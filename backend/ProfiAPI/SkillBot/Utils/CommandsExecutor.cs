using SkillBot.Commands;
using SkillBot.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace SkillBot.Utils
{
    public class CommandsExecutor
    {
        #region fields

        private ICommand[] _commands;
        private ApplicationCommand _appCommand;
        private ClientDto _clientInfo;

        #endregion

        #region constructor

        public CommandsExecutor(ICommand[] commands, ApplicationCommand appCommand, ClientDto clientInfo)
        {
            _commands = commands;
            _appCommand = appCommand;
            _clientInfo = clientInfo;
        }

        #endregion
        public async Task ExecuteCommand(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            foreach (var command in _commands)
            {
                if (message?.Text == command.CommandName)
                {
                    await command.Execute(botClient, message, cancellationToken);
                    return;
                }
            }

            if (message?.Text == _appCommand.CommandName)
            {
                await _appCommand.Execute(botClient, message, cancellationToken, _clientInfo);
                return;
            }

            if (_clientInfo.Name == null || _clientInfo.Email == null || _clientInfo.Message == null)
            {
                ClientsAssist.UpdateClientInfo(message?.Text, _clientInfo);
                await _appCommand.Execute(botClient, message, cancellationToken, _clientInfo);
            }
        }
    }
}
