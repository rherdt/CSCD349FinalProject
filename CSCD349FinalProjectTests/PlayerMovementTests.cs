using System;
using System.Windows;
using System.Text;
using CSCD349FinalProject.GamePlay;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCD349FinalProject.Spaces;
using CSCD349FinalProject.Characters;

namespace CSCD349FinalProjectTests
{
    [TestClass]
    public class PlayerMovementTests
    {
        [TestMethod]
        public void KeyUp()
        {
            Map m = new Map(10, 10, new Party(3));

            m.SetCurrentPosition(9, 0);
            m.DrawSprite(9, 0);

            PlayerMovement.KeyUp(m);
            Assert.AreEqual(new Point(8, 0), m.GetCurrentPosition());

            //test edge case
            m.SetCurrentPosition(0, 0);
            m.DrawSprite(0, 0);

            PlayerMovement.KeyUp(m);
            Assert.AreEqual(new Point(0, 0), m.GetCurrentPosition());
        }

        [TestMethod]
        public void KeyDown()
        {
            Map m = new Map(10, 10, new Party(3));

            m.SetCurrentPosition(8, 0);
            m.DrawSprite(8, 0);

            PlayerMovement.KeyDown(m);
            Assert.AreEqual(new Point(9, 0), m.GetCurrentPosition());

            //test edge case
            PlayerMovement.KeyDown(m);
            Assert.AreEqual(new Point(9, 0), m.GetCurrentPosition());
        }

        [TestMethod]
        public void KeyLeft()
        {
            Map m = new Map(10, 10, new Party(3));

            m.SetCurrentPosition(0, 1);
            m.DrawSprite(0,1);

            PlayerMovement.KeyLeft(m);
            Assert.AreEqual(new Point(0, 0), m.GetCurrentPosition());

            //test edge case
            PlayerMovement.KeyLeft(m);
            Assert.AreEqual(new Point(0, 0), m.GetCurrentPosition());
        }

        [TestMethod]
        public void KeyRight()
        {
            Map m = new Map(10, 10, new Party(3));

            m.SetCurrentPosition(0, 8);
            m.DrawSprite(0, 8);

            PlayerMovement.KeyRight(m);
            Assert.AreEqual(new Point(0, 9), m.GetCurrentPosition());

            //test edge case
            PlayerMovement.KeyRight(m);
            Assert.AreEqual(new Point(0, 9), m.GetCurrentPosition());
        }
    }
}
