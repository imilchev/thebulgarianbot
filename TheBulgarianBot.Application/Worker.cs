using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TheBulgarianBot.Application
{
    public class Worker : BackgroundService
    {
        private readonly Business.TheBulgarianBot theBulgarianBot;

        public Worker(IConfiguration config)
        {
            this.theBulgarianBot = new Business.TheBulgarianBot(config["BotToken"], config["ImagesFolder"]);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.theBulgarianBot.StartReceiving();
            Business.Logger.Logger.Instance.Information("The bot is started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }

            Business.Logger.Logger.Instance.Information("Stopping the bot...");
            this.theBulgarianBot.StopReceiving();
            Business.Logger.Logger.Instance.Information("The bot is stopped.");
        }
    }
}
