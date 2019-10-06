using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BulkSalesWebApp
{
    /*
     * 1. Create RESTfull API for Post entity
     * 2. ASP.NET Routing?
     * 3. How to organize context better (maybe create one more)
     * + 4. Add Comment entity
     * 5. question in TokenService
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
