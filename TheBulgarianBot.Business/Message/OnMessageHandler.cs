namespace TheBulgarianBot.Business.Message
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::TheBulgarianBot.Business.Replies;
    using Telegram.Bot;
    using Telegram.Bot.Args;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;

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
        /// <param name="client">The bot client raising the event.</param>
        /// <param name="args">The message event arguments.</param>
        public void OnMessage(object client, MessageEventArgs args)
        {
            var botClient = (TelegramBotClient) client;
            switch (args.Message.Type)
            {
                case MessageType.TextMessage:
                    // Check if it was a direction mention.
                    var isMentioned = args.Message.Chat.Type == ChatType.Private
                        || args.Message.Text.StartsWith("@thebulgarianbot");

                    // Check whether the bot was directly addressed or if it was a normal message in the chat.
                    var reply = this.MatchReply(
                        isMentioned
                            ? Replies.DirectReplies
                            : Replies.RepliesList,
                        args.Message.Text);

                    // Log the message if it was directly addressed to the bot and no reply was found.
                    // Send the default direct reply to the user.
                    if (reply == null && isMentioned)
                    {
                        Logger.Logger.LogMessageAsync(args.Message);
                        reply = Replies.DefaultDirectReply;
                    }

                    // If the reply is not null then send it back.
                    if (reply != null)
                    {
                        this.SendReply(botClient, args.Message, reply);
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
                    var textReply = (TextReply) reply;
                    botClient.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: textReply.Message,
                            replyToMessageId: message.Chat.Type == ChatType.Private ? 0 : message.MessageId,
                            parseMode: textReply.ParseMode);
                    break;
                case ReplyType.Photo:
                    var photoReply = (PhotoReply) reply;
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
        /// Finds the corresponding reply for the received message. In case there are multiple replies a random one is
        /// picked. Null if no reply was found.
        /// </summary>
        /// <param name="replies">The list with replies from which one should be picked.</param>
        /// <param name="messageText">The text of the message that was received.</param>
        /// <returns>The corresponding reply if one was found or a random one if many matches. Null if no reply was
        /// found.</returns>
        private Reply MatchReply(List<Reply> replies, string messageText)
        {
            var matchingReplies = replies.Where(r => r.ReplyTo.Any(m => m.IsMatch(messageText))).ToList();

            return matchingReplies.Count > 0 
                ? matchingReplies[OnMessageHandler.rand.Next(matchingReplies.Count)]
                : null;
        }
    }
}
