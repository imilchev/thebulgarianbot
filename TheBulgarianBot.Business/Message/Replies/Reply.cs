namespace TheBulgarianBot.Business.Message.Replies
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Base class for a reply to a message.
    /// </summary>
    internal abstract class Reply
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reply"/> class.
        /// </summary>
        /// <param name="replyType">The type of reply.</param>
        /// <param name="replyToText">A list of regular expressions to which the reply should be sent if they match with
        /// the message that was sent.</param>
        /// <param name="replyToFileId">A list of file identifiers to which the reply should be sent if they match the
        /// sticker message that was sent.</param>
        protected Reply(ReplyType replyType, IEnumerable<Regex> replyToText, IEnumerable<string> replyToFileId)
        {
            this.ReplyType = replyType;
            this.ReplyToText = replyToText;
            this.ReplyToFileId = replyToFileId;
        }

        /// <summary>
        /// Gets or sets the type of reply.
        /// </summary>
        public ReplyType ReplyType { get; set; }

        /// <summary>
        /// Gets or sets a list of regular expressions to which the reply should be sent if they match with the message
        /// that was sent.
        /// </summary>
        public IEnumerable<Regex> ReplyToText { get; set; }

        /// <summary>
        /// Gets or sets a list of file identifiers to which the reply should be sent if they match the sticker message
        /// that was sent.
        /// </summary>
        public IEnumerable<string> ReplyToFileId { get; set; }
    }
}
