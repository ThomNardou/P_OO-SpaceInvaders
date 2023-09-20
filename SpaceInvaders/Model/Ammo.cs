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
            yPos-=2;
        }

        public void killsEnnemy(List<Ennemy> ennemyList, List<Ammo> ammoList)
        {
            for (int i = 0; i < ammoList.Count(); i++)
            {
                for (int j = 0; j < ennemyList.Count(); j++)
                {
                    if ((ennemyList.ElementAt(j).xPos == ammoList.ElementAt(i).xPos || ennemyList.ElementAt(j).xPos + 1 == ammoList.ElementAt(i).xPos || ennemyList.ElementAt(j).xPos + 2 == ammoList.ElementAt(i).xPos || ennemyList.ElementAt(j).xPos + 3 == ammoList.ElementAt(i).xPos || ennemyList.ElementAt(j).xPos + 4 == ammoList.ElementAt(i).xPos) && ennemyList.ElementAt(j).yPos == ammoList.ElementAt(i).yPos)
                    {
                        ennemyList.Remove(ennemyList.ElementAt(j));
                    }
                }
            }
        }
    }
}
