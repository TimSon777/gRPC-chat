using System.Collections.Concurrent;
using Grpc.Core;
using Proto;
using Server.Abstractions;
using Server.Models;

namespace Server.Implementations;

public sealed class ChatMediator : IChatMediator
{
    private static readonly ConcurrentDictionary<User, IServerStreamWriter<ReceiveMessageResponse>?> Users = new();

    public Task<User> GetUserByNameAsync(string userName)
    {
        var user = Users.Keys.First(u => u.UserName == userName);

        return Task.FromResult(user);
    }

    public Task<bool> TryConnectUserAsync(User user)
    {
        var added = Users.TryAdd(user, null);

        return Task.FromResult(added);
    }

    public Task DisconnectUserAsync(User user)
    {
        Users.TryRemove(user, out _);
        
        return Task.CompletedTask;
    }

    public Task<bool> SubscribeToReceiveMessages(User user, IServerStreamWriter<ReceiveMessageResponse> responseWriter)
    {
        if (Users[user] is null)
        {
            return Task.FromResult(false);
        }

        Users[user] = responseWriter;
        
        return Task.FromResult(true);
    }

    public Task SaveMessageToUsersAsync(User user, string text)
    {
        foreach (var pair in Users)
        {
            pair.Key.ReceiveMessage(user, text);
        }
        
        return Task.CompletedTask;
    }

    public async Task BroadcastMessagesAsync(User user, CancellationToken cancellationToken)
    {
        var streamWriter = Users[user];

        var messages = user.GetMessages();

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