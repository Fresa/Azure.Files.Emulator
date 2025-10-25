using Example.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapOperations();
app.Run();
