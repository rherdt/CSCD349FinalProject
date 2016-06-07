using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD349FinalProject.Characters
{
    interface IParty
    {
        int GetHP();
        void TakeDamage(int hp);
        int GetPartyAttack();
        int GetPartyDefense();
        int GetLevel();
        ImageBrush GetImg();
        Inventory.Inventory GetInventory();
        void LevelUp();
        bool UpgradeWeapon();
        void ToggleCheat();
        void SetPartyLevel(int level);
        void setHealth(int health);
        int GetPartyType();
    }
}
