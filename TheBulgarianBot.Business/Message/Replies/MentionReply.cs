namespace TheBulgarianBot.Business.Message.Replies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Telegram.Bot.Types;
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
            : base(replyType: ReplyType.Mention, replyToText: replyTo, replyToFileId: new List<string>())
        {
            this.message = message;
            this.ParseMode = parseMode;
        }

        /// <summary>
        /// Gets or sets the parse mode for the message.
        /// </summary>
        public ParseMode ParseMode { get; set; }

        /// <summary>
        /// Gets the username to which the message should reply.
        /// </summary>
        /// <param name="message">The message requesting the mention.</param>
        /// <returns>The username to which the message should reply.</returns>
        public static string GetReplyToUsername(Message message)
        {
            var entity = message.Entities.FirstOrDefault(x => x.Type == MessageEntityType.TextMention);

            string name;
            if (entity != null)
            {
                name = $"[{entity.User.FirstName}](tg://user?id={entity.User.Id})";
            }
            else
            {
                var text = message.Text;

                // If the message starts with the name of the bot, then remove it, so it is not parsed.
                if (text.StartsWith("@thebulgarianbot"))
                {
                    var i = text.IndexOf(" ", StringComparison.OrdinalIgnoreCase) + 1;
                    text = text.Substring(i);
                }

                name = text.Split(' ').First(x => x.StartsWith("@"));
            }

            return name;
        }

        /// <summary>
        /// Checks whether a username is equal to the reply to usersername for the mention.
        /// </summary>
        /// <param name="message">The message requesting the mention.</param>
        /// <param name="username">The username to compare with.</param>
        /// <returns>Whether the username is equal to the one that is requested.</returns>
        public static bool IsReplyToUsernameEqualTo(Message message, string username)
        {
            var entity = message.Entities.FirstOrDefault(x => x.Type == MessageEntityType.TextMention);

            if (entity != null)
            {
                return !(entity.User.Username == null) && entity.User.Username.Equals(username, StringComparison.OrdinalIgnoreCase);
            }

            var text = message.Text;

            // If the message starts with the name of the bot, then remove it, so it is not parsed.
            if (text.StartsWith("@thebulgarianbot"))
            {
                var i = text.IndexOf(" ", StringComparison.OrdinalIgnoreCase) + 1;
                text = text.Substring(i);
            }

            return text.Split(' ').First(x => x.StartsWith("@")).Equals($"@{username}", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets the message for this reply by prepending the <see cref="message"/> in front of the message.
        /// </summary>
        /// <param name="username">The username which should be mentioned.</param>
        /// <returns>The message.</returns>
        public string GetMessage(string username)
        {
            return $"{username}, {this.message}";
        }
    }
}