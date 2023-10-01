using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {
        private int _xPos;
        public int XPos
        {
            get => _xPos;
            set => _xPos = value;
        }

        public int _yPos;
        public int _score = 0;

        private int compteurAmmo = 50;
        public int CompteurAmmo
        {
            get => compteurAmmo;
            set => compteurAmmo = value;
        }

        public ConsoleColor color;
        

        public Player(int x, int y, ConsoleColor color)
        {
            this._xPos = x;
            this._yPos = Config.SCREEN_HEIGHT - y;
            this.color = color;
        }

        public void UpdateXRight()
        {
            if (_xPos < Config.SCREEN_WIDTH - 9)
            {
                _xPos += 2;
            }  
        }

        public void UpdateXLeft()
        {
            if (_xPos > 6)
            {
                _xPos -= 2;
            }
        }

        public void AddPoint()
        {
            _score += 10;
        }


    }
}
