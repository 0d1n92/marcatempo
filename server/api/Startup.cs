using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using api.Helpers;
using api.Services;
using api.Authorization;
using Microsoft.EntityFrameworkCore;
using api.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System;

using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.HttpOverrides;

namespace api
{
    public class Startup
    {
    private readonly IWebHostEnvironment _env;
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

           string connectionString = Configuration.GetConnectionString("DefaultConnection");
              services.Configure<ForwardedHeadersOptions>(options =>
        {
        options.ForwardedHeaders =
                  ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });


      services.AddDbContext<DataContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            /*services.AddCors(options => options.AddPolicy("ApiCorsPolicy", build =>
             {
                 build.WithOrigins("http://localhost:8080")
                      .AllowAnyMethod()
                      .AllowAnyHeader();
             }));*/

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Marcatempo", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header enter Bearer [space] {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Scheme = "jwt",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Enumerable.Empty<string>().ToList()
                }

            });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddMvc();
            services.AddControllers().AddNewtonsoftJson(opts => {
                opts.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            }
            );
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IQrcodesService, QrcodesService>();
            services.AddScoped<IActionsService, ActionsService>();
            services.AddScoped<IEmailHelper, EmailHelper>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
              using (var scope = app.ApplicationServices.CreateScope())
              {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<DataContext>();
                context.Database.Migrate();
              }
        app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseForwardedHeaders();
            app.UsePathBase("/api");
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();
            app.UseEndpoints(x => x.MapControllers());
        }

    }
}
