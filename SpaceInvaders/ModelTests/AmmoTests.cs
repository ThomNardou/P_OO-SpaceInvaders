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
    public class AmmoTests
    {
        [TestMethod()]
        public void UpdateAmmoYTest()
        {
            int oldYPos;
            Ammo ammo = new Ammo(8, Config.SCREEN_HEIGHT - 10, ConsoleColor.DarkBlue);

            oldYPos = ammo.YPos;

            ammo.UpdateAmmoY();

            Assert.AreEqual(ammo.YPos, oldYPos - 2);
        }
    }
}