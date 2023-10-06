using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Drawing;
using Model;
using Display;
using Storage;
using System.Media;

namespace SpicyConso
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] strTitle =
            {
                "   _____                        _____                     _               \r\n",
                "  / ____|                      |_   _|                   | |              \r\n",
                " | (___  _ __   __ _  ___ ___    | |  _ ____   ____ _  __| | ___ _ __ ___ \r\n",
                "  \\___ \\| '_ \\ / _` |/ __/ _ \\   | | | '_ \\ \\ / / _` |/ _` |/ _ \\ '__/ __|\r\n",
                "  ____) | |_) | (_| | (_|  __/  _| |_| | | \\ V / (_| | (_| |  __/ |  \\__ \\\r\n",
                " |_____/| .__/ \\__,_|\\___\\___| |_____|_| |_|\\_/ \\__,_|\\__,_|\\___|_|  |___/\r\n",
                "        | |                                                               \r\n",
                "      |_|                                                               "
            };

            const string CHOSE_DEFAULT_LANGUAGE = "Please select a language (Français/English) <f/e> : ";

            char chrLanguage;
            char chrChoice;

            string pseudo = "player1";

            int yPosStart = 5;
            int intTempEnemyNb;

            bool firstLoop = true;
            bool samePosition = false;
            bool winGame = false;

            const int MODEL_WIDTH = Model.Config.SCREEN_WIDTH;
            const int MODEL_HEIGHT = Model.Config.SCREEN_HEIGHT;

            SoundPlayer lobbySong = new SoundPlayer(@"LobbySong.wav");
            SoundPlayer FirstPartSong = new SoundPlayer(@"FirstPartFight.wav");
            SoundPlayer SecondPartSong = new SoundPlayer(@"SecondPartFight.wav");
            SoundPlayer WinSong = new SoundPlayer(@"WinSong.wav");
            SoundPlayer LooseSong = new SoundPlayer(@"LooseSong.wav");

            ConsoleKeyInfo keypPressed;

            List<Ammo> ammoList = new List<Ammo>();
            List<Ennemy> ennemyList = new List<Ennemy>();

            FrenchMenu frenchMenu = new FrenchMenu();
            EnglishMenu englishMenu = new EnglishMenu();
            Store store = new Store();
            Player player = new Player(5, 5, ConsoleColor.DarkGreen, pseudo);

            PlayGround.Init();

            Console.SetCursorPosition((MODEL_WIDTH - CHOSE_DEFAULT_LANGUAGE.Length) / 2, MODEL_HEIGHT / 2 - 1);
            Console.Write(CHOSE_DEFAULT_LANGUAGE);
            chrLanguage = Console.ReadKey(true).KeyChar;

            Console.Clear();

            do
            {
                lobbySong.PlayLooping();

                for (int i = 0; i < 10; i++)
                {
                    ennemyList.Add(new Ennemy(yPosStart, 5, ConsoleColor.Cyan));
                    yPosStart += 5;
                }
                if (winGame)
                {
                    foreach (Ennemy enn in ennemyList)
                    {
                        enn.Speed++;
                    }
                    winGame = false;
                }

                intTempEnemyNb = ennemyList.Count();

                Console.ForegroundColor = ConsoleColor.White;
                do
                {

                    for (int i = 0; i < strTitle.Length; i++)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - strTitle[i].Length) / 2, Console.CursorTop);
                        Console.Write(strTitle[i]);
                    }

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
                        else if (chrChoice == '3')
                        {
                            frenchMenu.HighScore(store);
                        }
                    }
                    else
                    {
                        englishMenu.ShowMenu();

                        chrChoice = Console.ReadKey(true).KeyChar;

                        if (chrChoice == '2')
                        {
                            englishMenu.OptionMenu();

                        }
                        else if (chrChoice == '3')
                            break;
                    }

                    if (chrChoice == '5')
                        ExitGame();

                    Console.Clear();
                }
                while (chrChoice != '1');

                lobbySong.Stop();

                FirstPartSong.PlayLooping();

                do
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"Score : {player.Score}");

                    Console.SetCursorPosition(0, 1);
                    if (chrLanguage == 'f' || chrLanguage == 'F')
                        Console.WriteLine($"Munition : {player.CompteurAmmo}");
                    else
                        Console.WriteLine($"Ammo : {player.CompteurAmmo}");

                    if (ennemyList.Count <= intTempEnemyNb / 2)
                    {
                        if (firstLoop)
                        {
                            SecondPartSong.PlayLooping();
                            firstLoop = false;
                        }
                    }

                    for (int i = ammoList.Count() - 1; i > 0; i--)
                    {
                        if (ammoList.ElementAt(i).YPos >= 2)
                        {
                            PlayGround.ShowAmmo(ammoList.ElementAt(i));
                            ammoList.ElementAt(i).Update();
                        }
                        else
                        {
                            ammoList.Remove(ammoList.ElementAt(i));
                            player.CompteurAmmo--;
                        }
                    }

                    PlayGround.ShowPlayer(player);

                    if (Console.KeyAvailable)
                    {
                        keypPressed = Console.ReadKey(true);

                        switch (keypPressed.Key)
                        {
                            case ConsoleKey.Spacebar:
                                if (player.CompteurAmmo > 0)
                                {
                                    ammoList.Add(new Ammo(player.XPos, player.YPos, ConsoleColor.Blue));
                                    
                                }
                                break;
                            case ConsoleKey.D:
                                player.UpdateXRight();
                                break;
                            case ConsoleKey.A:
                                player.UpdateXLeft();
                                break;
                        }
                    }

                    foreach (Ennemy enneShow in ennemyList)
                    {
                        PlayGround.ShowEnnemy(enneShow);
                    }

                    if ((ennemyList.Last().XPos >= MODEL_WIDTH - 10 && !ennemyList.Last().GoingLeft) || (ennemyList.First().XPos <= 5 && ennemyList.First().GoingLeft))
                    {
                        foreach (Ennemy enneUpdate in ennemyList)
                        {
                            enneUpdate.UpdateEnnemyY();
                            if (ennemyList.First().XPos <= 5)
                            {
                                enneUpdate.GoingLeft = false;
                            }
                            else if (ennemyList.Last().XPos >= MODEL_WIDTH - 10)
                            {
                                enneUpdate.GoingLeft = true;
                            }
                        }
                    }

                    else
                    {
                        foreach (Ennemy enneUpdate in ennemyList)
                        {
                            enneUpdate.UpdateEnnemyX();
                        }
                    }

                    Thread.Sleep(50);
                    Console.Clear();


                    if (ammoList.Count() > 0 && ennemyList.Count() > 0)
                    {
                        ammoList.First().KillsEnnemy(ennemyList, ammoList, player);
                    }


                    for (int i = 0; i < ennemyList.Count(); i++)
                    {
                        samePosition = CheckPosition(player, ennemyList);
                    }

                }
                while (!samePosition && ennemyList.Count() > 0 && player.CompteurAmmo > 0);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                if (samePosition || player.CompteurAmmo <= 0)
                {
                    LooseSong.Play();
                    if (chrLanguage == 'e' || chrLanguage == 'E')
                    {
                        englishMenu.LoseMenu();
                    }
                    else if (chrLanguage == 'f' || chrLanguage == 'f')
                    {
                        frenchMenu.LoseMenu();
                    }

                    player.CompteurAmmo = 50;
                    player.Score = 0;
                }

                else
                {
                    WinSong.Play();
                    if (chrLanguage == 'e' || chrLanguage == 'E')
                    {
                        englishMenu.WinMenu();
                    }
                    else if (chrLanguage == 'f' || chrLanguage == 'f')
                    {
                        frenchMenu.WinMenu();
                    }
                    winGame = true;       
                }

                player.XPos = 5;
                yPosStart = 5;
                ennemyList.Clear();
                ammoList.Clear();
                firstLoop = true;

                Thread.Sleep(3000);
                Console.ReadKey();
                Console.Clear();
                
            }
            while (true);
        }

        static void ExitGame()
        {
            Environment.Exit(0);
        }

        static bool CheckPosition(Player player, List<Ennemy> ennList)
        {
            if (ennList != null)
            {
                if (player.YPos == ennList.First().YPos)
                {
                    return true;
                }
            }
            return false;
        }
    }
}