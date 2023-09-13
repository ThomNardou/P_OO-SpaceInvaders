using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class Ammo
    {

        public int xPos;
        public int yPos;

        ConsoleColor color;

        private string[] view =
        {
            " O ",
            " | "
        }; 

        public Ammo(int xPos, int yPos, ConsoleColor color)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.color = color;
        }

        public void Show()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(xPos, yPos);
            for (int i = 0; i < view.Length; i++)
            {
                Console.SetCursorPosition(xPos, yPos + i);
                Console.WriteLine(view[i]);
            }
        }

        public void Update()
        {
            yPos-=2;
        }
    }
}
