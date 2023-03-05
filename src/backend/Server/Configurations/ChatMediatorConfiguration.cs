using Server.Abstractions;
using Server.Implementations;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ChatMediatorConfiguration
{
    public static IServiceCollection AddChatMediator(this IServiceCollection services)
    {
        services.AddSingleton<IChatMediator, ChatMediator>();
        return services;
    }
}