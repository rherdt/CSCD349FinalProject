using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Weapons
{
    class P90 : IWeapon
    {
        private int attack = 5;
        private string name = "P90";

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
