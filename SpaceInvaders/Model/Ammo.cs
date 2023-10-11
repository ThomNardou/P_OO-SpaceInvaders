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
        public void Update()
        {
            _yPos -= 2;
        }

        /// <summary>
        /// regarde si une munition touche un enemmie
        /// </summary>
        /// <param name="ennemyList"></param>
        /// <param name="ammoOnplayList"></param>
        /// <param name="player"></param>
        public void KillsEnnemy(List<Ennemy> ennemyList, List<Ammo> ammoOnplayList, List<Ammo> ammoOffPlayerList ,Player player)
        {

            // pass en revue tout les enemmies
            for (int i = 0; i < ennemyList.Count(); i++)
            {
                // passe en revue toute les munition tiré
                for (int j = 0; j < ammoOnplayList.Count(); j++)
                {
                    if (ennemyList[i].YPos >= ammoOnplayList[j]._yPos && ennemyList[i].YPos <= ammoOnplayList[j]._yPos + 1 && ammoOnplayList[j]._xPos >= ennemyList[i].XPos && ammoOnplayList[j]._xPos <= ennemyList[i].XPos + 4)
                    {
                        ennemyList.Remove(ennemyList[i]);
                        player.AddPoint();
                        for (int x = 0; x < 2; x++)
                        {
                            ammoOffPlayerList.Add(new Ammo(player.XPos, player.YPos, ConsoleColor.DarkBlue));
                            player.CompteurAmmo++;
                        }
                        break;
                    }
                }

            }
        }
    }
}
