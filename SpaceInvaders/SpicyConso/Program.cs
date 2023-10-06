using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Drawing;
using Model;
using Display;
using Storage;
using System.Media;
using System.Diagnostics;

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

            

            char chrLanguage;
            char chrChoice;

            string pseudo;

            int yPosStart = 5;
            int intTempEnemyNb;
            int frameNumber = 0;

            bool firstLoop = true;
            bool samePosition = false;
            bool winGame = false;

            const int MODEL_WIDTH = Model.Config.SCREEN_WIDTH;

            ConsoleKeyInfo keypPressed;

            List<Ammo> ammoList = new List<Ammo>();
            List<Ennemy> ennemyList = new List<Ennemy>();

            FrenchMenu frenchMenu = new FrenchMenu();
            EnglishMenu englishMenu = new EnglishMenu();
            Store store = new Store();

            PlayGround.Init();

            chrLanguage = PlayGround.ChoseLanguage();
            pseudo = PlayGround.ChosePlayerName(chrLanguage);

            if (string.IsNullOrEmpty(pseudo))
            {
                pseudo = "player";
            }

            if (chrLanguage != 'f' || chrLanguage != 'F' || chrLanguage != 'e' || chrLanguage != 'E')
                chrLanguage = 'f';

            Debug.Write(pseudo);

            Console.Clear();

            Player player = new Player(5, 5, ConsoleColor.DarkGreen, pseudo);

            Console.Clear();

            do
            {
                PlayGround.lobbySong.PlayLooping();

                for (int i = 0; i < 10; i++)
                {
                    ennemyList.Add(new Ennemy(yPosStart, 5, ConsoleColor.Cyan));
                    yPosStart += 5;
                }

                if (winGame)
                {
                    foreach (Ennemy enn in ennemyList)
                    {
                        if (enn.Speed >= 0)
                        {
                            enn.Speed -= 5;
                        }
                        enn.IncrementX += 2;
                    }
                    winGame = false;
                }
                else
                {
                    foreach (Ennemy enn in ennemyList)
                    {
                        enn.Speed = 10;
                    }
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
                    else if (englishMenu.changeLanguage)
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

                PlayGround.firstPartSong.PlayLooping();

                do
                {

                    PlayGround.ShowPlayerScore(player);
                    PlayGround.ShowAmmoCount(chrLanguage, player);

                    if (ennemyList.Count <= intTempEnemyNb / 2)
                    {
                        if (firstLoop)
                        {
                            PlayGround.secondPartSong.PlayLooping();
                            firstLoop = false;
                        }
                    }

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

                    if (ammoList.Count > 0)
                    {
                        for (int i = ammoList.Count() - 1; i >= 0; i--)
                        {
                            if (ammoList.ElementAt(i).YPos >= 2)
                            {
                                PlayGround.ShowAmmo(ammoList.ElementAt(i));
                                if (frameNumber % ammoList.ElementAt(i).Speed == 0)
                                {
                                    ammoList.ElementAt(i).Update();
                                }
                            }
                            else
                            {
                                ammoList.Remove(ammoList.ElementAt(i));
                                player.CompteurAmmo--;
                            }
                        }
                    }

                    PlayGround.ShowPlayer(player);

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
                            if (frameNumber % enneUpdate.Speed == 0)
                            {
                                enneUpdate.UpdateEnnemyX();
                            }
                        }
                    }


                    frameNumber++;
                    Thread.Sleep(1);
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
                    PlayGround.looseSong.Play();
                    if (chrLanguage == 'e' || chrLanguage == 'E')
                    {
                        englishMenu.LoseMenu();
                    }
                    else
                    {
                        frenchMenu.LoseMenu();
                    }

                    player.CompteurAmmo = 50;
                    player.Score = 0;

                }

                else
                {
                    PlayGround.winSong.Play();

                    if (chrLanguage == 'e' || chrLanguage == 'E')
                    {
                        englishMenu.WinMenu();
                    }
                    else
                    {
                        frenchMenu.WinMenu();
                    }

                    winGame = true;       
                }

                ResetValue(player, ref yPosStart, ennemyList, ammoList, ref firstLoop);

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

        static void ResetValue(Player _player, ref int _yPosStart, List<Ennemy> _ennemyList, List<Ammo> _ammoList, ref bool _firstLoop)
        {
            _player.XPos = 5;
            _yPosStart = 5;
            _ennemyList.Clear();
            _ammoList.Clear();
            _firstLoop = true;
        }
    }
}