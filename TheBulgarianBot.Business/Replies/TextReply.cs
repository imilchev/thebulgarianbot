using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace TheBulgarianBot.Business.Replies
{
    internal class TextReply : Reply
    {
        public TextReply(string message, IEnumerable<Regex> replyTo, ParseMode parseMode = ParseMode.Default)
            : base(replyType: ReplyType.Text, replyTo: replyTo, parseMode: parseMode)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}
