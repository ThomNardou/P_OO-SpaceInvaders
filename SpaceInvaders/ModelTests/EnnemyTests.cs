using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tests
{
    [TestClass()]
    public class EnnemyTests
    {
        [TestMethod()]
        public void UpdateEnnemyXTestLeft()
        {
            int oldXPos;
            Ennemy ennemy = new Ennemy(8, 5, ConsoleColor.DarkBlue);

            oldXPos = ennemy.XPos;
            ennemy.GoingLeft = true;

            ennemy.UpdateEnnemyX();

            Assert.AreEqual(ennemy.XPos, oldXPos - 2);
        }

        [TestMethod()]
        public void UpdateEnnemyXTestRight()
        {
            int oldXPos;
            Ennemy ennemy = new Ennemy(8, 5, ConsoleColor.DarkBlue);

            oldXPos = ennemy.XPos;
            ennemy.GoingLeft = false;

            ennemy.UpdateEnnemyX();

            Assert.AreEqual(ennemy.XPos, oldXPos + 2);
        }

        [TestMethod()]
        public void UpdateEnnemyYTest()
        {
            int oldYPos;
            Ennemy ennemy = new Ennemy(8, 5, ConsoleColor.DarkBlue);

            oldYPos = ennemy.YPos;

            ennemy.UpdateEnnemyY();

            Assert.AreEqual(ennemy.YPos, oldYPos + 2);
        }
    }
}