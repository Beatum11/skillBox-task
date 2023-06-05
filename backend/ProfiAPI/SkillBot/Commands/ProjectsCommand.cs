using SkillBot.API.GET;
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
    public class ProjectsCommand : ICommand
    {
        #region fields

        private string commandName = "/projects";
        public string CommandName { get => commandName; }

        #endregion

        public async Task Execute(ITelegramBotClient botClient, Message message, 
                            CancellationToken token)
        {

            var projects = await ProjectsInfo.GetProjects();

            foreach (var project in projects)
            {
                var text = $"<b>{project.Title}</b>\n\n{project.Description}";

                await BotAssist.SendMessage(botClient, message, token, text);
            }
                
        }
    }
}
