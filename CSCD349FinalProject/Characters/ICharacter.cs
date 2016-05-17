using CSCD349FinalProject.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Characters
{
    interface ICharacter
    {
        int GetAttack();
        int GetDefense();
        string GetName();
        void ChangeWeapon(IWeapon weapon);
    }
}
