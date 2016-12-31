using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TheBulgarianBot.Business.Logger
{
    public static class Logger
    {
        private const string logFileBase = @"C:/TheBulgarianBot/log_";

        public static void LogAsync(Message message)
        {
            Logger.WriteLogAsync($"[{message.Date}] {message.From.FirstName} {message.From.LastName}: {message.Text}");
        }

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
