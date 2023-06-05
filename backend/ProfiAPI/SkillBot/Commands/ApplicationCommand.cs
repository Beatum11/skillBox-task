using SkillBot.API.POST;
using SkillBot.Keyboard;
using SkillBot.Models.DTOs;
using SkillBot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SkillBot.Commands
{
    public class ApplicationCommand
    {
        #region fields

        private string commandName = "/submit an application";
        public string CommandName { get => commandName; }

        #endregion

        public async Task Execute(ITelegramBotClient botClient, Message message,
                            CancellationToken token, ClientDto clientInfo)
        {
            if(clientInfo.Name == null)
                await BotAssist.SendMessage(botClient, message, token, 
                                        "Write your name: ");
            else if (clientInfo.Email == null)
                await BotAssist.SendMessage(botClient, message, token,
                                        "Write your email: ");
            else if(clientInfo.Message == null)
                await BotAssist.SendMessage(botClient, message, token,
                                        "Write your message: ");
            else
            {
                await BotAssist.SendMessage(botClient, message, token, 
                                            $"Your Name: {clientInfo.Name}\n" +
                                            $"Your Email: {clientInfo.Email}\n" +
                                            $"Your Message: {clientInfo.Message}\n\n" +
                                            $"<b>We'll reply as soon as possible!</b>");

                await ApplicationRequest.PostDataAsync(clientInfo);
            }
        }
    }
}
