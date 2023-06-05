using SkillBot.API;
using SkillBot.Keyboard;
using SkillBot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace SkillBot.Commands
{
    public class ServicesCommand : ICommand
    {
        #region fields

        private string commandName = "/services";
        public string CommandName { get => commandName; }

        #endregion

        public async Task Execute(ITelegramBotClient botClient, Message message,
                                  CancellationToken token)
        {
            var services = await ServicesInfo.GetServices();

            foreach (var service in services)
            {
                var text = $"<b>{service.Title}</b>\n\n{service.Description}";
                
                await BotAssist.SendMessage(botClient, message, token, text);
            }
        }
    }
}
