namespace TheBulgarianBot.Business
{
    using Telegram.Bot;

    /// <summary>
    /// A class representing event data. It contains the telegram bot client instance and the event data itself.
    /// </summary>
    /// <typeparam name="T">The type of event data.</typeparam>
    public class EventData<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventData{T}"/> class.
        /// </summary>
        /// <param name="client">The telegram bot client instance.</param>
        /// <param name="eventArgs">The event arguments.</param>
        public EventData(TelegramBotClient client, T eventArgs)
        {
            this.Client = client;
            this.EventArgs = eventArgs;
        }

        /// <summary>
        /// Gets the telegram bot client instance.
        /// </summary>
        public TelegramBotClient Client { get; }

        /// <summary>
        /// Gets the event arguments.
        /// </summary>
        public T EventArgs { get; }
    }
}
