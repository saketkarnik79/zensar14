using API_DemoGRPC.Interceptors;
using API_DemoGRPC.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace API_DemoGRPC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime= true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer ="Zensar",
                        ValidAudience="ZensarAudience",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz"))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = ctx =>
                        {
                            // log or inspect ctx.Exception.Message
                            Console.WriteLine("Auth failed: " + ctx.Exception?.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = ctx =>
                        {
                            Console.WriteLine("Token validated for: " + ctx.Principal?.Identity?.Name);
                            return Task.CompletedTask;
                        }
                    };
                });
            builder.Services.AddAuthorization();

            // Add services to the container.
            builder.Services.AddGrpc();
            //builder.Services.AddGrpc(options =>
            //{
            //    options.Interceptors.Add<ServerLoggingInterceptor>();
            //});

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>();
            app.MapGrpcService<Chat>();
            app.MapGrpcService<Auth>();
            app.MapGet("/", () => "gRPC Sever is ready & running...");

            app.Run();
        }
    }
}