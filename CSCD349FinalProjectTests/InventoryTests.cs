using System;
using CSCD349FinalProject.Inventory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSCD349FinalProjectTests
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void TestSlotsAvailable()
        {
            Inventory inv = new Inventory(3);
            Assert.IsTrue(inv.AvailableSlots());

            inv.AddItem(new Molotov());
            inv.AddItem(new Grenade());
            inv.AddItem(new Medkit());
            Assert.IsFalse(inv.AvailableSlots());

            inv.UseItem(inv.GetItems()[0]);
            Assert.IsTrue(inv.AvailableSlots());


        }

        [TestMethod]
        public void TestAddItem()
        {
            Inventory inv = new Inventory(3);
            inv.AddItem(new Molotov());
            Assert.AreEqual(1, inv.GetItems().Count);

            //test edge case
            inv.AddItem(new Molotov());
            inv.AddItem(new Molotov());
            inv.AddItem(new Molotov());
            Assert.AreEqual(3, inv.GetItems().Count);
        }


        [TestMethod]
        public void TestUseItem()
        {
            Inventory inv = new Inventory(3);
            inv.AddItem(new Molotov());
            inv.AddItem(new Bandage());
            inv.UseItem(inv.GetItems()[1]);

            Assert.AreEqual(1, inv.GetItems().Count);

            //test edge case
            inv.UseItem(inv.GetItems()[0]);
            Assert.AreEqual(0, inv.GetItems().Count);
        }

        [TestMethod]
        public void TestNumSlots()
        {
            Inventory inv = new Inventory(5);
            Assert.AreEqual(5, inv.GetNumSlots());

            //test edge case
            inv = new Inventory(-1);
            Assert.AreEqual(3, inv.GetNumSlots());
        }


    }


}
