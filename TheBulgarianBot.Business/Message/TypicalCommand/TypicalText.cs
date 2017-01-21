using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBulgarianBot.Business.Message.TypicalCommand
{
    public class TypicalText
    {
        public TypicalText(string topText, string bottomText)
        {
            this.TopText = topText;
            this.BottomText = bottomText;
        }

        public string TopText { get; }

        public string BottomText { get; }
    }
}
