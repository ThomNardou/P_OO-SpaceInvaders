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

            // Déclaration des variables : 

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

            int xPosStart = 5;
            int intTempEnemyNb;
            int frameNumber = 0;
            int speed = 10; 

            bool firstLoop = true;
            bool samePosition = false;
            bool winGame = false;
            bool lastAmmo = false;

            const int SCREEN_WIDTH = Model.Config.SCREEN_WIDTH;

            ConsoleKeyInfo keypPressed;

            // Déclaration des listes d'objet
            List<Ammo> ammoListOnPlay = new List<Ammo>();
            List<Ammo> ammoListOffPlay = new List<Ammo>();
            List<Ennemy> ennemyList = new List<Ennemy>();

            // Inctansiation des classes
            Store store = new Store();
            FrenchMenu frenchMenu = new FrenchMenu();
            EnglishMenu englishMenu = new EnglishMenu();
            Player player = new Player(5, 5, ConsoleColor.DarkGreen);

            // Inisialisation de l'air de jeu 
            PlayGround.Init();

            // Demande à l'utilisateur le language par défaut
            chrLanguage = PlayGround.ChoseDefaultLanguage();

            // Demande à l'utilisateur le le pseudo du joueur 
            player.Pseudo = PlayGround.ChosePlayerName(chrLanguage);

            Console.Clear();

            do
            {
                // Joue la musique de fond
                PlayGround.lobbySong.PlayLooping();

                // Boucle qui va instancier les 10 enemies 
                for (int i = 0; i < 10; i++)
                {
                    // ajoute dans la liste les enemies 
                    ennemyList.Add(new Ennemy(xPosStart, 5, ConsoleColor.Cyan));
                    xPosStart += 5;
                }

                for (int i = 0; i < player.CompteurAmmo; i++)
                {
                    ammoListOffPlay.Add(new Ammo(player.XPos, player.YPos, ConsoleColor.Blue));
                }

                // augmente la vitesse des ennemies
                if (winGame)
                {
                    if(speed > 1)
                        speed -= 1;

                    winGame = false;
                }
                // reset la vitesse des ennemies
                else
                {
                    speed = 10;
                }

                // Variable temporaire qui prend le nombre d'enemmies 
                intTempEnemyNb = ennemyList.Count();

                Console.ForegroundColor = ConsoleColor.White;
                do
                {
                    // Affiche le titre
                    for (int i = 0; i < strTitle.Length; i++)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - strTitle[i].Length) / 2, Console.CursorTop);
                        Console.Write(strTitle[i]);
                    }

                    // si l'utilisateur à changer de language
                    if (frenchMenu.changeLanguage)
                    {
                        // change la langue en Anglais
                        chrLanguage = 'e';
                        frenchMenu.changeLanguage = false;
                    }
                    else if (englishMenu.changeLanguage)
                    {
                        // change la langue en français
                        chrLanguage = 'f';
                        englishMenu.changeLanguage = false;
                    }

                    if (chrLanguage == 'f' || chrLanguage == 'F')
                    {
                        // affiche le menu français
                        frenchMenu.ShowMenu();

                        chrChoice = Console.ReadKey(true).KeyChar;

                        if (chrChoice == '2')
                        {
                            // affiche la page des option en française 
                            frenchMenu.OptionMenu();
                        }
                        else if (chrChoice == '3')
                        {
                            // affiche la page des records en française 
                            frenchMenu.HighScore(store);
                        }
                    }
                    else
                    {
                        // affiche le menu Anglais
                        englishMenu.ShowMenu();

                        chrChoice = Console.ReadKey(true).KeyChar;

                        if (chrChoice == '2')
                        {
                            // affiche la page des record en anglais
                            englishMenu.OptionMenu();
                        }
                        else if (chrChoice == '3')
                        {
                            // affiche la page des records en anglais 
                            englishMenu.HighScore(store);
                        }
                    }

                    // Ferme le jeu 
                    if (chrChoice == '5')
                        ExitGame();

                    Console.Clear();
                }
                while (chrChoice != '1');

                // Joue la musique de fond pour la première partie du jeu
                PlayGround.firstPartSong.PlayLooping();

                ///////////////////////////////////////////////////////// MOTEUR DE JEU /////////////////////////////////////////////////////////
                do
                {
                    // Affiche le score actuelle du joueur
                    PlayGround.ShowPlayerScore(player);

                    // Affiche le nombre de munition restante
                    PlayGround.ShowAmmoCount(chrLanguage, player);


                    if (ennemyList.Count <= intTempEnemyNb / 2)
                    {
                        if (firstLoop)
                        {
                            // Joue la musique pour la seconde partie du jeu
                            PlayGround.secondPartSong.PlayLooping();
                            firstLoop = false;
                        }
                    }

                    // Regarde si un joueur à appuyer sur une touche
                    if (Console.KeyAvailable)
                    {
                        keypPressed = Console.ReadKey(true);

                        switch (keypPressed.Key)
                        {
                            // Si le joueur à appuyer sur la bar d'espace 
                            case ConsoleKey.Spacebar:
                                if (player.CompteurAmmo > 0)
                                {
                                    if (ammoListOffPlay.Count > 0)
                                        ammoListOnPlay.Add(new Ammo(player.XPos, player.YPos, ConsoleColor.Magenta));

                                    ammoListOffPlay.RemoveAt(0);

                                    // décrémente le nombre de munition par un 
                                    player.CompteurAmmo--;
                                }
                                else
                                    lastAmmo = true;
                                break;

                            // si le joueur à appuyer sur D
                            case ConsoleKey.D:
                                // déplace le joueur vers la droite
                                player.UpdateXRight();
                                break;

                            // si le joueur à appuyer sur A
                            case ConsoleKey.A:
                                // déplace le joueur vers la gauche
                                player.UpdateXLeft();
                                break;
                        }
                    }

                    for (int i = ammoListOnPlay.Count() - 1; i >= 0; i--)
                    {
                        if (ammoListOnPlay.ElementAt(i).YPos >= 2)
                        {
                            // Affiche la munition
                            PlayGround.ShowAmmo(ammoListOnPlay.ElementAt(i));

                            // gère la vitesse des munition par rapport au nombre de frame
                            if (frameNumber % ammoListOnPlay.ElementAt(i).Speed == 0)
                            {
                                ammoListOnPlay.ElementAt(i).UpdateAmmoY();
                            }
                        }
                        else
                        {
                            // supprime la munition
                            ammoListOnPlay.Remove(ammoListOnPlay.ElementAt(i));
                        }
                    }

                    // affiche le joueur 
                    PlayGround.ShowPlayer(player);

                    // affiche tout les enemmie de la liste 
                    foreach (Ennemy enneShow in ennemyList)
                    {
                        PlayGround.ShowEnnemy(enneShow);
                    }

                    if ((ennemyList.Last().XPos >= SCREEN_WIDTH - 10 && !ennemyList.Last().GoingLeft) || (ennemyList.First().XPos <= 5 && ennemyList.First().GoingLeft))
                    {
                        foreach (Ennemy enneUpdate in ennemyList)
                        {
                            // fais descendre l'enemmie
                            enneUpdate.UpdateEnnemyY();
                            if (ennemyList.First().XPos <= 5)
                            {
                                // met à jour si l'ennemie doit aller à gauche ou pas
                                enneUpdate.GoingLeft = false;
                            }
                            else if (ennemyList.Last().XPos >= SCREEN_WIDTH - 10)
                            {
                                // met à jour si l'ennemie doit aller à gauche ou pas
                                enneUpdate.GoingLeft = true;
                            }
                        }
                    }

                    else
                    {
                        // Déplace tous les enemmies sur l'axe x
                        foreach (Ennemy enneUpdate in ennemyList)
                        {
                            //  Gère la vitesse des enemmies 
                            if (frameNumber % speed == 0)
                            {
                                enneUpdate.UpdateEnnemyX();
                            }
                        }
                    }

                    // agmente le nombre de frame
                    frameNumber++;

                    Thread.Sleep(3);
                    Console.Clear();


                    // check si une munition touche un enemmie
                    if (ammoListOnPlay.Count() > 0 && ennemyList.Count() > 0)
                    {
                        // pass en revue tout les enemmies
                        for (int i = 0; i < ennemyList.Count(); i++)
                        {
                            // passe en revue toute les munition tiré
                            for (int j = 0; j < ammoListOnPlay.Count(); j++)
                            {
                                if (ennemyList[i].YPos >= ammoListOnPlay[j].YPos && ennemyList[i].YPos <= ammoListOnPlay[j].YPos + 1 && ammoListOnPlay[j].XPos >= ennemyList[i].XPos && ammoListOnPlay[j].XPos <= ennemyList[i].XPos + 4)
                                {
                                    ennemyList.Remove(ennemyList[i]);
                                    ammoListOnPlay.RemoveAt(0);

                                    player.AddPoint();
                                    for (int x = 0; x < 2; x++)
                                    {
                                        ammoListOffPlay.Add(new Ammo(player.XPos, player.YPos, ConsoleColor.DarkBlue));
                                        player.CompteurAmmo++;
                                    }
                                    break;
                                }
                            }

                        }
                    }

                    // check si les enemmies sont à la même position que le joueur sur l'axe Y
                    for (int i = 0; i < ennemyList.Count(); i++)
                    {
                        samePosition = CheckPosition(player, ennemyList);
                    }

                    if (ammoListOnPlay.Count() == 0 && player.CompteurAmmo == 0)
                    {
                        lastAmmo = true;
                    }
                }
                while (!samePosition && ennemyList.Count() > 0 && !lastAmmo);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                // regarde si le joueur à perdu ou gagné
                if (samePosition || player.CompteurAmmo <= 0)
                {
                    // joue la musique de fond si le joueur à perdu la partie
                    PlayGround.looseSong.Play();

                    // Regarde la langue choisie par l'utilisateur
                    if (chrLanguage == 'e' || chrLanguage == 'E')
                    {
                        // affiche la page de défaite en anglais
                        englishMenu.LoseMenu();
                    }
                    else
                    {
                        // affiche la page de défaite en français
                        frenchMenu.LoseMenu();
                    }

                    // Insert les valeurs dans la base de donnée
                    store.InsertValue(player);

                    // réinitialise les valeurs 
                    player.CompteurAmmo = 50;
                    player._score = 0;

                }

                else
                {
                    // joue la musique de victoire
                    PlayGround.winSong.Play();

                    // regarde la langue du joueur
                    if (chrLanguage == 'e' || chrLanguage == 'E')
                    {
                        // affiche le menu de victoire en anglais
                        englishMenu.WinMenu();
                    }
                    else
                    {
                        // affiche le menu de victoire en français
                        frenchMenu.WinMenu();
                    }

                    winGame = true;
                }


                // réinitialise toute les valeurs
                ResetValue(player, ref xPosStart, ennemyList, ammoListOnPlay, ref firstLoop, ref lastAmmo);

                Console.ReadKey();
                Console.Clear();
            }
            while (true);
        }

        /// <summary>
        /// Ferme l'execution du code
        /// </summary>
        static void ExitGame()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Check la position de l'enemmies ar rapport au joueur
        /// </summary>
        /// <param name="player"></param>
        /// <param name="ennList"></param>
        /// <returns>Retourne un bool pour savoir si ils sont à la même position</returns>
        static bool CheckPosition(Player player, List<Ennemy> ennList)
        {
            // regarde si la liste n'est pas null
            if (ennList != null)
            {
                // regarde la position Y des enemmies est égal à la position Y du joueur 
                if (player.YPos == ennList.First().YPos)
                {
                    // retourne vrai si ils ont la même position
                    return true;
                }
            }

            // retourne faux dans le cas contraire
            return false;
        }

        /// <summary>
        /// Réinitialise toutes les valeurs
        /// </summary>
        /// <param name="_player"></param>
        /// <param name="_yPosStart"></param>
        /// <param name="_ennemyList"></param>
        /// <param name="_ammoList"></param>
        /// <param name="_firstLoop"></param>
        static void ResetValue(Player _player, ref int _yPosStart, List<Ennemy> _ennemyList, List<Ammo> _ammoList, ref bool _firstLoop, ref bool _lastAmmo)
        {
            _player.XPos = 5;
            _yPosStart = 5;
            _ennemyList.Clear();
            _ammoList.Clear();
            _firstLoop = true;
            _lastAmmo = false;
        }
    }
}