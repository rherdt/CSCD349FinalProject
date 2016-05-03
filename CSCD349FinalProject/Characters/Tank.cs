using CSCD349FinalProject.Inventory;
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
        private int invSlots;
        private InvItem[] inv;

        public Tank()
        {
            this.name = "Medic";
            this.attack = 6;
            this.defense = 10;
            this.invSlots = 3;
            this.inv = new InvItem[invSlots];
        }

        public string GetName()
        {
            return name;
        }

        public void DropInvItem(int slot)
        {
            if (slot >= 0 && slot < inv.Length)
                inv[slot] = null;
        }

        public int GetAttack()
        {
            return attack;
        }

        public int GetDefense()
        {
            return defense;
        }

        public InvItem GetInvItem(int slot)
        {
            if (slot >= 0 && slot < inv.Length)
                return inv[slot];

            else
                return null;
        }

        public bool InventoryFull()
        {
            bool full = true;

            foreach (InvItem i in inv)
            {
                if (i == null)
                    full = false;
            }

            return full;
        }

        public void PickUpInvItem(InvItem item)
        {
            if (!InventoryFull())
            {
                int slot = NextEmptyInvSlot();
                inv[slot] = item;
            }
        }

        public int NextEmptyInvSlot()
        {
            int emptySlot = 0;

            for (int i = 0; i < inv.Length; i++)
            {
                if (inv[i] == null)
                {
                    emptySlot = i;
                    i = inv.Length;
                }
            }

            return emptySlot;
        }
    }
}
