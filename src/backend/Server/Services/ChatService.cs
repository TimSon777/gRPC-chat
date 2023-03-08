using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Proto;
using Server.Abstractions;
using Server.Models;

namespace Server.Services;

public sealed class ChatService : Chat.ChatBase
{
    private readonly IChatMediator _chatMediator;

    public ChatService(IChatMediator chatMediator)
    {
        _chatMediator = chatMediator;
    }

    public override async Task<ConnectResponse> Connect(Empty request, ServerCallContext context)
    {
        var userName = context.UserName();

        var user = new User
        {
            UserName = userName
        };

        var connected = await _chatMediator.TryConnectUserAsync(user);

        return new ConnectResponse
        {
            Connected = connected
        };
    }

    public override async Task<Empty> SendMessage(SendMessageRequest request, ServerCallContext context)
    {
        var userName = context.UserName();
        var user = await _chatMediator.GetUserByNameAsync(userName);
        
        await _chatMediator.SaveMessageToUsersAsync(user, request.Text);
        
        return new Empty();
    }

    public override async Task ReceiveMessages(Empty request, IServerStreamWriter<ReceiveMessageResponse> responseStream, ServerCallContext context)
    {
        var userName = context.UserName();
        var user = await _chatMediator.GetUserByNameAsync(userName);

        await _chatMediator.SubscribeToReceiveMessages(user, responseStream);

        try
        {
            while (true)
            {
                await _chatMediator.BroadcastMessagesAsync(user, context.CancellationToken);
                await Task.Delay(1000);
            }
        }
        catch (OperationCanceledException)
        {
            await _chatMediator.DisconnectUserAsync(user);
        }
    }
}