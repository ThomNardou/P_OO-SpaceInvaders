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
        // Déclaration des attributs
        private bool _goingLeft = false;

        public ConsoleColor _color;

        private int _xPos;
        private int _yPos;
        private int _speed = 10;

        // Déclaration des propriétés 
        public int XPos
        {
            get=>_xPos; 
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
        public bool GoingLeft
        {
            get => _goingLeft; 
            set => _goingLeft = value;
        }

        public Ennemy (int x, int y, ConsoleColor color)
        {
            this._xPos = x;
            this._yPos = y;
            this._color = color;
        }

        /// <summary>
        /// Change la valeur X de l'enemmie pour le déplacer
        /// </summary>
        public void UpdateEnnemyX()
        {
            // regarde si l'enemmie va à gauche
            if (_goingLeft)
            {
                // déplace l'enemmie sur la gauche
                this._xPos -= 2;
            }
            else
            {
                // Déplace l'enemmie sur la droite
                this._xPos += 2;
            }
        }

        /// <summary>
        /// Change la valeur Y de l'enemmie pour le déplacer vers le bas
        /// </summary>
        public void UpdateEnnemyY()
        {
            this._yPos += 2;
        }

        
    }
}
