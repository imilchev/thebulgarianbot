using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using TheBulgarianBot.Business.UpdateMessage;

namespace TheBulgarianBot.Business
{
    public class TheBulgarianBot
    {
        private const string token = "181586297:AAG7-FzzSV08Vd7-ONOnARSZmt_off0GQh4";
        private readonly TelegramBotClient botClient;
        private readonly UpdateMessageHandler updateMessageHandler;

        public TheBulgarianBot()
        {
            this.botClient = new TelegramBotClient(token);
            this.updateMessageHandler = new UpdateMessageHandler();

            this.botClient.OnUpdate += this.updateMessageHandler.OnUpdate;
        }

        public void StartReceiving()
        {
            this.botClient.StartReceiving();
        }
    }
}
