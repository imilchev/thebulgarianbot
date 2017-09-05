namespace TheBulgarianBot.Business.Message.Replies
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using global::TheBulgarianBot.Business.Resource;
    using Telegram.Bot.Types;

    /// <summary>
    /// A class representing a sticker reply.
    /// </summary>
    internal class StickerReply : Reply
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StickerReply"/> class.
        /// </summary>
        /// <param name="fileId">The file ID of the sticker to send as reply.</param>
        /// <param name="replyTo">A list of regular expressions to which the reply should be sent if they match with the
        /// message that was sent.</param>
        public StickerReply(string fileId, IEnumerable<Regex> replyTo)
            : base(replyType: ReplyType.Sticker, replyTo: replyTo)
        {
            this.FileId = fileId;
        }

        /// <summary>
        /// Gets or sets the file ID of the sticker to send as reply.
        /// </summary>
        public string FileId { get; }

        /// <summary>
        /// Gets the corresponding file that should be sent.
        /// </summary>
        public FileToSend Sticker => new FileToSend(this.FileId);
    }
}
