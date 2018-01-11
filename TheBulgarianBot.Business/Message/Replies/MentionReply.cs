namespace TheBulgarianBot.Business.Message.Replies
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Telegram.Bot.Types.Enums;

    /// <summary>
    /// A class representing a mention reply.
    /// </summary>
    internal class MentionReply : Reply
    {
        private readonly string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="MentionReply"/> class.
        /// </summary>
        /// <param name="message">The message of the reply.</param>
        /// <param name="replyTo">A list of regular expressions to which the reply should be sent if they match with the
        /// message that was sent.</param>
        /// <param name="parseMode">The parse mode for the message. By default set to <see cref="ParseMode.Default"/>.
        /// </param>
        public MentionReply(string message, IEnumerable<Regex> replyTo, ParseMode parseMode = ParseMode.Default)
            : base(replyType: ReplyType.Mention, replyTo: replyTo)
        {
            this.message = message;
            this.ParseMode = parseMode;
        }

        /// <summary>
        /// Gets or sets the parse mode for the message.
        /// </summary>
        public ParseMode ParseMode { get; set; }

        /// <summary>
        /// Gets the message for this reply by prepending the <see cref="message"/> in front of the message.
        /// </summary>
        /// <param name="username">The username which should be mentioned</param>
        /// <returns>The message</returns>
        public string GetMessage(string username)
        {
            return $"{username}, {this.message}";
        }
    }
}