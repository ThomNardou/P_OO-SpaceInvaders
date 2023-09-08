using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class player
    {

        private int xPos;
        private int yPos;

        private string[] _enemy = { "{@v@}", "/\" \"\\" };

        public void show()
        {
            Console.SetCursorPosition(xPos, yPos);
            for (int i = 0; i < _enemy.Length; i++)
            {
                Console.SetCursorPosition(xPos, yPos + i);
                Console.WriteLine(_enemy[i]);
            }
        }

        public void moveRight()
        {
            
        }
    }
}
