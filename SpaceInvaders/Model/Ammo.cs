using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ammo
    {

        private int _xPos;
        public int XPos
        {
            get => _xPos; 
            set => _xPos = value;
        }

        private int _yPos;
        public int YPos
        {
            get => _yPos; 
            set => _yPos = value;
        }

        public ConsoleColor _color;

        public Ammo(int xPos, int yPos, ConsoleColor color)
        {
            this._xPos = xPos;
            this._yPos = yPos;
            this._color = color;
        }

        public void Update()
        {
            _yPos -= 2;
        }

        public void KillsEnnemy(List<Ennemy> ennemyList, List<Ammo> ammoList, Player player)
        {
            for (int i = 0; i < ennemyList.Count(); i++)
            {

                for (int j = 0; j < ammoList.Count(); j++)
                {
                    if (ennemyList[i].YPos >= ammoList[j]._yPos && ennemyList[i].YPos <= ammoList[j]._yPos + 1 && ammoList[j]._xPos >= ennemyList[i].XPos && ammoList[j]._xPos <= ennemyList[i].XPos + 4)
                    {
                        ennemyList.Remove(ennemyList[i]);
                        ammoList.Remove(ammoList[j]);
                        player.AddPoint();
                        player.CompteurAmmo += 2;
                        break;
                    }
                }

            }
        }
    }
}
