namespace TheBulgarianBot.Business.UpdateMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Replies;
    using Telegram.Bot;
    using Telegram.Bot.Args;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;

    internal class UpdateMessageHandler
    {
        /// <summary>
        /// Holds the instance for random generation.
        /// </summary>
        private static readonly Random rand;

        /// <summary>
        /// Initializes the static fields of the <see cref="UpdateMessageHandler"/> class.
        /// </summary>
        static UpdateMessageHandler()
        {
            UpdateMessageHandler.rand = new Random();
        }

        /// <summary>
        /// Handles the update event for the bot.
        /// </summary>
        /// <param name="client">The bot client raising the event.</param>
        /// <param name="args">The update event arguments</param>
        public void OnUpdate(object client, UpdateEventArgs args)
        {
            var botClient = (TelegramBotClient)client;
            switch (args.Update.Type)
            {
                case UpdateType.MessageUpdate:
                    this.OnMessageUpdate(botClient, args.Update);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the message update event for the bot.
        /// </summary>
        /// <param name="botClient">The bot client raising the event.</param>
        /// <param name="update">The update data.</param>
        private void OnMessageUpdate(TelegramBotClient botClient, Update update)
        {
            switch (update.Message.Type)
            {
                case MessageType.TextMessage:
                    // Check whether the bot was directly addressed or if it was a normal message in the chat.
                    var reply = this.MatchReply(
                        update.Message.Text.StartsWith("@thebulgarianbot")
                            ? Replies.DirectReplies
                            : Replies.RepliesList,
                        update.Message.Text);

                    // Log the message if it was directly addressed to the bot and no reply was found.
                    // Send the default direct reply to the user.
                    if (reply == null && update.Message.Text.StartsWith("@thebulgarianbot"))
                    {
                        Logger.Logger.LogMessageAsync(update.Message);
                        reply = Replies.DefaultDirectReply;
                    }

                    // If the reply is not null then send it back.
                    if (reply != null)
                    {
                        this.SendReply(botClient, update.Message, reply);   
                    }

                    break;
                default:
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
                            replyToMessageId: message.MessageId,
                            parseMode: textReply.ParseMode);
                    break;
                case ReplyType.Photo:
                    var photoReply = (PhotoReply) reply;
                    botClient.SendPhotoAsync(
                        chatId: message.Chat.Id,
                        photo: photoReply.FileToSend,
                        caption: photoReply.Caption,
                        replyToMessageId: message.MessageId);
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
                ? matchingReplies[UpdateMessageHandler.rand.Next(matchingReplies.Count)]
                : null;
        }
    }
}
