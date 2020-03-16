namespace TheBulgarianBot.Business.Message
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Replies;
    using Telegram.Bot;
    using Telegram.Bot.Args;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;
    using TypicalCommand;

    /// <summary>
    /// A class responsible for handling messages adressed to the bot.
    /// </summary>
    internal class OnMessageHandler
    {
        /// <summary>
        /// Holds the instance for random generation.
        /// </summary>
        private static readonly Random Rand;

        /// <summary>
        /// Initializes static members of the <see cref="OnMessageHandler"/> class.
        /// </summary>
        static OnMessageHandler()
        {
            OnMessageHandler.Rand = new Random();
        }

        /// <summary>
        /// Handles the message received event.
        /// </summary>
        /// <param name="data">The event data.</param>
        public async void OnMessage(object data)
        {
            try
            {
                var eventData = (EventData<MessageEventArgs>)data;
                var botClient = eventData.Client;
                switch (eventData.EventArgs.Message.Type)
                {
                    case MessageType.Text:
                        if (eventData.EventArgs.Message.Text.StartsWith("/"))
                        {
                            await this.HandleCommands(botClient, eventData.EventArgs.Message);
                        }
                        else
                        {
                            await this.HandleTextMessages(botClient, eventData.EventArgs.Message);
                        }

                        break;
                    case MessageType.Sticker:
                        await this.HandleStickerMessages(botClient, eventData.EventArgs.Message);
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Instance.Fatal(ex, "Unexpected error");
            }
        }

        /// <summary>
        /// Sends a reply to the given message.
        /// </summary>
        /// <param name="botClient">The bot client.</param>
        /// <param name="message">The original message that was sent.</param>
        /// <param name="reply">The reply to be sent.</param>
        private async Task SendReply(TelegramBotClient botClient, Message message, Reply reply)
        {
            var replyToMessageId = message.Chat.Type == ChatType.Private ? 0 : message.MessageId;

            switch (reply.ReplyType)
            {
                case ReplyType.Text:
                    var textReply = (TextReply)reply;
                    await botClient.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: textReply.Message,
                            replyToMessageId: replyToMessageId,
                            parseMode: textReply.ParseMode);
                    break;
                case ReplyType.Photo:
                    var photoReply = (PhotoReply)reply;
                    await botClient.SendPhotoAsync(
                        chatId: message.Chat.Id,
                        photo: photoReply.FileToSend,
                        caption: photoReply.Caption,
                        replyToMessageId: replyToMessageId);
                    break;
                case ReplyType.Sticker:
                    var stickerReply = (StickerReply)reply;
                    await botClient.SendStickerAsync(
                        chatId: message.Chat.Id,
                        sticker: stickerReply.Sticker,
                        replyToMessageId: replyToMessageId);
                    break;
                case ReplyType.Mention:
                    var mentionReply = (MentionReply)reply;

                    await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: mentionReply.GetMessage(MentionReply.GetReplyToUsername(message)),
                        parseMode: ParseMode.Markdown);
                    break;
                default:
                    Logger.Logger.Instance.Error("Invalid reply type {ReplyType} encountered.", reply.ReplyType);
                    break;
            }
        }

        /// <summary>
        /// Handles the commands for the bot.
        /// </summary>
        /// <param name="botClient">The telegram bot client instance.</param>
        /// <param name="message">The message containing the command.</param>
        private async Task HandleCommands(TelegramBotClient botClient, Message message)
        {
            if (message.Text.StartsWith("/typical"))
            {
                await TypicalCommandHandler.HandleTypicalCommand(botClient, message);
            }
        }

        /// <summary>
        /// Handles the text messages addressed to the bot.
        /// </summary>
        /// <param name="botClient">The telegram bot client.</param>
        /// <param name="message">The message addressed to the bot.</param>
        private async Task HandleTextMessages(TelegramBotClient botClient, Message message)
        {
            // Check if it was a direction mention.
            var isMentioned = message.Text.StartsWith("@thebulgarianbot");
            var isPrivate = message.Chat.Type == ChatType.Private;

            if (Regexes.CurseOrderRegexes.Any(r => r.IsMatch(message.Text)) &&
                (message.Entities.Any(x => x.Type == MessageEntityType.TextMention) ||
                 message.Entities.Count(x => x.Type == MessageEntityType.Mention) > 1))
            {
                if (message.From.Username != null && !MentionReply.IsReplyToUsernameEqualTo(message, "ivanmilchev"))
                {
                    var mentionReplies = Replies.Replies.MentionReplies;
                    await this.SendReply(
                        botClient,
                        message,
                        mentionReplies[OnMessageHandler.Rand.Next(mentionReplies.Count)]);
                }
                else
                {
                    await this.SendReply(botClient, message, Replies.Replies.DefaultCurseOrderReply);
                }
            }
            else
            {
                // Check whether the bot was directly addressed or if it was a normal message in the chat.
                var reply = this.MatchReply(
                    isMentioned && !isPrivate
                        ? Replies.Replies.DirectReplies
                        : isPrivate
                            ? Replies.Replies.RepliesList.Concat(Replies.Replies.DirectReplies).ToList()
                            : Replies.Replies.RepliesList,
                    message);

                // Log the message if it was directly addressed to the bot and no reply was found.
                // Send the default direct reply to the user.
                if (reply == null && (isMentioned || isPrivate))
                {
                    Logger.Logger.Instance.Warning("{Username}: {Text}", message.From.Username, message.Text);
                    reply = Replies.Replies.DefaultDirectReply;
                }

                // If the reply is not null then send it back.
                if (reply != null)
                {
                    await this.SendReply(botClient, message, reply);
                }
            }
        }

        /// <summary>
        /// Handles the text messages addressed to the bot.
        /// </summary>
        /// <param name="botClient">The telegram bot client.</param>
        /// <param name="message">The message addressed to the bot.</param>
        private async Task HandleStickerMessages(TelegramBotClient botClient, Message message)
        {
            if (message.ReplyToMessage != null && message.ReplyToMessage.From.IsBot &&
                     message.ReplyToMessage.From.Username.Equals("thebulgarianbot"))
            {
                // Check whether the bot was directly addressed or if it was a normal message in the chat.
                var reply = this.MatchReply(Replies.Replies.DirectReplies, message);

                // If the reply is not null then send it back.
                if (reply != null)
                {
                    await this.SendReply(botClient, message, reply);
                }
            }
        }

        /// <summary>
        /// Finds the corresponding reply for the received message. In case there are multiple replies a random one is
        /// picked. Null if no reply was found.
        /// </summary>
        /// <param name="replies">The list with replies from which one should be picked.</param>
        /// <param name="message">The message that was received.</param>
        /// <returns>The corresponding reply if one was found or a random one if many matches. Null if no reply was
        /// found.</returns>
        private Reply MatchReply(IReadOnlyList<Reply> replies, Message message)
        {
            List<Reply> matchingReplies = new List<Reply>();

            switch (message.Type)
            {
                case MessageType.Text:
                    matchingReplies = replies.Where(r => r.ReplyToText.Any(m => m.IsMatch(message.Text))).ToList();
                    break;
                case MessageType.Sticker:
                    matchingReplies = replies.Where(r => r.ReplyToFileId.Any(m => m.Equals(message.Sticker.FileUniqueId)))
                        .ToList();
                    break;
            }

            return matchingReplies.Count > 0
                ? matchingReplies[OnMessageHandler.Rand.Next(matchingReplies.Count)]
                : null;
        }
    }
}
