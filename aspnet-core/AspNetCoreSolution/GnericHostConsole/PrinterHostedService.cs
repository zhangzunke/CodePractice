using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace GnericHostConsole
{
    public class PrinterHostedService : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly AppSettings _settings;

        public PrinterHostedService(ILoggerFactory loggerFactory, IOptionsSnapshot<AppSettings> options)
        {
            _logger = loggerFactory.CreateLogger<PrinterHostedService>();
            _settings = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Printer is working. {_settings.PrinterDelaySecond}");
                await Task.Delay(TimeSpan.FromSeconds(_settings.PrinterDelaySecond), stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Printer is stopped");
            return base.StopAsync(cancellationToken);
        }
    }
}
