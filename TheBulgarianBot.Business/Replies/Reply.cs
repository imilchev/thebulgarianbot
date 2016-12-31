using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace TheBulgarianBot.Business.Replies
{
    internal abstract class Reply
    {
        protected Reply(ReplyType replyType, IEnumerable<Regex> replyTo, ParseMode parseMode = ParseMode.Default)
        {
            this.ReplyType = replyType;
            this.ReplyTo = replyTo;
            this.ParseMode = parseMode;
        }

        public ReplyType ReplyType { get; set; }

        public IEnumerable<Regex> ReplyTo { get; set; } 

        public ParseMode ParseMode { get; set; }
    }
}
