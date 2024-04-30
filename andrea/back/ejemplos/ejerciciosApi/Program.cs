using ejerciciosApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var startUp = new StartUp(builder.Configuration);

startUp.ConfigureServices(builder.Services);

var app = builder.Build();

startUp.Configure(app, app.Environment);

// Configure the HTTP request pipeline.

app.Run();
