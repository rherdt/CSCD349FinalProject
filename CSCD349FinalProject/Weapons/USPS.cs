using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Weapons
{
    class USPS : IWeapon
    {
        private int attack = 2;
        private string name = "USP-S";

        public int getAttack()
        {
            return attack;
        }

        public string getName()
        {
            return name;
        }
    }
}
