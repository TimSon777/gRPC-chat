using System.Collections.Concurrent;
using Grpc.Core;
using Proto;
using Server.Abstractions;
using Server.Models;

namespace Server.Implementations;

public sealed class ChatMediator : IChatMediator
{
    private static readonly ConcurrentDictionary<User, IServerStreamWriter<ReceiveMessageResponse>?> Users = new();

    public Task<bool> TryConnectUserAsync(User user)
    {
        var added = Users.TryAdd(user, null);

        return Task.FromResult(added);
    }

    public Task DisconnectUserAsync(User user)
    {
        Users.Remove(user, out _);
        
        return Task.CompletedTask;
    }

    public Task SubscribeToReceiveMessages(User user, IServerStreamWriter<ReceiveMessageResponse> responseWriter)
    {
        Users[user] = responseWriter;
        
        return Task.CompletedTask;
    }

    public Task SaveMessageToUsersAsync(User user, string text)
    {
        foreach (var internalUser in Users)
        {
            internalUser.Key.ReceiveMessage(user.UserName, text);
        }
        
        return Task.CompletedTask;
    }

    public async Task BroadcastMessagesAsync(User user, CancellationToken cancellationToken)
    {
        var (userWithMessages, streamWriter) = Users.First(pair => pair.Key.Equals(user));

        var messages = userWithMessages.GetMessages();

        foreach (var message in messages)
        {
            var response = new ReceiveMessageResponse
            {
                From = message.UserName,
                Text = message.Text
            };

            if (streamWriter is not null)
            {
                await streamWriter.WriteAsync(response, cancellationToken);
            }
        }
    }
}