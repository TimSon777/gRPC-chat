var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddGrpc();
services.AddChatMediator();

var app = builder.Build();

app.MapGrpcServices();

app.Run();