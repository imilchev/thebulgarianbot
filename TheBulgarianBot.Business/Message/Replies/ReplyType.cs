namespace TheBulgarianBot.Business.Message.Replies
{
    /// <summary>
    /// An enumeration representing the different types of reply.
    /// </summary>
    public enum ReplyType
    {
        /// <summary>
        /// The reply contains text.
        /// </summary>
        Text = 0,

        /// <summary>
        /// The reply contains a photo.
        /// </summary>
        Photo = 1,

        /// <summary>
        /// The reply contains a sticker.
        /// </summary>
        Sticker = 2,

        /// <summary>
        /// The reply contains text but needs a usersname specified.
        /// </summary>
        Mention = 3,
    }
}
