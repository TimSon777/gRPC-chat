using System.Security.Claims;

// ReSharper disable once CheckNamespace
namespace Grpc.Core;

public static class ServerCallContextExtensions
{
    public static string UserName(this ServerCallContext context)
    {
        var httpContext = context.GetHttpContext();

        return httpContext.User.UserName();
    }
}