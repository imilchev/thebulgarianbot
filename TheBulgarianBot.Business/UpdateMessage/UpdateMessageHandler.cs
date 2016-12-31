using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TheBulgarianBot.Business.Replies;

namespace TheBulgarianBot.Business.UpdateMessage
{
    internal class UpdateMessageHandler
    {
        public UpdateMessageHandler()
        {

        }

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

        private void OnMessageUpdate(TelegramBotClient botClient, Update update)
        {
            switch (update.Message.Type)
            {
                case MessageType.TextMessage:
                    // Check whether the bot was directly addressed or if it was a normal message in the chat.
                    var reply = this.MatchReply(
                        update.Message.Text.StartsWith("@thebulgarianbot")
                            ? Replies.Replies.DirectReplies
                            : Replies.Replies.RepliesList,
                        update.Message.Text);

                    // Log the message if it was directly addressed to the bot and no reply was found.
                    // Send the default direct reply to the user.
                    if (reply == null && update.Message.Text.StartsWith("@thebulgarianbot"))
                    {
                        Logger.Logger.LogAsync(update.Message);
                        reply = Replies.Replies.DefaultDirectReply;
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

        private void SendReply(TelegramBotClient botClient, Message message, Reply reply)
        {
            switch (reply.ReplyType)
            {
                case ReplyType.Text:
                    botClient.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: ((TextReply)reply).Message,
                            replyToMessageId: message.MessageId,
                            parseMode: reply.ParseMode);
                    break;
                case ReplyType.Photo:

                    break;
                default:
                    Logger.Logger.WriteLogAsync("[EXCEPTION]: Invalid reply type encountered.");
                    break;
            }
        }

        private Reply MatchReply(List<Reply> replies, string messageText)
        {
            return replies.FirstOrDefault(r => r.ReplyTo.Any(m => m.IsMatch(messageText)));
        }
    }
}
