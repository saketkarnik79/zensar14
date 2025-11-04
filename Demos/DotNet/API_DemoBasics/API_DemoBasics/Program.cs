using Microsoft.EntityFrameworkCore;
using API_DemoBasics.Data;
using API_DemoBasics.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API_DemoBasics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<JwtIssuanceService>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!))
                    };
                });

            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<ZenClientsDbContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores <ZenClientsDbContext> ()
                .AddDefaultTokenProviders();

            //builder.Services.AddControllers();
            //builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();
            builder.Services.AddControllers(options => 
            {
                options.RespectBrowserAcceptHeader = true;
            }).AddXmlDataContractSerializerFormatters();
            //builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(options => 
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization Header using the Bearer scheme. Example: \"Authoration: Bearer {token}\"",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    } 
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (builder.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); //This must come before UseAuthorization
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
