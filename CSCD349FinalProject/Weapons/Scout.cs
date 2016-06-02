using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Weapons
{
    class Scout : IWeapon
    {
        private int attack = 8;
        private string name = "Scout";

        public int GetAttack()
        {
            return attack;
        }

        public string GetName()
        {
            return name;
        }
    }
}
