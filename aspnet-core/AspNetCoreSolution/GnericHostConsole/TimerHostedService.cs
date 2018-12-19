using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GnericHostConsole
{
    public class TimerHostedService : BackgroundService
    {
        private Timer _timer;
        private readonly ILogger _logger;
        private readonly AppSettings _settings;

        public TimerHostedService(ILoggerFactory loggerFactory, IOptionsSnapshot<AppSettings> options)
        {
            _logger = loggerFactory.CreateLogger<TimerHostedService>();
            _settings = options.Value;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(_settings.TimerPeriod));
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timer is stopping");
            _timer?.Change(Timeout.Infinite, 0);
            return base.StopAsync(cancellationToken);
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("Timer is working");
        }

        public override void Dispose()
        {
            _timer?.Dispose();
            base.Dispose();
        }
    }
}
