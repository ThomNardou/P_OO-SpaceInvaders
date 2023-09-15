using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ammo
    {

        public int xPos;
        public int yPos;

        public ConsoleColor color;

        

        public Ammo(int xPos, int yPos, ConsoleColor color)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.color = color;
        }

        public void Update()
        {
            yPos-=2;
        }
    }
}
