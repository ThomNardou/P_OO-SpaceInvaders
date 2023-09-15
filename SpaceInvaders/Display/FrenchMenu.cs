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
            "\t\t\t\t1.\tJouer",
            "\t\t\t\t2.\tOption",
            "\t\t\t\t3.\tRecords",
            "\t\t\t\t4.\tVestiaire",
            "\t\t\t\t5.\tQuitter"
        };

        private string TitleOption = "   ____        _   _             \r\n  / __ \\      | | (_)            \r\n | |  | |_ __ | |_ _  ___  _ __  \r\n | |  | | '_ \\| __| |/ _ \\| '_ \\ \r\n | |__| | |_) | |_| | (_) | | | |\r\n  \\____/| .__/ \\__|_|\\___/|_| |_|\r\n        | |                      \r\n        |_|                      ";

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
            Console.WriteLine(TitleOption + "\n");

            Console.WriteLine("\tmodifier la langue :\n");
            Console.WriteLine("\t\t1. Français");
            Console.WriteLine("\t\t2. English\n");
            Console.WriteLine("\t\t3. Retour");

           chrLanguage = Console.ReadKey(true).KeyChar;

            if (chrLanguage == '2')
                changeLanguage = true;

        }
    }
}
