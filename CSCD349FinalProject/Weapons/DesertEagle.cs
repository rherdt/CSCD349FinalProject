using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Weapons
{
    class DesertEagle : IWeapon
    {
        private int attack = 5;
        private string name = "Desert Eagle";

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
