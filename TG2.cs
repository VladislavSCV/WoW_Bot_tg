using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using static System.Net.WebRequestMethods;

var botClient = new TelegramBotClient("5848473957:AAGzbL-pYqLkjNaJOQLtp1Tft6_80SsiLpI");

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

Console.WriteLine($"Bot name:{me.Username}");
Console.ReadLine();


cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    
    if (update.Message is not { } message)
        return;
    
    if (message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    DateTime dt = new DateTime();
    int dth = dt.Hour;
    int dth2 = dt.Minute;

    Console.WriteLine($"Messege text:{messageText}; Chat Id:{chatId};{DateTime.Now}");

    switch (messageText)
    {
        case "/start":
            Message message0 = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Hello! This bot will help you learn English! You need to select a team and do a test.! ",
            cancellationToken: cancellationToken);
            break;
        case "/command2":
            Message message001 = await botClient.SendPhotoAsync(
                        chatId: chatId,
                        photo: "https://fs.znanio.ru/d5af0e/85/2f/59c8b00cdf6e1e19edb7d4c429eb5c9a38.jpg",
                        caption: "<b>Help</b> <i></i> <a href=\"\"></a>",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
            Message message00 = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Plurals! Test 1." +
            $"\n https://wordwall.net/play/1512/897/2666",
            cancellationToken: cancellationToken);
            Message message01 = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Plurals! Test 2. " +
            $"\n https://wordwall.net/play/1399/804/8900",
            cancellationToken: cancellationToken);
            Message message02 = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Plurals! Test 3. " +
            $"\n https://wordwall.net/play/1899/001/572",
            cancellationToken: cancellationToken);
            break;
        case "/command1":
            Message message10 = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Placement test" +
            $"\n https://wordwall.net/play/4066/938/466",
            cancellationToken: cancellationToken);
            break;
        case "/command3":
            Message message200 = await botClient.SendPhotoAsync(
                        chatId: chatId,
                        photo: "https://memorial-zv.ru/800/600/https/ds05.infourok.ru/uploads/ex/0b28/000798bf-e93f5b5d/img1.jpg",
                        caption: "<b>Help</b> <i></i> <a href=\"\"></a>",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
            Message message20 = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Present|past|future|Simple" +
            $"\n https://wordwall.net/play/1750/155/5892",
            cancellationToken: cancellationToken);
            break;
    }
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
