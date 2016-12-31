namespace TheBulgarianBot.Business.Replies
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Telegram.Bot.Types.Enums;

    /// <summary>
    /// Base class for a reply to a message.
    /// </summary>
    internal abstract class Reply
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reply"/> class.
        /// </summary>
        /// <param name="replyType">The type of reply.</param>
        /// <param name="replyTo">A list of regular expressions to which the reply should be sent if they match with the
        /// message that was sent.</param>
        protected Reply(ReplyType replyType, IEnumerable<Regex> replyTo)
        {
            this.ReplyType = replyType;
            this.ReplyTo = replyTo;
        }

        /// <summary>
        /// Gets or sets the type of reply.
        /// </summary>
        public ReplyType ReplyType { get; set; }

        /// <summary>
        /// Gets or sets a list of regular expressions to which the reply should be sent if they match with the message
        /// that was sent.
        /// </summary>
        public IEnumerable<Regex> ReplyTo { get; set; } 
    }
}
