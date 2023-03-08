using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

var jwtConfiguration = configuration.GetSection(JwtSettings.SectionKey);

services
    .AddOptions<JwtSettings>()
    .Bind(jwtConfiguration)
    .ValidateDataAnnotations()
    .ValidateOnStart();

var jwtSettings = new JwtSettings();
jwtConfiguration.Bind(jwtSettings);

services.AddJwrBearerAuthentication(jwtSettings);
services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

services.AddGrpc();
services.AddChatMediator();
services.AddJwtProvider();
services.AddCors(options => options.AddPolicy("grpc-cors-policy", corsPolicyBuilder =>
{
    corsPolicyBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");;
}));

var app = builder.Build();

app.UseGrpcWeb(); 
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapGrpcServices();

app.Run();