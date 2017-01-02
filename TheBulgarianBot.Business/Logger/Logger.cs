namespace TheBulgarianBot.Business.Logger
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Telegram.Bot.Types;

    /// <summary>
    /// Static class for logging messages in a log file.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// The base file name for the log file.
        /// </summary>
        private const string logFileBase = @"D:/TheBulgarianBot/Logs/log_";

        /// <summary>
        /// Logs a <see cref="Message"/> in the log file.
        /// </summary>
        /// <param name="message">The <see cref="Message"/> to be logged.</param>
        public static void LogMessageAsync(Message message)
        {
            Logger.WriteLogAsync($"[{message.Date}] {message.From.FirstName} {message.From.LastName}: {message.Text}");
        }

        /// <summary>
        /// Logs a string message in the log file.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public static async void WriteLogAsync(string message)
        {
            await Task.Run(() =>
            {
                var date = DateTime.Today.Date.ToString("ddMMyyyy");
                var filename = logFileBase + date + ".txt";

                var file = System.IO.File.Exists(filename)
                    ? System.IO.File.Open(filename, FileMode.Append)
                    : System.IO.File.Create(filename);

                using (var writer = new StreamWriter(file))
                {
                    writer.WriteLine(message);
                }
            });
        }
    }
}
