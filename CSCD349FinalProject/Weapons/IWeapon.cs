using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Weapons
{
    interface IWeapon
    {
        string GetName();
        int GetAttack();

        //possibly getter for block/defense?
        //possibly a getter for a sprite?

    }
}
