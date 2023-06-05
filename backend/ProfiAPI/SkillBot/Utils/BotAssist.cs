using SkillBot.Keyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace SkillBot.Utils
{
    public static class BotAssist
    {
        public static async Task SendMessage(ITelegramBotClient botClient, Message message,
                                             CancellationToken token, string textToSend)
        {
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: textToSend,
                parseMode: ParseMode.Html,
                replyMarkup: Buttons.GetButtons(),
                cancellationToken: token);
        }
    }
}
