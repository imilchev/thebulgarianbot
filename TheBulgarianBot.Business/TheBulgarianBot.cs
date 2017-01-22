namespace TheBulgarianBot.Business
{
    using System.Threading;
    using Message;
    using Telegram.Bot;
    using Telegram.Bot.Args;

    /// <summary>
    /// The main entry point for the bot.
    /// </summary>
    public class TheBulgarianBot
    {
        /// <summary>
        /// The access token for the bot.
        /// </summary>
        private const string token = "302251638:AAF2FAcJomslmYVI_j6kTLEpyd5NjriNmyU";

        /// <summary>
        /// The bot client.
        /// </summary>
        private readonly TelegramBotClient botClient;

        /// <summary>
        /// The update message handler.
        /// </summary>
        private readonly OnMessageHandler onMessageHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="TheBulgarianBot"/> class.
        /// </summary>
        public TheBulgarianBot()
        {
            this.botClient = new TelegramBotClient(token);
            this.onMessageHandler = new OnMessageHandler();

            this.botClient.OnMessage += this.OnMessage;
        }

        /// <summary>
        /// Starts receiving messages and handling replies.
        /// </summary>
        public void StartReceiving()
        {
            this.botClient.StartReceiving();
        }

        /// <summary>
        /// Stops receiving messages and handling replies.
        /// </summary>
        public void StopReceiving()
        {
            this.botClient.StopReceiving();
        }

        /// <summary>
        /// Handles the on message event. Distributes the messages to the handler by using a thread pool.
        /// </summary>
        /// <param name="client">The telegram bot client instance.</param>
        /// <param name="args">The message event arguments.</param>
        private void OnMessage(object client, MessageEventArgs args)
        {
            ThreadPool.QueueUserWorkItem(
                this.onMessageHandler.OnMessage,
                new EventData<MessageEventArgs>((TelegramBotClient)client, args));
        }
    }
}