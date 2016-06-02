using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Weapons
{
    interface IWeapon
    {
        string getName();
        int getAttack();

        //possibly getter for block/defense?
        //possibly a getter for a sprite?

    }
}
