using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCD349FinalProject.Inventory;
using CSCD349FinalProject.Weapons;

namespace CSCD349FinalProject.Characters
{
    class Medic : IGoodGuy
    {
        private string name;
        private int attack;
        private int defense;
        private IWeapon weapon;
        //private int invSlots;
        //private IInvItem[] inv;

        public Medic()
        {
            this.name = "Medic";
            this.defense = 5;
            this.weapon = new USPS();
            this.attack = this.weapon.GetAttack();
            //this.invSlots = 10;
            //this.inv = new IInvItem[invSlots];
        }

        public string GetName()
        {
            return name;
        }

        //public void DropInvItem(int slot)
        //{
        //    if (slot >= 0 && slot < inv.Length)
        //        inv[slot] = null;
        //}

        public int GetAttack()
        {
            return attack;
        }

        public int GetDefense()
        {
            return defense;
        }

        public void UpgradeWeapon()
        {
            weapon = new DesertEagle();
            attack = weapon.GetAttack();
        }

        public bool IsUpgraded()
        {
            if (weapon.GetName().Equals("Desert Eagle"))
                return true;

            return false;
        }

        //public IInvItem GetInvItem(int slot)
        //{
        //    if (slot >= 0 && slot < inv.Length)
        //        return inv[slot];

        //    else
        //        return null;
        //}

        //public bool InventoryFull()
        //{
        //    bool full = true;

        //    foreach (IInvItem i in inv)
        //    {
        //        if (i == null)
        //            full = false;
        //    }

        //    return full;
        //}

        //public void PickUpInvItem(IInvItem item)
        //{
        //    if (!InventoryFull())
        //    {
        //        int slot = NextEmptyInvSlot();
        //        inv[slot] = item;
        //    }
        //}

        //public int NextEmptyInvSlot()
        //{
        //    int emptySlot = 0;

        //    for (int i = 0; i < inv.Length; i++)
        //    {
        //        if (inv[i] == null)
        //        {
        //            emptySlot = i;
        //            i = inv.Length;
        //        }                  
        //    }

        //    return emptySlot;
        //}
    }
}
