using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCD349FinalProject.Weapons;
using CSCD349FinalProject.Characters;

namespace CSCD349FinalProjectTests
{
    /// <summary>
    /// Summary description for WeaponTests
    /// </summary>
    [TestClass]
    public class WeaponTests
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestSharpshooterWeapons()
        {
            IWeapon w1 = new Scout();
            IWeapon w2 = new AWP();
            Assert.IsTrue(w1.GetAttack() < w2.GetAttack());
            Sharpshooter s = new Sharpshooter();
            Assert.AreEqual(s.GetAttack(), w1.GetAttack());
            s.UpgradeWeapon();
            Assert.AreEqual(s.GetAttack(), w2.GetAttack());
        }

        [TestMethod]
        public void TestMedicWeapons()
        {
            IWeapon w1 = new USPS();
            IWeapon w2 = new DesertEagle();
            Assert.IsTrue(w1.GetAttack() < w2.GetAttack());
            Medic s = new Medic();
            Assert.AreEqual(s.GetAttack(), w1.GetAttack());
            s.UpgradeWeapon();
            Assert.AreEqual(s.GetAttack(), w2.GetAttack());
        }

        [TestMethod]
        public void TestTankWeapons()
        {
            IWeapon w1 = new P90();
            IWeapon w2 = new Negev();
            Assert.IsTrue(w1.GetAttack() < w2.GetAttack());
            Tank s = new Tank();
            Assert.AreEqual(s.GetAttack(), w1.GetAttack());
            s.UpgradeWeapon();
            Assert.AreEqual(s.GetAttack(), w2.GetAttack());
        }
    }
}
