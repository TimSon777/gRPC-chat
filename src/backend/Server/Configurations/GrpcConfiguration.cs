using Server.Services;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder;

public static class GrpcConfiguration
{
    public static WebApplication MapGrpcServices(this WebApplication app)
    {
        app.MapGrpcService<ChatService>().EnableGrpcWeb().RequireCors("grpc-cors-policy");
        app.MapGrpcService<AuthService>().EnableGrpcWeb().RequireCors("grpc-cors-policy");
        return app;
    }
}