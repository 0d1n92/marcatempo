
using api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration, builder.Environment);

startup.ConfigureServices(builder.Services);

var app = builder.Build();
if (builder.Environment.IsDevelopment())
{
    app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
}
else
{
   app.UseCors(options => options.WithOrigins(builder.Configuration["Client:url"]).AllowAnyMethod().AllowAnyHeader());
}
startup.Configure(app, app.Environment);

app.Run();