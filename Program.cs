using System;
using Telegram.Bot;
using System.IO;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramGAPIBot
{
    class Program
    {
        static TelegramBotClient botClient = new TelegramBotClient("1338176434:AAHj44O4diyNRxeZNH2P12qIX7A-_EIDpsI");
        static bool start = false;


        static string btnUseCalculator = "Use Calculator";
        static string btnAboutTheDesigner = "About";


        //true if on Operation going. . . 
        static bool onOperation = false;


        //holds the id of the last send message by the bot for deleting or editing the message 
        static int presgID, markupMsgID, errMsgID;
     
        static void Main(string[] args)
        {
            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();
            Console.ReadLine();
        }
        static void deleteErrorMsg(Telegram.Bot.Args.MessageEventArgs e)
        {
            //catches message not found exception
            try
            {
                botClient.DeleteMessageAsync(e.Message.Chat.Id, errMsgID);
            }
            catch (Exception)
            {

            }
        }
      
        static void calculatorMenu(Telegram.Bot.Args.MessageEventArgs e)
        {

            KeyboardButton[][] buttons = new KeyboardButton[4][];

            buttons[0] = new KeyboardButton[4];
            buttons[1] = new KeyboardButton[4];
            buttons[2] = new KeyboardButton[4];
            buttons[3] = new KeyboardButton[4];


            buttons[0][0] = new KeyboardButton("7");
            buttons[0][1] = new KeyboardButton("8");
            buttons[0][2] = new KeyboardButton("9");
            buttons[0][3] = new KeyboardButton("+");

            buttons[1][0] = new KeyboardButton("4");
            buttons[1][1] = new KeyboardButton("5");
            buttons[1][2] = new KeyboardButton("6");
            buttons[1][3] = new KeyboardButton("/");

            buttons[2][0] = new KeyboardButton("1");
            buttons[2][1] = new KeyboardButton("2");
            buttons[2][2] = new KeyboardButton("3");
            buttons[2][3] = new KeyboardButton("*");

            buttons[3][0] = new KeyboardButton(".");
            buttons[3][1] = new KeyboardButton("0");
            buttons[3][2] = new KeyboardButton("-");
            buttons[3][3] = new KeyboardButton("=");



            ReplyKeyboardMarkup keyboardMarkup = new ReplyKeyboardMarkup(buttons);
            keyboardMarkup.ResizeKeyboard = true;


            botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
            botClient.SendTextMessageAsync(e.Message.Chat, "Send after inserting the Number you want to Operate", replyMarkup: keyboardMarkup);
  
        }

        static void getNumberthen(Telegram.Bot.Args.MessageEventArgs e)
        {

            onOperation = true;
            if (e.Message.Text == "7")
            {
                Console.WriteLine("seben");


            }
        }


        
        private static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {

            if (e.Message.Text == "/Start")
            {
                start = true;
                if (start)
                {
                    deleteErrorMsg(e);
                    calculatorMenu(e);
                   if (e.Message.Text == "7")
                    {
                        onOperation = true;
                        
                     


                    }
                }
               

            }


         }


        }
     
}


