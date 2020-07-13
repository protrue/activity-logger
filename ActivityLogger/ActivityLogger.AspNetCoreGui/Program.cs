using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ActivityLogger.AspNetCoreGui
{
    using ElectronNET.API;

    public class Program
    {
        public static void Main(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseElectron(args);
                    webBuilder.UseStartup<Startup>();
                })
                .Build()
                .Run();
    }
}