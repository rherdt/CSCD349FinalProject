using System;
using CSCD349FinalProject.Characters;
using CSCD349FinalProject.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSCD349FinalProjectTests
{
    [TestClass]
    public class PartyTests
    {
        [TestMethod]
        public void TestPartyHealth()
        {
            Party p = new Party(1);
            Assert.AreEqual(100, p.GetHP());
        }

        [TestMethod]
        public void TestTakeDamage()
        {
            Party p = new Party(1);
            Assert.AreEqual(100, p.GetHP());
            p.Damage(10);
            Assert.AreEqual(90, p.GetHP());
            p.Damage(100);
            Assert.AreEqual(0, p.GetHP());
        }

        [TestMethod]
        public void TestLevelUp()
        {
            Party p = new Party(1);
            int originalAttack = p.GetPartyAttack();
            p.LevelUp();
            p.LevelUp();
            p.LevelUp();
            p.LevelUp();
            int newAttack = p.GetPartyAttack();
            Assert.AreEqual(5, p.GetLevel());
            Assert.IsTrue(newAttack > originalAttack);
        }

        [TestMethod]
        public void TestGetDefense()
        {
            Party p = new Party(1);
            int originalDefense = p.GetPartyDefense();
            p.LevelUp();
            p.LevelUp();
            p.LevelUp();
            p.LevelUp();
            int newDefense = p.GetPartyDefense();
            Assert.IsTrue(newDefense > originalDefense);
        }

        [TestMethod]
        public void TestRecalcStats()
        {
            Party p = new Party(1);
            int originalDefense = p.GetPartyDefense();
            int originalAttack = p.GetPartyAttack();
            p.LevelUp();
            p.LevelUp();
            p.LevelUp();
            p.LevelUp();
            int newDefense = p.GetPartyDefense();
            int newAttack = p.GetPartyAttack();
            Assert.IsTrue(newAttack > originalAttack);
            Assert.IsTrue(newDefense > originalDefense);
        }

        [TestMethod]
        public void TestGetLevel()
        {
            Party p = new Party(1);
            Assert.AreEqual(1, p.GetLevel());
            p.LevelUp();
            Assert.AreEqual(2, p.GetLevel());


        }

        [TestMethod]
        public void TestGetImg()
        {
            Party p = new Party(1);
            Assert.IsNotNull(p.GetImg());
        }

        [TestMethod]
        public void TestUpgradeWeapon()
        {
            Party p = new Party(1);
            int originalAttack = p.GetPartyAttack();
            p.UpgradeWeapon();
            int newAttack = p.GetPartyAttack();
            Assert.IsTrue(newAttack > originalAttack);
        }


    }
}
