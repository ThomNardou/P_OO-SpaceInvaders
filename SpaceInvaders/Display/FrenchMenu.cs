using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FrenchMenu
    {
        private string[] option =
        {
            "1.\tJouer",
            "2.\tOption",
            "3.\tRecords",
            "4.\tVestiaire",
            "5.\tQuitter"
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
            for (int i = 0; i < tab_optionTitle.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - tab_optionTitle[i].Length) / 2, Console.CursorTop);
                Console.Write(tab_optionTitle[i]);
            }

            Console.WriteLine("\tmodifier la langue :\n");
            Console.WriteLine("\t\t1. Français");
            Console.WriteLine("\t\t2. English\n");
            Console.WriteLine("\t\t3. Retour");

           chrLanguage = Console.ReadKey(true).KeyChar;

            if (chrLanguage == '2')
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

            Console.WriteLine("\tAppyer sur une touche pour retourner au menu principal :\n");
        }

        public void WinMenu()
        {
            Console.Clear();
            for (int i = 0; i < tab_WinTitle.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - tab_WinTitle[i].Length) / 2, Console.CursorTop);
                Console.Write(tab_WinTitle[i]);
            }

            Console.WriteLine("\tAppyer sur une touche pour retourner au menu principal :\n");
        }
    }
}
