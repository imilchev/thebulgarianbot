namespace TheBulgarianBot.Business.Replies
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Resource;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;

    /// <summary>
    /// A static class containing the replies.
    /// </summary>
    internal static class Replies
    {
        /// <summary>
        /// The default direct reply that will be sent whenever the user directly adresses the bot, but there is no
        /// predefined reply.
        /// </summary>
        public static Reply DefaultDirectReply;

        /// <summary>
        /// The list with replies that are used for global chat messages.
        /// </summary>
        public static List<Reply> RepliesList;

        /// <summary>
        /// The list with replies that are used when the bot is addressed directly.
        /// </summary>
        public static List<Reply> DirectReplies;

        /// <summary>
        /// Initializes the static fields of the <see cref="Replies"/> class.
        /// </summary>
        static Replies()
        {
            // Default direct reply.
            Replies.DefaultDirectReply = new TextReply(
                message: "WTF are you talking about, kopele?",
                replyTo: new List<Regex>());

            // Replies list.
            Replies.RepliesList = new List<Reply>
            {
                new TextReply(
                    message: "```triggered```",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bfree\b")
                    },
                    parseMode: ParseMode.Markdown),
                new TextReply(
                    message: "SEAL THE DEAL AND LET'S BOOGIE!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bdiscounts?\b"),
                        new Regex(@"\bsales?\b"),
                        new Regex(@"\bcheap(er)?\b"),
                        new Regex(@"\bразпродажб(а|и)\b"),
                        new Regex(@"\brazprodajb(a|i)\b")
                    }),
                new TextReply(
                    message: "Zdravei, uruspia",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bangelica\b"),
                        new Regex(@"\bgirls?\b"),
                        new Regex(@"\bwom(a|e)n\b")
                    }),
                new TextReply(
                    message: "*Gas chamber!*",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bnigg(a|er)\b"),
                        new Regex(@"\bblack\b")
                    },
                    parseMode: ParseMode.Markdown)
            };

            // Direct replies.
            Replies.DirectReplies = new List<Reply>
            {
                new TextReply(
                    message: "Every time is a good time for drinking!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\b When (should|must) \w drink\b", RegexOptions.IgnoreCase)
                    }),
                new TextReply(
                    message: "Po vsqko vreme!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\b Koga (triabva|trqbva) da (pia|piq)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\b Koga da (pia|piq)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\b Кога трябва? да пия\b", RegexOptions.IgnoreCase),
                    }),
                new PhotoReply(
                    fileName: "rakia.png",
                    caption: "The best drink man can get - RAKIA!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bWhat do Bulgarians drink\b", RegexOptions.IgnoreCase)
                    })
            };
        }
    }
}
