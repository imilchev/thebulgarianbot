namespace TheBulgarianBot.Business.Message.TypicalCommand
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Telegram.Bot;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.InputFiles;

    /// <summary>
    /// Handles the /typical command.
    /// </summary>
    internal static class TypicalCommandHandler
    {
        /// <summary>
        /// Holds the instance for random generation.
        /// </summary>
        private static readonly Random Rand;

        /// <summary>
        /// Initializes static members of the <see cref="TypicalCommandHandler"/> class.
        /// </summary>
        static TypicalCommandHandler()
        {
            TypicalCommandHandler.Rand = new Random();
        }

        /// <summary>
        /// Handles the /typical command, by retrieving the user's profile picture and putting a random text on it.
        /// </summary>
        /// <param name="botClient">The telegram bot client instance.</param>
        /// <param name="message">The message containing the command.</param>
        /// <returns>A task that is resolved once the method execution is completed.</returns>
        public static async Task HandleTypicalCommand(TelegramBotClient botClient, Message message)
        {
            // Get the profile pics for the user.
            var profilePics = await botClient.GetUserProfilePhotosAsync(message.From.Id);

            if (profilePics.TotalCount > 0)
            {
                // Filter the profile pics by getting a random one from them and then getting it in a size
                // bigger or equal than 320.
                var profilePicsFilteredList = profilePics.Photos
                    .SelectMany(x => x.Where(y => y.Width >= 640))
                    .ToList();

                // Get a random picture of that size.
                var profilePic =
                    profilePicsFilteredList[TypicalCommandHandler.Rand.Next(profilePicsFilteredList.Count)];

                // Retrieve the picture itself.
                using var profilePicStream = new MemoryStream();
                var text =
                    TypicalTexts.TypicalTextsList[TypicalCommandHandler.Rand.Next(TypicalTexts.TypicalTextsList.Count)];

                var profileFile = await botClient.GetFileAsync(profilePic.FileId);
                await botClient.DownloadFileAsync(profileFile.FilePath, profilePicStream);

                using var image = Image.FromStream(profilePicStream);
                using var graphics = Graphics.FromImage(image);
                using var ms = new MemoryStream();
                using var stringFormat = new StringFormat(StringFormat.GenericDefault) { Alignment = StringAlignment.Center };

                // Determine initial font size.
                var fontSize = profilePic.Height / 15;

                // Create the font.
                var font = new Font("DejaVu Sans", fontSize, FontStyle.Bold);

                // Determine whether the top or the bottom text is longer.
                var longerText = text.TopText.Length > text.BottomText.Length ? text.TopText : text.BottomText;

                font = TypicalCommandHandler.GetFontSize(font, graphics, longerText, profilePic.Width);

                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                var textContainingBox = new SizeF(profilePic.Width, fontSize * 1.4f);

                // Top text
                var top = new RectangleF(new PointF(0, 0), new SizeF(profilePic.Width, fontSize * 1.4f));

                graphics.DrawString(
                    text.TopText,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(-2, -2), textContainingBox),
                    stringFormat);
                graphics.DrawString(
                    text.TopText,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(-2, 2), textContainingBox),
                    stringFormat);
                graphics.DrawString(text.TopText, font, Brushes.White, top, stringFormat);

                // Bottom text
                var bottomPointY = profilePic.Height - (fontSize * 1.4f);
                var bottom = new RectangleF(
                    new PointF(0, bottomPointY),
                    new SizeF(profilePic.Width, fontSize * 1.4f));

                graphics.DrawString(
                    text.BottomText,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(-2, bottomPointY - 2), textContainingBox),
                    stringFormat);
                graphics.DrawString(
                    text.BottomText,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(-2, bottomPointY + 2), textContainingBox),
                    stringFormat);
                graphics.DrawString(text.BottomText, font, Brushes.White, bottom, stringFormat);

                // Save the resulting image in a memory stream.
                image.Save(ms, ImageFormat.Png);

                // Restart the position of the pointer in the memory stream, otherwise an exception occurs.
                ms.Position = 0;

                // Wait for the call to return, otherwise the objects will be disposed before they are sent.
                botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(ms, "typical.png")).Wait();

                // Dispose the font and paths since they are not in a using statement.
                font.Dispose();
            }
            else
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Sloji si snimka i posle me zanimavai we");
            }
        }

        /// <summary>
        /// Get the correct font size so the string fits in the desired width.
        /// </summary>
        /// <param name="font">The initial font. It is going to be reused entirely except for the size.</param>
        /// <param name="graphics">The <see cref="Graphics"/> instance used for measuring the string width.</param>
        /// <param name="text">The text.</param>
        /// <param name="desiredWidth">The width in which the text should fit.</param>
        /// <returns>Returns the corresponding font, to fit the string in the desired width.</returns>
        private static Font GetFontSize(Font font, Graphics graphics, string text, float desiredWidth)
        {
            while (graphics.MeasureString(text, font).Width > desiredWidth)
            {
                font = new Font(font.FontFamily, font.Size - 1, FontStyle.Bold);
            }

            return font;
        }
    }
}
