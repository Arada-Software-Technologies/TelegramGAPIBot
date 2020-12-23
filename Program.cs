using System;
using Telegram.Bot;
using System.IO;
using Telegram.Bot.Types.InputFiles;


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
        }
        }
    }
