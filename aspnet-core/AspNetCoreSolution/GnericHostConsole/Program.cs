using Microsoft.Extensions.Hosting;
using System;
using NLog;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace GnericHostConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                //logging
                .ConfigureLogging(factory => 
                {
                    factory.AddNLog(new NLogProviderOptions { CaptureMessageProperties = true, CaptureMessageTemplates = true });
                    NLog.LogManager.LoadConfiguration("nlog.config");
                })
                //host config
                .ConfigureHostConfiguration(config => 
                {
                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                //app config
                .ConfigureAppConfiguration((hostContext, config) => 
                {
                    var env = hostContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureServices((hostContext, services) => 
                {
                    services.AddOptions();
                    services.Configure<AppSettings>(hostContext.Configuration.GetSection("AppSettings"));

                    services.AddHostedService<PrinterHostedService>();
                    services.AddHostedService<TimerHostedService>();

                });

            await builder.RunConsoleAsync();
            //Console.WriteLine("Hello World!");
        }
    }
}
