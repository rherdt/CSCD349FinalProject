using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Inventory
{
    class Inventory
    {
        private int numSlots;
        private int numAvailableSlots;        
        List<IInvItem> items;
        public Inventory(int numSlots)
        {
            this.numSlots = numSlots;
            this.items = new List<IInvItem>(numSlots);
            this.numAvailableSlots = this.items.Count();
        }

        public bool AvailableSlots()
        {
            return this.items.Count < this.numSlots;
        }

        public void AddItem(IInvItem item)
        {
            if(item != null)
            {
                if (AvailableSlots())
                {
                    this.items.Add(item);
                }
                else
                {//Can take out after debugging, or add to info panel
                    Console.WriteLine("Inventory Full");
                }
            }
            
        }

        public void UseItem(IInvItem item)
        {
            if(item != null && this.items.Count > 0)
            {
                this.items.Remove(item);
            }
        }

        public int getNumSlots()
        {
            return this.numSlots;
        }

        public List<IInvItem> GetItems()
        {
            return this.items;
        }

    }
}
