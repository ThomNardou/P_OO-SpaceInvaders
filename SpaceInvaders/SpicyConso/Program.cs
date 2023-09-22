using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Drawing;
using Model;
using Display;


namespace SpicyConso
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string strTitle = "   _____                        _____                     _               \r\n  / ____|                      |_   _|                   | |              \r\n | (___  _ __   __ _  ___ ___    | |  _ ____   ____ _  __| | ___ _ __ ___ \r\n  \\___ \\| '_ \\ / _` |/ __/ _ \\   | | | '_ \\ \\ / / _` |/ _` |/ _ \\ '__/ __|\r\n  ____) | |_) | (_| | (_|  __/  _| |_| | | \\ V / (_| | (_| |  __/ |  \\__ \\\r\n |_____/| .__/ \\__,_|\\___\\___| |_____|_| |_|\\_/ \\__,_|\\__,_|\\___|_|  |___/\r\n        | |                                                               \r\n        |_|                                                               ";

            char chrLanguage;
            char chrChoice;

            int Compteur = 5;

            bool samePosition = false;

            Random random = new Random();

            const int MODEL_HEIGHT = Model.Config.SCREEN_HEIGHT;
            const int MODEL_WIDTH = Model.Config.SCREEN_WIDTH;

            ConsoleKeyInfo keypPressed;

            List<Ammo> ammoList = new List<Ammo>();
            List<Ennemy> ennemyList = new List<Ennemy>();

            FrenchMenu frenchMenu = new FrenchMenu();
            EnglishMenu englishMenu = new EnglishMenu();

            Player player = new Player(5, 5, ConsoleColor.DarkGreen);

            for (int i = 0; i < 10; i++)
            {
                ennemyList.Add(new Ennemy(Compteur, 5, ConsoleColor.Cyan));
                Compteur += 5;
            }

            Console.ForegroundColor = ConsoleColor.White;

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
                    chrLanguage = 'f';
                    englishMenu.changeLanguage = false;
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

            PlayGround.Init();

            do
            {

                for (int i = ammoList.Count() - 1; i > 0; i--)
                {
                    if (ammoList.ElementAt(i).yPos >= 2)
                    {
                        PlayGround.ShowAmmo(ammoList.ElementAt(i));
                        ammoList.ElementAt(i).Update();
                    }
                    else
                    {
                        ammoList.Remove(ammoList.ElementAt(i));
                    }
                }

                PlayGround.showPlayer(player);

                if (Console.KeyAvailable)
                {
                    keypPressed = Console.ReadKey(true);

                    switch (keypPressed.Key)
                    {
                        case ConsoleKey.Spacebar:
                            ammoList.Add(new Ammo(player.xPos, player.yPos, ConsoleColor.Blue));
                            break;
                        case ConsoleKey.D:
                            player.updateXRight();
                            break;
                        case ConsoleKey.A:
                            player.updateXLeft();
                            break;
                    }
                }


                foreach (Ennemy enneShow in ennemyList)
                {
                    PlayGround.showEnnemy(enneShow);
                }

                if ((ennemyList.Last().xPos >= MODEL_WIDTH - 10 && !ennemyList.Last().goingLeft) || (ennemyList.First().xPos <= 5 && ennemyList.First().goingLeft))
                {
                    foreach (Ennemy enneUpdate in ennemyList)
                    {
                        enneUpdate.updateEnnemyY();
                        if (ennemyList.First().xPos <= 5)
                        {
                            enneUpdate.goingLeft = false;
                        }
                        else if (ennemyList.Last().xPos >= MODEL_WIDTH - 10)
                        {
                            enneUpdate.goingLeft = true;
                        }
                    }
                }

                else
                {
                    foreach (Ennemy enneUpdate in ennemyList)
                    {
                        enneUpdate.updateEnnemyX();
                    }
                }


                Thread.Sleep(50);
                Console.Clear();

                if (ammoList.Count() > 0 && ennemyList.Count() > 0)
                {
                    ammoList.First().killsEnnemy(ennemyList, ammoList);
                }

                
                for (int i = 0; i < ennemyList.Count(); i++)
                {
                    samePosition = checkPosition(player, ennemyList);
                }

            }
            while (!samePosition && ennemyList.Count() > 0);

            Console.Clear();
            Console.WriteLine("all anemies are killed");
            Console.ReadLine();

        }

        static void ExitGame()
        {
            Environment.Exit(0);
        }

        static bool checkPosition(Player player, List<Ennemy> ennList)
        {
            if (ennList != null)
            {
                if (player.yPos == ennList.First().yPos)
                {
                    return true;
                        
                }
            }
            return false;
        }
    }
}
