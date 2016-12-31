using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace TheBulgarianBot.Business.Replies
{
    internal static class Replies
    {
        public static Reply DefaultDirectReply;
        public static List<Reply> RepliesList;
        public static List<Reply> DirectReplies;

        static Replies()
        {
            Replies.DefaultDirectReply = new TextReply(
                message: "WTF are you talking about, kopele?",
                replyTo: new List<Regex>());

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
                    })
            };
        }
    }
}
