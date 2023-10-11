using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {

        // Déclaration des attributs
        private string _pseudo = "";

        public ConsoleColor color;

        private int _xPos;
        private int _yPos;
        private int compteurAmmo = 50;

        // Déclaration des propriétés 
        public string Pseudo
        {
            get => _pseudo;
            set => _pseudo = value;
        }
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

        public int _score = 0;

        public int CompteurAmmo
        {
            get => compteurAmmo;
            set => compteurAmmo = value;
        }

        /// <summary>
        /// Constructeur de la classe "player"
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public Player(int x, int y, ConsoleColor color)
        {
            this._xPos = x;
            this._yPos = Config.SCREEN_HEIGHT - y;
            this.color = color;
        }

        /// <summary>
        /// Change la position X du joueur pour le déplacer vers la droite
        /// </summary>
        public void UpdateXRight()
        {
            if (_xPos < Config.SCREEN_WIDTH - 9)
            {
                _xPos += 2;
            }  
        }

        /// <summary>
        /// Change la valeur X du joueur pour le déplacer vers la gauche
        /// </summary>
        public void UpdateXLeft()
        {
            if (_xPos > 6)
            {
                _xPos -= 2;
            }
        }

        /// <summary>
        /// Ajoute 10 point au joueur
        /// </summary>
        public void AddPoint()
        {
            _score += 10;
        }


    }
}
