using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ammo
    {
        // déclaration des attributs
        private int _xPos;
        private int _yPos;
        private int _speed = 5;

        public ConsoleColor _color;

        // Déclaration des propriétés
        public int XPos
        {
            get => _xPos; 
            set => _xPos = value;
        }
        public int YPos
        {
            get => _yPos; 
            set => _yPos = value;
        }
        public int Speed
        {
            get => _speed;
            set => _speed = value;
        }

        /// <summary>
        /// Constructeur d'une munition
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="color"></param>
        public Ammo(int xPos, int yPos, ConsoleColor color)
        {
            this._xPos = xPos;
            this._yPos = yPos;
            this._color = color;
        }

        /// <summary>
        /// Change la valeur de Y pour faire monter la munition
        /// </summary>
        public void UpdateAmmoY()
        {
            _yPos -= 2;
        }
    }
}
