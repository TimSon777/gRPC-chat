using Grpc.Core;
using Proto;
using Server.Models;

namespace Server.Abstractions;

public interface IChatMediator
{
    Task<User> GetUserByNameAsync(string userName);
    Task<bool> TryConnectUserAsync(User user);
    Task DisconnectUserAsync(User user, IServerStreamWriter<ReceiveMessageResponse> serverStreamWriter);
    Task SubscribeToReceiveMessages(User user, IServerStreamWriter<ReceiveMessageResponse> responseWriter);
    Task SaveMessageToUsersAsync(User user, string text);
    Task BroadcastMessagesAsync(User user, CancellationToken cancellationToken);
}