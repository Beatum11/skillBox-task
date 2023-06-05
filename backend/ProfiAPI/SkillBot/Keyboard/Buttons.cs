using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace SkillBot.Keyboard
{
    public static class Buttons
    {
        public static IReplyMarkup? GetButtons()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] { "/start", "/projects"},
                new KeyboardButton[] { "/services", "/submit an application"}
            })
            {
                ResizeKeyboard = true
            };

            return replyKeyboardMarkup;
        }
    }
}
