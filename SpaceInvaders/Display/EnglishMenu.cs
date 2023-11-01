using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display
{
    public class EnglishMenu
    {


        // Déclaration des Titre
        private string[] optionChoseLobby =
        {
            "1. Start",
            "2. Option",
            "3. HighScores",
            "4. lockerrom",
            "5. Leave"
        };
        private string[] optionChose =
        {
             "Edit the language :",
             "\t1. Français",
             "\t2. English",
             "\t3. back",
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
        private string[] tab_HighScoreTitle =
        {
            @"  _    _ _       _      _____                    ",
            @" | |  | (_)     | |    / ____|                   ",
            @" | |__| |_  __ _| |__ | (___   ___ ___  _ __ ___ ",
            @" |  __  | |/ _` | '_ \ \___ \ / __/ _ \| '__/ _ \",
            @" | |  | | | (_| | | | |____) | (_| (_) | | |  __/",
            @" |_|  |_|_|\__, |_| |_|_____/ \___\___/|_|  \___|",
            @"            __/ |                                ",
            @"           |___/                                 "
        };

        // Déclaration des constantes 
        private const string GO_BACK_LOBBY_MESSAGE = "Press a key to return to the main menu :";

        // Déclaration des attributs
        public bool changeLanguage = false;
        private char chrLanguage;

        /// <summary>
        /// Afficher le menu principal 
        /// </summary>
        public void ShowMenu()
        {
            for (int i = 0; i < optionChoseLobby.Length; i++)
            {
                Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - 8, 10 + i);
                Console.WriteLine(optionChoseLobby[i]);
            }
        }

        /// <summary>
        /// Afficher la page des options 
        /// </summary>
        public void OptionMenu()
        {
            Console.Clear();
            for (int i = 0; i < tab_optionTitle.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - tab_optionTitle[i].Length) / 2, Console.CursorTop);
                Console.Write(tab_optionTitle[i]);
            }

            for (int i = 0; i < optionChose.Length; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - 8, 10 + i);
                }
                else
                {
                    Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - 8, 10 + i + 1);
                }

                Console.WriteLine(optionChose[i]);
            }

            chrLanguage = Console.ReadKey(true).KeyChar;

            if (chrLanguage == '1')
                changeLanguage = true;
        }

        /// <summary>
        /// Affiche la page de défaite
        /// </summary>
        public void LoseMenu()
        {
            Console.Clear();
            for (int i = 0; i < tab_LostTitle.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - tab_LostTitle[i].Length) / 2, Console.CursorTop);
                Console.Write(tab_LostTitle[i]);
            }

            Console.SetCursorPosition((Config.SCREEN_WIDTH - GO_BACK_LOBBY_MESSAGE.Length) / 2, 10);
            Console.WriteLine(GO_BACK_LOBBY_MESSAGE);
        }

        /// <summary>
        /// Affiche la page de victoire
        /// </summary>
        public void WinMenu()
        {
            Console.Clear();
            for (int i = 0; i < tab_WinTitle.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - tab_WinTitle[i].Length) / 2, Console.CursorTop);
                Console.Write(tab_WinTitle[i]);
            }

            Console.SetCursorPosition((Config.SCREEN_WIDTH - GO_BACK_LOBBY_MESSAGE.Length) / 2, 10);
            Console.WriteLine(GO_BACK_LOBBY_MESSAGE);
        }

        /// <summary>
        /// Affiche la page des records
        /// </summary>
        /// <param name="storeage"></param>
        public void HighScore(Store storeage)
        {

            Console.Clear();

            for (int i = 0; i < tab_HighScoreTitle.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - tab_HighScoreTitle[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(tab_HighScoreTitle[i]);
            }

            storeage.SaveSelect();
            for (int i = 0; i < storeage.Record.Count; ++i)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 10 + i);
                Console.WriteLine(storeage.Record.ElementAt(i));
            }
            storeage.ClosConnection();

            Console.ReadKey();
        }
    }
}
