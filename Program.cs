using System;
using Telegram.Bot;
//using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
//using Telegram.Bot.Types;
//using Telegram.Bot.Types.Enums;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Google.Cloud.Vision.V1;

namespace TelegramGAPIBot
{
    class Program
    {
        static TelegramBotClient botClient = new TelegramBotClient("1338176434:AAHj44O4diyNRxeZNH2P12qIX7A-_EIDpsI");
        static void Main(string[] args)
        {
            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();
            Console.ReadLine();
        }

        private static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Console.WriteLine(e.Message.Text);


            if (e.Message.Text == "Hi")
            {
                botClient.SendTextMessageAsync(e.Message.Chat.Id, "What's Up ?");
            }
            // Defining Keyboard button that requests a contact
            KeyboardButton button = KeyboardButton.WithRequestContact("Send contact");

            //Defining Keyboard that contains the button
            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(button);

            // Send keyboard with message!
             botClient.SendTextMessageAsync(e.Message.Chat, "Please send contact", replyMarkup: keyboard);


        }
        
    }
}
