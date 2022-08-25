using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
