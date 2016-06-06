using CSCD349FinalProject.Inventory;
using CSCD349FinalProject.Weapons;

namespace CSCD349FinalProject.Characters
{
    interface IGoodGuy : ICharacter
    {
        void ChangeWeapon(IWeapon weapon);
        IInvItem GetInvItem(int slot);
        void PickUpInvItem(IInvItem item);
        void DropInvItem(int slot);
        int NextEmptyInvSlot();
        bool InventoryFull();
    }
}
