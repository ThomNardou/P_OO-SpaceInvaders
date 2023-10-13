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
    public class PlayerTests
    {
        [TestMethod()]
        public void AddPointTest()
        {
            int oldScore;
            Player player = new Player(20, 5, ConsoleColor.Red);
            oldScore = player._score;

            player.AddPoint();

            Assert.AreEqual(player._score, oldScore + 10);
        }

        [TestMethod()]
        public void UpdateXRightTest()
        {
            int oldXPos;
            Player player = new Player(20, 5, ConsoleColor.Red);
            oldXPos = player.XPos;

            player.UpdateXRight();

            Assert.AreEqual(player.XPos, oldXPos + 2);
        }

        [TestMethod()]
        public void UpdateXLeftTest()
        {
            int oldXPos;
            Player player = new Player(20, 5, ConsoleColor.Red);
            oldXPos = player.XPos;

            player.UpdateXLeft();

            Assert.AreEqual(player.XPos, oldXPos - 2);
        }
    }
}