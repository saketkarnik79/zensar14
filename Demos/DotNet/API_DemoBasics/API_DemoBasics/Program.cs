using Microsoft.EntityFrameworkCore;
using API_DemoBasics.Data;

namespace API_DemoBasics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ZenClientsDbContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            //builder.Services.AddControllers();
            //builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();
            builder.Services.AddControllers(options => 
            {
                options.RespectBrowserAcceptHeader = true;
            }).AddXmlDataContractSerializerFormatters();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (builder.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
