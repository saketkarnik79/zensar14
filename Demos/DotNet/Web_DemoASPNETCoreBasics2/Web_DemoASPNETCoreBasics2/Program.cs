using Web_DemoASPNETCoreBasics2.Middlewares;
using Web_DemoASPNETCoreBasics2.Services.Contracts;
using Web_DemoASPNETCoreBasics2.Services;

namespace Web_DemoASPNETCoreBasics2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IDataService, DataServiceV1>();
            builder.Services.AddTransient<IDataService, DataServiceV2>();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Use the custom middleware
            //app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseRequestLogging();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
