using Server.Services;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder;

public static class GrpcConfiguration
{
    public static WebApplication MapGrpcServices(this WebApplication app)
    {
        app.MapGrpcService<ChatService>();
        app.MapGrpcService<GreeterService>();
        return app;
    }
}