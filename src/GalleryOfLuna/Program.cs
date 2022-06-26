using GalleryOfLuna.EntityFramework;
using GalleryOfLuna.Extensions;

using Serilog;

namespace GalleryOfLuna
{
    internal class Program
    {
        public static async Task<int> Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();

                await host.MigrateDatabaseAsync<PublishingDbContext>();
                await host.RunAsync();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((context, _) =>
                        Log.Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(context.Configuration)
                            .CreateLogger());

                    webBuilder.UseStartup<Startup>();
                });
    }
}
