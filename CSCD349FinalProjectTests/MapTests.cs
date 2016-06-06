using System;
using System.Windows;
using CSCD349FinalProject;
using CSCD349FinalProject.Spaces;
using CSCD349FinalProject.Characters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSCD349FinalProjectTests
{
    
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void MapIsCorrectSize()
        {
            Map m = new Map(10,10, new Party(3));
            Assert.AreEqual(m.GetColumns(), 10);
            Assert.AreEqual(m.GetRows(), 10);

        }

        [TestMethod]
        public void StairsAreLoaded()
        {
            Map m = new Map(10, 10, new Party(3));
            Assert.IsInstanceOfType(m.GetBoardSpace(0, m.getGrid().GetLength(1) - 1), typeof(StairSquare));
        }

        [TestMethod]
        public void DrawSpriteFillsChild()
        {
            Map m = new Map(10, 10, new Party(1));
            m.DrawSprite(5, 5);
            Assert.IsNotNull(m.GetBoardSpace(5, 5).getSpace().Child);
        }

        [TestMethod]
        public void SetCurrentPosition()
        {
            Map m = new Map(10, 10, new Party(3));
            m.SetCurrentPosition(5, 5);
            Point p = m.GetCurrentPosition();
            Assert.AreEqual(new Point(5,5), p);
        }

        [TestMethod]
        public void ReturnsValidParty()
        {
            Map m = new Map(10, 10, new Party(3));
            Party p = m.getParty();
            Assert.IsNotNull(p);
        }
    }
}
