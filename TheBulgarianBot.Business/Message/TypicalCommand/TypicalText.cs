namespace TheBulgarianBot.Business.Message.TypicalCommand
{
    /// <summary>
    /// A class used for the /typical command. It contains the top and bottom text for the profile picture of the user.
    /// </summary>
    public class TypicalText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypicalText"/> class.
        /// </summary>
        /// <param name="topText">The top text for the profile picture.</param>
        /// <param name="bottomText">The bottom text for the profile picture.</param>
        public TypicalText(string topText, string bottomText)
        {
            this.TopText = topText;
            this.BottomText = bottomText;
        }

        /// <summary>
        /// Gets the top text for the profile picture.
        /// </summary>
        public string TopText { get; }

        /// <summary>
        /// Gets the bottom text for the profile picture.
        /// </summary>
        public string BottomText { get; }
    }
}
