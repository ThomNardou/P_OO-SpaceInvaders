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

        private int _xPos;
        public int XPos
        {
            get=>_xPos; 
            set => _xPos = value;
        }

        private int _yPos;
        public int YPos
        {
            get => _yPos; 
            set => _yPos = value;
        }

        private int _speed = 1;
        public int Speed
        {
            get => _speed;
            set => _speed = value;
        }

        private bool _goingLeft = false;
        public bool GoingLeft
        {
            get => _goingLeft; 
            set => _goingLeft = value;
        }

        public ConsoleColor _color;

        public Ennemy (int x, int y, ConsoleColor color)
        {
            this._xPos = x;
            this._yPos = y;
            this._color = color;
        }

        public void UpdateEnnemyX()
        {
            if (_goingLeft)
            {
                this._xPos-=_speed;
            }
            else
            {
                this._xPos+=_speed;
            }
        }

        public void UpdateEnnemyY()
        {
            this._yPos += 2;
        }

        
    }
}
