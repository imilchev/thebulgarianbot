namespace TheBulgarianBot.Business.Replies
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Telegram.Bot.Types.Enums;

    /// <summary>
    /// A class representing a text reply.
    /// </summary>
    internal class TextReply : Reply
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextReply"/> class.
        /// </summary>
        /// <param name="message">The message of the reply.</param>
        /// <param name="replyTo">A list of regular expressions to which the reply should be sent if they match with the
        /// message that was sent.</param>
        /// <param name="parseMode">The parse mode for the message. By default set to <see cref="ParseMode.Default"/>.
        /// </param>
        public TextReply(string message, IEnumerable<Regex> replyTo, ParseMode parseMode = ParseMode.Default)
            : base(replyType: ReplyType.Text, replyTo: replyTo)
        {
            this.Message = message;
            this.ParseMode = parseMode;
        }

        /// <summary>
        /// Gets or sets the message of the reply.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the parse mode for the message.
        /// </summary>
        public ParseMode ParseMode { get; set; }
    }
}
