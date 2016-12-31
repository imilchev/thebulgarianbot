namespace TheBulgarianBot.Business.Replies
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Telegram.Bot.Types.Enums;

    /// <summary>
    /// A class representing a photo reply.
    /// </summary>
    internal class PhotoReply : Reply
    {
        // TODO: fix photo type
        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoReply"/> class.
        /// </summary>
        /// <param name="photo">The photo for the message</param>
        /// <param name="replyTo">A list of regular expressions to which the reply should be sent if they match with the
        /// message that was sent.</param>
        /// <param name="parseMode">The parse mode for the message.</param>
        public PhotoReply(string photo, IEnumerable<Regex> replyTo, ParseMode parseMode = ParseMode.Default)
            : base(replyType: ReplyType.Text, replyTo: replyTo, parseMode: parseMode)
        {
        }
    }
}
