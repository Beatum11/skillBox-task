using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SkillBot.Commands
{
    //We can make this interface "internal"
    public interface ICommand
    {
        string CommandName { get; }
        Task Execute(ITelegramBotClient botClient, Message message, CancellationToken token);
    }
}
