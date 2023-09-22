using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EnglishMenu
    {
        private string[] option =
        {
            "\t\t\t\t1.\tStart",
            "\t\t\t\t2.\tOption",
            "\t\t\t\t3.\tHighScores",
            "\t\t\t\t4.\tlockerrom",
            "\t\t\t\t5.\tLeave"
        };

        private string Title = "   ____        _   _             \r\n  / __ \\      | | (_)            \r\n | |  | |_ __ | |_ _  ___  _ __  \r\n | |  | | '_ \\| __| |/ _ \\| '_ \\ \r\n | |__| | |_) | |_| | (_) | | | |\r\n  \\____/| .__/ \\__|_|\\___/|_| |_|\r\n        | |                      \r\n        |_|                      ";
        private string LostTitle = " __     __           _                    \r\n \\ \\   / /          | |                   \r\n  \\ \\_/ /__  _   _  | |     ___  ___  ___ \r\n   \\   / _ \\| | | | | |    / _ \\/ __|/ _ \\\r\n    | | (_) | |_| | | |___| (_) \\__ \\  __/\r\n    |_|\\___/ \\__,_| |______\\___/|___/\\___|\r\n                                          \r\n                                          ";
        private string WinTitle = " __     __          __          ___       \r\n \\ \\   / /          \\ \\        / (_)      \r\n  \\ \\_/ /__  _   _   \\ \\  /\\  / / _ _ __  \r\n   \\   / _ \\| | | |   \\ \\/  \\/ / | | '_ \\ \r\n    | | (_) | |_| |    \\  /\\  /  | | | | |\r\n    |_|\\___/ \\__,_|     \\/  \\/   |_|_| |_|\r\n                                          \r\n                                          ";

        public bool changeLanguage = false;
        private char chrLanguage;

        public void ShowMenu()
        {
            for (int i = 0; i < option.Length; i++)
            {
                Console.WriteLine(option[i]);
            }
        }

        public void OptionMenu()
        {
            Console.Clear();
            Console.WriteLine(Title + "\n");

            Console.WriteLine("\tEdit the language :\n");
            Console.WriteLine("\t\t1. Français");
            Console.WriteLine("\t\t2. English\n");
            Console.WriteLine("\t\t3. back");

            chrLanguage = Console.ReadKey(true).KeyChar;

            if (chrLanguage == '1')
                changeLanguage = true;
        }

        public void LoseMenu()
        {
            Console.Clear();
            Console.WriteLine(LostTitle + "\n");

            Console.WriteLine("\tPress a key to return to the main menu :\n");
        }

        public void WinMenu()
        {
            Console.Clear();
            Console.WriteLine(WinTitle + "\n");

            Console.WriteLine("\tPress a key to return to the main menu :\n");
        }
    }
}
