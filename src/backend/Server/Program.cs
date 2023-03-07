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

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGrpcServices();

app.Run();