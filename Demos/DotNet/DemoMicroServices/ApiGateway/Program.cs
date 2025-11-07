using Ocelot.Middleware;
using Ocelot.DependencyInjection;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("OcelotAPIGWConfig.json");

            // Add services to the container.
            builder.Services.AddOcelot();
            //builder.Services.AddControllers();

            var app = builder.Build();

            //app.MapControllers();
            app.UseOcelot();

            app.Run();
        }
    }
}
