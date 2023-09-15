using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {
        public int xPos;
        public int yPos;

        public ConsoleColor color;
        

        public Player(int x, int y, ConsoleColor color)
        {
            this.xPos = x;
            this.yPos = Config.SCREEN_HEIGHT - y;
            this.color = color;
        }

        public void updateXRight()
        {
            if (xPos < Config.SCREEN_WIDTH - 9)
            {
                xPos += 2;
            }  
        }

        public void updateXLeft()
        {
            if (xPos > 6)
            {
                xPos -= 2;
            }
        }

        
    }
}
