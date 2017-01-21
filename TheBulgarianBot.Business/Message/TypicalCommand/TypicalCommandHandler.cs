namespace TheBulgarianBot.Business.Message.TypicalCommand
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using Telegram.Bot;
    using Telegram.Bot.Types;

    public static class TypicalCommandHandler
    {
        /// <summary>
        /// Holds the instance for random generation.
        /// </summary>
        private static readonly Random rand;

        /// <summary>
        /// Initializes the static fields of the <see cref="OnMessageHandler"/> class.
        /// </summary>
        static TypicalCommandHandler()
        {
            TypicalCommandHandler.rand = new Random();
        }

        public static void HandleTypicalCommand(TelegramBotClient botClient, Message message)
        {
            // Get the profile pics for the user.
            var profilePics = botClient.GetUserProfilePhotosAsync(message.From.Id).Result;

            if (profilePics.TotalCount > 0)
            {
                // Filter the profile pics by getting a random one from them and then getting it in a size
                // bigger or equal than 320.
                var profilePicsFilteredList = profilePics.Photos
                    .SelectMany(x => x.Where(y => y.Width >= 320))
                    .ToList();

                // Get a random picture of that size.
                var profilePic =
                    profilePicsFilteredList[TypicalCommandHandler.rand.Next(profilePicsFilteredList.Count)];

                // Retrieve the picture itself.
                var profilePicFile = botClient.GetFileAsync(profilePic.FileId).Result;

                var text = Text.typicalTexts[TypicalCommandHandler.rand.Next(Text.typicalTexts.Count)];

                using (var image = Image.FromStream(profilePicFile.FileStream))
                using (var graphics = Graphics.FromImage(image))
                using (var ms = new MemoryStream())
                using (var topPath = new GraphicsPath())
                using (var bottomPath = new GraphicsPath())
                using (var stringFormat =
                    new StringFormat(StringFormat.GenericDefault) {Alignment = StringAlignment.Center})
                {
                    // Determine initial font size.
                    var fontSize = profilePic.Height/15;

                    // Create the font.
                    var font = new Font("Arial", fontSize, FontStyle.Bold);

                    // Determine whether the top or the bottom text is longer.
                    var longerText = text.TopText.Length > text.BottomText.Length ? text.TopText : text.BottomText;

                    var top = new RectangleF(new PointF(0, 0), new SizeF(profilePic.Width, (fontSize*1.4f)));

                    font = TypicalCommandHandler.GetFontSize(font, graphics, longerText, profilePic.Width);

                    // Add the string to the path.
                    topPath.AddString(
                        text.TopText, // text to draw
                        font.FontFamily, // or any other font family
                        (int) font.Style, // font style (bold, italic, etc.)
                        graphics.DpiY*font.Size/72, // em size
                        top, // location where to draw text
                        stringFormat); // set options here (e.g. center alignment)

                    graphics.DrawPath(new Pen(Brushes.Black, font.Size/10), topPath);
                    graphics.FillPath(Brushes.White, topPath);

                    var bottom = new RectangleF(
                        new PointF(0, profilePic.Height - (fontSize*1.4f)),
                        new SizeF(profilePic.Width, fontSize*1.4f));

                    // Add the string to the path.
                    bottomPath.AddString(
                        text.BottomText, // text to draw
                        font.FontFamily, // or any other font family
                        (int) font.Style, // font style (bold, italic, etc.)
                        graphics.DpiY*font.Size/72, // em size
                        bottom, // location where to draw text
                        stringFormat); // set options here (e.g. center alignment)
                    graphics.DrawPath(new Pen(Brushes.Black, font.Size/10), bottomPath);
                    graphics.FillPath(Brushes.White, bottomPath);

                    // Save the resulting image in a memory stream.
                    image.Save(ms, ImageFormat.Png);

                    // Restart the position of the pointer in the memory stream, otherwise an exception occurs.
                    ms.Position = 0;

                    // Wait for the call to return, otherwise the objects will be disposed before they are sent.
                    botClient.SendPhotoAsync(message.Chat.Id, new FileToSend("typical.png", ms)).Wait();

                    // Dispose the font and paths since they are not in a using statement.
                    font.Dispose();
                }
            }
            else
            {
                botClient.SendTextMessageAsync(message.Chat.Id, "Sloji si snimka i posle me zanimavai we");
            }
        }

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
