namespace TheBulgarianBot.Business.Message.GeneralaCommand
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Telegram.Bot;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.InputFiles;

    /// <summary>
    /// Handles the /generala command.
    /// </summary>
    internal class GeneralaCommandHandler
    {
        /// <summary>
        /// Holds the path for the images folder.
        /// </summary>
        private readonly string generalaImagesFolderPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralaCommandHandler"/> class.
        /// </summary>
        /// <param name="imagesFolderPath">The path to the images folder.</param>
        internal GeneralaCommandHandler(string imagesFolderPath)
        {
            this.generalaImagesFolderPath = Path.Combine(imagesFolderPath, "generala");
        }

        /// <summary>
        /// Handles the /generala command, by sending a random meme.
        /// </summary>
        /// <param name="botClient">The telegram bot client instance.</param>
        /// <param name="message">The message containing the command.</param>
        /// <returns>A task that is resolved once the method execution is completed.</returns>
        public async Task HandleGeneralaCommand(TelegramBotClient botClient, Message message)
        {
            var images = Directory.GetFiles(this.generalaImagesFolderPath);

            var imageToSend = images[Randomizer.Random.Next(images.Length)];

            using var stream = System.IO.File.OpenRead(imageToSend);
            await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream, imageToSend));
        }
    }
}
