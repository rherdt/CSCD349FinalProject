using CSCD349FinalProject.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Characters
{
    interface IGoodGuy : ICharacter
    {
        InvItem GetInvItem(int slot);
        void PickUpInvItem(InvItem item);
        void DropInvItem(int slot);
        int NextEmptyInvSlot();
        bool InventoryFull();
    }
}
