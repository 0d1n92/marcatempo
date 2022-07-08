
using api;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();
app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
startup.Configure(app, app.Environment);

app.Run();