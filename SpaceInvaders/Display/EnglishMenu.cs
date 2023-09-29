using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EnglishMenu
    {
        private string[] Action =
        {
            "1. Start",
            "2. Option",
            "3. HighScores",
            "4. lockerrom",
            "5. Leave"
        };

        private string[] tab_optionTitle =
        {
            "   ____        _   _             \r\n",
            "  / __ \\      | | (_)            \r\n",
            " | |  | |_ __ | |_ _  ___  _ __  \r\n",
            " | |  | | '_ \\| __| |/ _ \\| '_ \\ \r\n",
            " | |__| | |_) | |_| | (_) | | | |\r\n",
            "  \\____/| .__/ \\__|_|\\___/|_| |_|\r\n",
            "        | |                      \r\n",
            "      |_|                      "
        };

        private string[] tab_LostTitle =
        {
            " __     __           _                    \r\n",
            " \\ \\   / /          | |                   \r\n",
            "  \\ \\_/ /__  _   _  | |     ___  ___  ___ \r\n",
            "   \\   / _ \\| | | | | |    / _ \\/ __|/ _ \\\r\n",
            "    | | (_) | |_| | | |___| (_) \\__ \\  __/\r\n",
            "    |_|\\___/ \\__,_| |______\\___/|___/\\___|\r\n",
            "                                          \r\n",
            "                                          "
        };

        private string[] tab_WinTitle =
        {
            " __     __          __          ___       \r\n",
            " \\ \\   / /          \\ \\        / (_)      \r\n",
            "  \\ \\_/ /__  _   _   \\ \\  /\\  / / _ _ __  \r\n",
            "   \\   / _ \\| | | |   \\ \\/  \\/ / | | '_ \\ \r\n",
            "    | | (_) | |_| |    \\  /\\  /  | | | | |\r\n",
            "    |_|\\___/ \\__,_|     \\/  \\/   |_|_| |_|\r\n",
            "                                          \r\n",
            "                                          "
        };

        public bool changeLanguage = false;
        private char chrLanguage;

        public void ShowMenu()
        {
            for (int i = 0; i < Action.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - Action[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(Action[i]);
            }
        }

        public void OptionMenu()
        {
            Console.Clear();
            for (int i = 0; i < tab_optionTitle.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - tab_optionTitle[i].Length) / 2, Console.CursorTop);
                Console.Write(tab_optionTitle[i]);
            }

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
            for (int i = 0; i < tab_LostTitle.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - tab_LostTitle[i].Length) / 2, Console.CursorTop);
                Console.Write(tab_LostTitle[i]);
            }

            Console.WriteLine("\tPress a key to return to the main menu :\n");
        }

        public void WinMenu()
        {
            Console.Clear();
            for (int i = 0; i < tab_WinTitle.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - tab_WinTitle[i].Length) / 2, Console.CursorTop);
                Console.Write(tab_WinTitle[i]);
            }

            Console.WriteLine("\tPress a key to return to the main menu :\n");
        }
    }
}
