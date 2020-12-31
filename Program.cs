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


        double operand1, operand2, result;


        static string btnUseCalculator = "Use Calculator";
        static string btnAboutTheDesigner = "About";

        //static string btnNumberSeven = "7";
        //static string btnNumberEight = "8";
        //static string btnNumberNine = "9";
        //static string btnNumberFour = "4";
        //static string btnNumberFive = "5";
        //static string btnNumberSix = "6";
        //static string btnNumberOne = "1";
        //static string btnNumbertwo = "2";
        //static string btnNumberthree = "3";
        //static string btnNumberZero = "0";
        //static string btnPoint = ".";


        static string btnAddn = "+";
        static string btnSubn = "-";
        static string btnTimes = "*";
        static string btnDivide = "/";
        static string btnEquals = "=";



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
        
        private static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (!onOperation)
            {
                if (e.Message.Text == "/Start")
                {
                    deleteErrorMsg(e);
                    calculatorMenu(e);

                }
                else{
                    ReplyKeyboardMarkup ikm = new ReplyKeyboardMarkup();
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, "Thanks for Choosing Me", replyMarkup: ikm);
                }

                

            }


        }
        static void useCalculator(Telegram.Bot.Args.MessageEventArgs e)
        {
            botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
            botClient.DeleteMessageAsync(e.Message.Chat.Id, presgID);
            //onOperation = true;
            botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
            calculatorMenu(e);


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
        //function for welcoming the User
        static void Welcome(Telegram.Bot.Args.MessageEventArgs e)
        {
            // Defining the Keyboard buttons for the main menu
            KeyboardButton[][] button = { new KeyboardButton[1], new KeyboardButton[1]};
            

            button[0][0] = new KeyboardButton(btnUseCalculator);
            button[1][0] = new KeyboardButton(btnAboutTheDesigner);
      

            //Defining the Keyboard that contains the buttons above
            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(button);

            //adjusts the size of the custom keyboard to what is only is needed
            keyboard.ResizeKeyboard = true;
         
            ReplyKeyboardMarkup keyboardMarkup = new ReplyKeyboardMarkup(button);
            botClient.SendTextMessageAsync(e.Message.Chat, "Use the Buttons Provided Below :", replyMarkup: keyboardMarkup);

            //deletes the '/start' text            
            botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);


            
            //deletes the '/start' text            
            botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);

            if (e.Message.Text == "Use Calculator" || e.Message.Text == "btnUseCalculator")
            {
                //botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                //botClient.DeleteMessageAsync(e.Message.Chat.Id, markupMsgID);
                //onOperation = true;
                //useCalculator(e);
            }
            else if (e.Message.Text == "About" || e.Message.Text == "btnAboutTheDesigner")
            {
                botClient.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                botClient.DeleteMessageAsync(e.Message.Chat.Id, markupMsgID);
                //ReplyKeyboardMarkup keyboardMarkup = new ReplyKeyboardMarkup();
                botClient.SendTextMessageAsync(e.Message.Chat, "Designed and Developed by Bitsuamlak", replyMarkup: keyboardMarkup);
            }

        }
    }
}

