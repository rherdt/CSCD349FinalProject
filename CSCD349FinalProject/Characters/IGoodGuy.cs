using CSCD349FinalProject.Inventory;
using CSCD349FinalProject.Weapons;

namespace CSCD349FinalProject.Characters
{
    interface IGoodGuy : ICharacter
    {
        void UpgradeWeapon();
        //IInvItem GetInvItem(int slot);
        //void PickUpInvItem(IInvItem item);
        //void DropInvItem(int slot);
        //int NextEmptyInvSlot();
        //bool InventoryFull();
    }
}
