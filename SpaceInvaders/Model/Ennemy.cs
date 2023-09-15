using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ennemy
    {

        public int xPos;
        public int yPos;

        public bool goingLeft = false;

        ConsoleColor color;

        private string[] _enemy = { "{@v@}", "/\" \"\\" };

        public Ennemy (int x, int y, ConsoleColor color)
        {
            this.xPos = x;
            this.yPos = y;
            this.color = color;
        }


        public void show()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(xPos, yPos);
            for (int i = 0; i < _enemy.Length; i++)
            {
                Console.SetCursorPosition(xPos, yPos + i);
                Console.WriteLine(_enemy[i]);
            }
        }

        public void updateEnnemyX()
        {
            if (goingLeft)
            {
                this.xPos-=3;
            }
            else
            {
                this.xPos+=3;
            }
        }

        public void updateEnnemyY()
        {
            this.yPos += 2;
        }
    }
}
