using CSCD349FinalProject.Inventory;
using CSCD349FinalProject.Weapons;

namespace CSCD349FinalProject.Characters
{
    interface IGoodGuy : ICharacter
    {
        void ChangeWeapon(IWeapon weapon);
        InvItem GetInvItem(int slot);
        void PickUpInvItem(InvItem item);
        void DropInvItem(int slot);
        int NextEmptyInvSlot();
        bool InventoryFull();
    }
}
