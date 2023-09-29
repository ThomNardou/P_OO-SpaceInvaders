using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Model
{
    public class Ennemy
    {

        public int xPos;
        public int yPos;
        public int speed = 1;

        public bool goingLeft = false;

        public ConsoleColor _color;

        

        public Ennemy (int x, int y, ConsoleColor color)
        {
            this.xPos = x;
            this.yPos = y;
            this._color = color;
        }


        

        public void updateEnnemyX()
        {
            if (goingLeft)
            {
                this.xPos-=speed;
            }
            else
            {
                this.xPos+=speed;
            }
        }

        public void updateEnnemyY()
        {
            this.yPos += 2;
        }

        
    }
}
