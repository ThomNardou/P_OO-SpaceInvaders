using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using Model;

namespace Display
{
    public class PlayGround
    {
        static private string[] _player =
        {
            " | ",
            "/@\\"
        };

        static private string[] view =
        {
            " O ",
            " | "
        };

        static private string[] _enemy = { "{@v@}", "/\" \"\\" };

        static public SoundPlayer lobbySong = new SoundPlayer(@"LobbySong.wav");
        static public SoundPlayer firstPartSong = new SoundPlayer(@"FirstPartFight.wav");
        static public SoundPlayer secondPartSong = new SoundPlayer(@"SecondPartFight.wav");
        static public SoundPlayer winSong = new SoundPlayer(@"WinSong.wav");
        static public SoundPlayer looseSong = new SoundPlayer(@"LooseSong.wav");

        static private char _chrLanguage;
        static private string _strPseudo;

        private const string CHOSE_DEFAULT_LANGUAGE = "Please select a language (Français/English) <f/e> : ";
        private const string CHOSE_PLAYER_NAME_FR = "Veuillez entrer votre pseudo : ";
        private const string CHOSE_PLAYER_NAME_EN = "Please enter your username : ";

        public static void Init()
        {
            Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
            Console.SetBufferSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "SpaceInvaders.exe";
        }

        static public void ShowPlayer(Player player)
        {
            Console.ForegroundColor = player.color;
            Console.SetCursorPosition(player.XPos, player.YPos);
            for (int i = 0; i < _player.Length; i++)
            {
                Console.SetCursorPosition(player.XPos, player.YPos + i);
                Console.WriteLine(_player[i]);
            }
        }

        static public void ShowEnnemy(Ennemy ennemy)
        {
            Console.ForegroundColor = ennemy._color;
            Console.SetCursorPosition(ennemy.XPos, ennemy.YPos);
            for (int i = 0; i < _enemy.Length; i++)
            {
                Console.SetCursorPosition(ennemy.XPos, ennemy.YPos + i);
                Console.WriteLine(_enemy[i]);
            }
        }

        static public void ShowAmmo(Ammo ammo)
        {
            Console.ForegroundColor = ammo._color;
            Console.SetCursorPosition(ammo.XPos, ammo.YPos);
            for (int i = 0; i < view.Length; i++)
            {
                Console.SetCursorPosition(ammo.XPos, ammo.YPos + i);
                Console.WriteLine(view[i]);
            }
        }

        static public void ShowAmmoCount(char chrLanguage, Player player)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(0, 1);
            if (chrLanguage == 'f' || chrLanguage == 'F')
                Console.WriteLine($"Munition : {player.CompteurAmmo}");
            else
                Console.WriteLine($"Ammo : {player.CompteurAmmo}");
        }

        static public void ShowPlayerScore(Player player)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Score : {player.Score}");
        }

        static public char ChoseLanguage()
        {
            Console.SetCursorPosition((Config.SCREEN_WIDTH - CHOSE_DEFAULT_LANGUAGE.Length) / 2, Config.SCREEN_HEIGHT / 2 - 1);
            Console.Write(CHOSE_DEFAULT_LANGUAGE);
            _chrLanguage = Console.ReadKey(true).KeyChar;
            Console.Clear();
            return _chrLanguage;
        }

        static public string ChosePlayerName(char chrLanguage)
        {
            if (chrLanguage == 'f' || chrLanguage == 'F')
            {
                Console.SetCursorPosition((Config.SCREEN_WIDTH - CHOSE_PLAYER_NAME_FR.Length) / 2, Config.SCREEN_HEIGHT / 2 - 1);
                Console.Write(CHOSE_PLAYER_NAME_FR);
            }
            else
            {
                Console.SetCursorPosition((Config.SCREEN_WIDTH - CHOSE_PLAYER_NAME_EN.Length) / 2, Config.SCREEN_HEIGHT / 2 - 1);
                Console.Write(CHOSE_PLAYER_NAME_EN);
            }
            return _strPseudo = Console.ReadLine();
        } 
    }
}
