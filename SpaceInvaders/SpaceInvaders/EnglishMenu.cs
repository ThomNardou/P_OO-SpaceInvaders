using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class EnglishMenu
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

            Console.WriteLine("\t\t\t\t1.\tFrançais");
            Console.WriteLine("\t\t\t\t2.\tEnglish\n");
            Console.WriteLine("\t\t\t\t3.\tback");

            chrLanguage = Console.ReadKey(true).KeyChar;

            if (chrLanguage == '1')
                changeLanguage = true;
        }
    }
}
