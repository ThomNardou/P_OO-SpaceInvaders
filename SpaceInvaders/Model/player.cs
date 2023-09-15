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

        ConsoleColor color;
        

        private string[] _player =
        {
            " | ",
            "/@\\"
        };

        public Player(int x, int y, ConsoleColor color)
        {
            this.xPos = x;
            this.yPos = Config.SCREEN_HEIGHT - y;
            this.color = color;
        }

        public void show()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(xPos, yPos);
            for (int i = 0; i < _player.Length; i++)
            {
                Console.SetCursorPosition(xPos, yPos + i);
                Console.WriteLine(_player[i]);
            }
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
