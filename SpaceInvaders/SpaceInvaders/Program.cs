using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string strTitle = "   _____                        _____                     _               \r\n  / ____|                      |_   _|                   | |              \r\n | (___  _ __   __ _  ___ ___    | |  _ ____   ____ _  __| | ___ _ __ ___ \r\n  \\___ \\| '_ \\ / _` |/ __/ _ \\   | | | '_ \\ \\ / / _` |/ _` |/ _ \\ '__/ __|\r\n  ____) | |_) | (_| | (_|  __/  _| |_| | | \\ V / (_| | (_| |  __/ |  \\__ \\\r\n |_____/| .__/ \\__,_|\\___\\___| |_____|_| |_|\\_/ \\__,_|\\__,_|\\___|_|  |___/\r\n        | |                                                               \r\n        |_|                                                               ";

            char chrLanguage;
            char chrChoice;

            FrenchMenu frenchMenu = new FrenchMenu();
            EnglishMenu englishMenu = new EnglishMenu();

            Console.Write("\n\n\tPlease select a language (français/English) <f/e> : ");
            chrLanguage = Console.ReadKey(true).KeyChar;

            Console.Clear();


            do
            {
                Console.WriteLine(strTitle + "\n");
                if (frenchMenu.changeLanguage)
                {
                    chrLanguage = 'e';
                    frenchMenu.changeLanguage = false;
                }
                if (englishMenu.changeLanguage)
                {
                    {
                        chrLanguage = 'f';
                        frenchMenu.changeLanguage = false;
                    }
                }

                if (chrLanguage == 'f' || chrLanguage == 'F')
                {
                    frenchMenu.ShowMenu();

                    chrChoice = Console.ReadKey(true).KeyChar;

                    if (chrChoice == '2')
                    {
                        frenchMenu.OptionMenu();
                    }
                    else if (chrChoice == '5')
                        ExitGame();

                }
                else
                {
                    englishMenu.ShowMenu();

                    chrChoice = Console.ReadKey(true).KeyChar;

                    if (chrChoice == '2')
                    {
                        englishMenu.OptionMenu();
                    }
                    else if (chrChoice == '5')
                        ExitGame();
                }

                Console.Clear();
            }
            while (chrChoice != '1');




            Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);

            player player = new player();

            player.show();

            Console.ReadLine();
        }

        static void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
