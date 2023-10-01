using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ammo
    {

        public int xPos;
        public int yPos;

        public ConsoleColor color;



        public Ammo(int xPos, int yPos, ConsoleColor color)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.color = color;
        }

        public void Update()
        {
            yPos -= 2;
        }

        public void KillsEnnemy(List<Ennemy> ennemyList, List<Ammo> ammoList, Player player)
        {
            for (int i = 0; i < ennemyList.Count(); i++)
            {

                for (int j = 0; j < ammoList.Count(); j++)
                {
                    if (ennemyList[i].yPos >= ammoList[j].yPos && ennemyList[i].yPos <= ammoList[j].yPos + 1 && ammoList[j].xPos >= ennemyList[i].xPos && ammoList[j].xPos <= ennemyList[i].xPos + 4)
                    {
                        ennemyList.Remove(ennemyList[i]);
                        player.AddPoint();
                        player.CompteurAmmo += 3;
                        break;
                    }
                }

            }
        }
    }
}
