namespace TheBulgarianBot.Business.Message.Replies
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using global::TheBulgarianBot.Business.Resource;
    using Telegram.Bot.Types;

    /// <summary>
    /// A class representing a photo reply.
    /// </summary>
    internal class PhotoReply : Reply
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoReply"/> class.
        /// </summary>
        /// <param name="fileName">The name of the photo to be sent.</param>
        /// <param name="replyTo">A list of regular expressions to which the reply should be sent if they match with the
        /// message that was sent.</param>
        /// <param name="caption">The caption for the photo. By default set to null.</param>
        public PhotoReply(string fileName, IEnumerable<Regex> replyTo, string caption = null)
            : base(replyType: ReplyType.Photo, replyTo: replyTo)
        {
            this.FileName = fileName;
            this.Caption = caption;
        }

        /// <summary>
        /// Gets or sets the photo to send as reply.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the caption for the photo.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Gets the corresponding file that should be sent.
        /// </summary>
        public FileToSend FileToSend => new FileToSend(this.FileName, ResourceLoader.LoadResource(this.FileName));
    }
}
