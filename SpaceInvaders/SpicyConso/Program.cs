using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

            bool isEmpty = false;

            const int MODEL_HEIGHT = Model.Config.SCREEN_HEIGHT;
            const int MODEL_WIDTH = Model.Config.SCREEN_WIDTH;

            ConsoleKeyInfo keypPressed;

            List<Ammo> ammoList = new List<Ammo>();
            List<Ennemy> ennemyList = new List<Ennemy>();

            FrenchMenu frenchMenu = new FrenchMenu();
            EnglishMenu englishMenu = new EnglishMenu();

            Player player = new Player(5, 5, ConsoleColor.DarkGreen);
            Ennemy ennemy1 = new Ennemy(5, 5, ConsoleColor.Red);
            Ennemy ennemy2 = new Ennemy(10, 5, ConsoleColor.Cyan);
            Ennemy ennemy3 = new Ennemy(15, 5, ConsoleColor.Green);
            Ennemy ennemy4 = new Ennemy(20, 5, ConsoleColor.Gray);
            Ennemy ennemy5 = new Ennemy(25, 5, ConsoleColor.Yellow);
            Ennemy ennemy6 = new Ennemy(30, 5, ConsoleColor.DarkRed);
            Ennemy ennemy7 = new Ennemy(35, 5, ConsoleColor.DarkCyan);
            Ennemy ennemy8 = new Ennemy(40, 5, ConsoleColor.DarkGreen);
            Ennemy ennemy9 = new Ennemy(45, 5, ConsoleColor.DarkGray);
            Ennemy ennemy10 = new Ennemy(50, 5, ConsoleColor.DarkYellow);

            addEnnemy(ennemyList, ennemy1);
            addEnnemy(ennemyList, ennemy2);
            addEnnemy(ennemyList, ennemy3);
            addEnnemy(ennemyList, ennemy4);
            addEnnemy(ennemyList, ennemy5);
            addEnnemy(ennemyList, ennemy6);
            addEnnemy(ennemyList, ennemy7);
            addEnnemy(ennemyList, ennemy8);
            addEnnemy(ennemyList, ennemy9);
            addEnnemy(ennemyList, ennemy10);

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\n\n\tPlease select a language (français/English) <f/e> : ");
            chrLanguage = Console.ReadKey(true).KeyChar;

            Console.Clear();

            Console.CursorVisible = false;

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

            }
            while (ennemyList.First().yPos < player.yPos || ennemyList.Count() > 0);

        }

        static void ExitGame()
        {
            Environment.Exit(0);
        }

        static void addEnnemy(List<Ennemy> ennList, Ennemy _ennemy)
        {
            ennList.Add(_ennemy);
        }
    }
}
