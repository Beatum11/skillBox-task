using Microsoft.VisualBasic;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Microsoft.Extensions.Configuration;
using SkillBot.Commands;
using SkillBot.Models.DTOs;
using SkillBot.Utils;

#region First Part

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var botToken = configuration["TelegramBot_AccessToken"];

ICommand[] commands = new ICommand[]
{
    new ProjectsCommand(),
    new StartCommand(),
    new ServicesCommand()
};

ApplicationCommand appCommand = new ApplicationCommand();
ClientDto clientInfo = new ClientDto();

var commandExecutor = new CommandsExecutor(commands, appCommand, clientInfo);

#endregion

#region Second Part

if (botToken != null)
{
    var botClient = new TelegramBotClient(botToken);

    using CancellationTokenSource cts = new();

    ReceiverOptions receiverOptions = new()
    {
        AllowedUpdates = Array.Empty<UpdateType>() 
    };

    botClient.StartReceiving(
        updateHandler: HandleUpdateAsync,
        pollingErrorHandler: HandlePollingErrorAsync,
        receiverOptions: receiverOptions,
        cancellationToken: cts.Token
    );

    var me = await botClient.GetMeAsync();

    Console.WriteLine($"Start listening for @{me.Username}");
    Console.ReadLine();

    cts.Cancel();
}
#endregion

#region Third Part

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    var message = update.Message;
    if(message != null)
        await commandExecutor.ExecuteCommand(botClient, message, cancellationToken);
}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}


#endregion


