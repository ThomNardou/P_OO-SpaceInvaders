﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
