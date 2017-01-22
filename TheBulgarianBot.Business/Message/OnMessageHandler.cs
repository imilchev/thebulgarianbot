namespace TheBulgarianBot.Business.Message
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        private static readonly Random rand;

        /// <summary>
        /// Initializes the static fields of the <see cref="OnMessageHandler"/> class.
        /// </summary>
        static OnMessageHandler()
        {
            OnMessageHandler.rand = new Random();
        }

        /// <summary>
        /// Handles the message received event.
        /// </summary>
        /// <param name="data">The event data.</param>
        public void OnMessage(object data)
        {
            var eventData = (EventData<MessageEventArgs>)data;
            var botClient = eventData.Client;
            switch (eventData.EventArgs.Message.Type)
            {
                case MessageType.TextMessage:
                    if (eventData.EventArgs.Message.Text.StartsWith("/"))
                    {
                        this.HandleCommands(botClient, eventData.EventArgs.Message);
                    }
                    else
                    {
                        this.HandleTextMessages(botClient, eventData.EventArgs.Message);
                    }

                    break;
            }
        }

        /// <summary>
        /// Sends a reply to the given message.
        /// </summary>
        /// <param name="botClient">The bot client.</param>
        /// <param name="message">The original message that was sent.</param>
        /// <param name="reply">The reply to be sent.</param>
        private void SendReply(TelegramBotClient botClient, Message message, Reply reply)
        {
            switch (reply.ReplyType)
            {
                case ReplyType.Text:
                    var textReply = (TextReply)reply;
                    botClient.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: textReply.Message,
                            replyToMessageId: message.Chat.Type == ChatType.Private ? 0 : message.MessageId,
                            parseMode: textReply.ParseMode);
                    break;
                case ReplyType.Photo:
                    var photoReply = (PhotoReply)reply;
                    botClient.SendPhotoAsync(
                        chatId: message.Chat.Id,
                        photo: photoReply.FileToSend,
                        caption: photoReply.Caption,
                        replyToMessageId: message.Chat.Type == ChatType.Private ? 0 : message.MessageId);
                    break;
                default:
                    Logger.Logger.WriteLogAsync("[EXCEPTION]: Invalid reply type encountered.");
                    break;
            }
        }

        /// <summary>
        /// Handles the commands for the bot.
        /// </summary>
        /// <param name="botClient">The telegram bot client instance.</param>
        /// <param name="message">The message containing the command.</param>
        private void HandleCommands(TelegramBotClient botClient, Message message)
        {
            if (message.Text.StartsWith("/typical"))
            {
                TypicalCommandHandler.HandleTypicalCommand(botClient, message);
            }
        }

        /// <summary>
        /// Handles the text messages addressed to the bot.
        /// </summary>
        /// <param name="botClient">The telegram bot client.</param>
        /// <param name="message">The message addressed to the bot.</param>
        private void HandleTextMessages(TelegramBotClient botClient, Message message)
        {
            // Check if it was a direction mention.
            var isMentioned = message.Text.StartsWith("@thebulgarianbot");
            var isPrivate = message.Chat.Type == ChatType.Private;

            // Check whether the bot was directly addressed or if it was a normal message in the chat.
            var reply = this.MatchReply(
                isMentioned && !isPrivate
                    ? Replies.Replies.DirectReplies
                    : isPrivate
                        ? Replies.Replies.RepliesList.Concat(Replies.Replies.DirectReplies).ToList()
                        : Replies.Replies.RepliesList,
                message.Text);

            // Log the message if it was directly addressed to the bot and no reply was found.
            // Send the default direct reply to the user.
            if (reply == null && (isMentioned || isPrivate))
            {
                Logger.Logger.LogMessageAsync(message);
                reply = Replies.Replies.DefaultDirectReply;
            }

            // If the reply is not null then send it back.
            if (reply != null)
            {
                this.SendReply(botClient, message, reply);
            }
        }

        /// <summary>
        /// Finds the corresponding reply for the received message. In case there are multiple replies a random one is
        /// picked. Null if no reply was found.
        /// </summary>
        /// <param name="replies">The list with replies from which one should be picked.</param>
        /// <param name="messageText">The text of the message that was received.</param>
        /// <returns>The corresponding reply if one was found or a random one if many matches. Null if no reply was
        /// found.</returns>
        private Reply MatchReply(IReadOnlyList<Reply> replies, string messageText)
        {
            var matchingReplies = replies.Where(r => r.ReplyTo.Any(m => m.IsMatch(messageText))).ToList();

            return matchingReplies.Count > 0
                ? matchingReplies[OnMessageHandler.rand.Next(matchingReplies.Count)]
                : null;
        }
    }
}
