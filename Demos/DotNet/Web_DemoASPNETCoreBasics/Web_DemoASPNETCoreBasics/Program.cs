namespace Web_DemoASPNETCoreBasics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Middleware components
            app.Use(async (context, next) =>
            {
                Console.WriteLine("Request incoming...");
                await next(); // Call the next middleware
                Console.WriteLine("Response outgoing...");
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.MapGet("/", () => "Hello, ASP.NET Core!");

            app.Run();
        }
    }
}
