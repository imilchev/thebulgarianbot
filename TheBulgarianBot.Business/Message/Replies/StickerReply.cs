namespace TheBulgarianBot.Business.Message.Replies
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using global::TheBulgarianBot.Business.Resource;
    using Telegram.Bot.Types.InputFiles;

    /// <summary>
    /// A class representing a sticker reply.
    /// </summary>
    internal class StickerReply : Reply
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StickerReply"/> class.
        /// </summary>
        /// <param name="fileId">The file ID of the sticker to send as reply.</param>
        /// <param name="replyToText">A list of regular expressions to which the reply should be sent if they match with
        /// the message that was sent.</param>
        /// <param name="replyToFileId">A list of file identifiers to which the reply should be sent if they match the
        /// sticker message that was sent.</param>
        public StickerReply(string fileId, IEnumerable<Regex> replyToText, IEnumerable<string> replyToFileId)
            : base(replyType: ReplyType.Sticker, replyToText: replyToText, replyToFileId: replyToFileId)
        {
            this.FileId = fileId;
        }

        /// <summary>
        /// Gets the file ID of the sticker to send as reply.
        /// </summary>
        public string FileId { get; }

        /// <summary>
        /// Gets the corresponding file that should be sent.
        /// </summary>
        public InputOnlineFile Sticker => new InputOnlineFile(this.FileId);
    }
}
