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

        public ConsoleColor color;

        

        public Ennemy (int x, int y, ConsoleColor color)
        {
            this.xPos = x;
            this.yPos = y;
            this.color = color;
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
