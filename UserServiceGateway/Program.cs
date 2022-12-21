var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "User-Service-Gateway Running Successfully...");

app.Run();
