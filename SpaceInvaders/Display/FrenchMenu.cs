﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage;

namespace Display
{
    public class FrenchMenu
    {
        // Déclaration des titres
        private string[] optionChoseLobby =
        {
            "1. Jouer",
            "2. Option",
            "3. Records",
            "4. Vestiaire",
            "5. Quitter"
        };
        private string[] optionChose =
        {
             "modifier la langue :",
             "1. Français",
             "2. English",
             "3. Retour",
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
            "  _______                                     _       \r\n",
            " |__   __|                                   | |      \r\n",
            "    | |_   _    __ _ ___   _ __   ___ _ __ __| |_   _ \r\n",
            "    | | | | |  / _` / __| | '_ \\ / _ \\ '__/ _` | | | |\r\n",
            "    | | |_| | | (_| \\__ \\ | |_) |  __/ | | (_| | |_| |\r\n",
            "    |_|\\__,_|  \\__,_|___/ | .__/ \\___|_|  \\__,_|\\__,_|\r\n",
            "                          | |                         \r\n",
            "                        |_|                         "
        };
        private string[] tab_WinTitle =
        {
            "  _______                                            __ \r\n",
            " |__   __|                                          /_/ \r\n",
            "    | |_   _    __ _ ___    __ _  __ _  __ _ _ __   ___ \r\n",
            "    | | | | |  / _` / __|  / _` |/ _` |/ _` | '_ \\ / _ \\\r\n",
            "    | | |_| | | (_| \\__ \\ | (_| | (_| | (_| | | | |  __/\r\n",
            "    |_|\\__,_|  \\__,_|___/  \\__, |\\__,_|\\__, |_| |_|\\___|\r\n",
            "                            __/ |       __/ |           \r\n",
            "                           |___/       |___/            "
        };
        private string[] tab_HighScoreTitle =
        {
            @"  _____                        _ ",
            @" |  __ \                      | |",
            @" | |__) |___  ___ ___  _ __ __| |",
            @" |  _  // _ \/ __/ _ \| '__/ _` |",
            @" | | \ \  __/ (_| (_) | | | (_| |",
            @" |_|  \_\___|\___\___/|_|  \__,_|",
            @"                                 ",
            @"                                 "
        };

        // Déclaration des constante 
        private const string GO_BACK_LOBBY_MESSAGE = "Appyer sur une touche pour retourner au menu principal :";

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

            if (chrLanguage == '2')
                changeLanguage = true;

        }

        /// <summary>
        /// Afficher la page de défaite
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
        /// Afficher la page de victoire
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
        /// Afficher la page des records
        /// </summary>
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
            storeage.Record.Clear();
            storeage.Compteur = 0;

            Console.ReadKey();
        }
    }
}
