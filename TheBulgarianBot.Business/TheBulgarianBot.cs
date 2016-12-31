namespace TheBulgarianBot.Business
{
    using Telegram.Bot;
    using UpdateMessage;

    /// <summary>
    /// The main entry point for the bot.
    /// </summary>
    public class TheBulgarianBot
    {
        /// <summary>
        /// The access token for the bot.
        /// </summary>
        private const string token = "181586297:AAG7-FzzSV08Vd7-ONOnARSZmt_off0GQh4";

        /// <summary>
        /// The bot client.
        /// </summary>
        private readonly TelegramBotClient botClient;

        /// <summary>
        /// The update message handler.
        /// </summary>
        private readonly UpdateMessageHandler updateMessageHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="TheBulgarianBot"/> class.
        /// </summary>
        public TheBulgarianBot()
        {
            this.botClient = new TelegramBotClient(token);
            this.updateMessageHandler = new UpdateMessageHandler();

            this.botClient.OnUpdate += this.updateMessageHandler.OnUpdate;
        }

        /// <summary>
        /// Starts receiving messages and handling replies.
        /// </summary>
        public void StartReceiving()
        {
            this.botClient.StartReceiving();
        }
    }
}
