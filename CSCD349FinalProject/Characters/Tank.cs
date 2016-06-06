using CSCD349FinalProject.Inventory;
using CSCD349FinalProject.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Characters
{
    class Tank : IGoodGuy
    {
        private string name;
        private int attack;
        private int defense;
        private IWeapon weapon;
        //private int invSlots;
       // private IInvItem[] inv;

        public Tank()
        {
            this.name = "Medic";
            this.defense = 10;
            this.weapon = new P90();
            this.attack = this.weapon.GetAttack();
            //this.invSlots = 3;
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
            weapon = new Negev();
        }

        public bool IsUpgraded()
        {
            if (weapon.GetName().Equals("Negev"))
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
