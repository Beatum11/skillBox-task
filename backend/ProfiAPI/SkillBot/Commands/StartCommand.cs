using Telegram.Bot.Types;
using Telegram.Bot;
using SkillBot.Keyboard;
using static System.Net.Mime.MediaTypeNames;
using Telegram.Bot.Types.Enums;
using SkillBot.Utils;

namespace SkillBot.Commands
{
    public class StartCommand : ICommand
    {
        #region Fields

        private string commandName = "/start";
        public string CommandName { get => commandName; }

        #endregion

        public async Task Execute(ITelegramBotClient botClient, Message message, 
                                  CancellationToken token)
        {
            var text = 
            $"<b>Good Day!</b> My name is <i>Bot Skilly</i>🤖.\nHow can I help you:";

            await BotAssist.SendMessage(botClient, message, token, text);
        }

    }
}
