using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Weapons
{
    class TempWeapon : IWeapon
    {
        public int getDamage()
        {
            return 10;
        }

        public string getName()
        {
            return "Temp";
        }

        public IWeaponEffect getWeaponEffect()
        {
            throw new NotImplementedException();
        }

        public int getWeight()
        {
            throw new NotImplementedException();
        }

        public void setDamage(int dmg)
        {
            throw new NotImplementedException();
        }
    }
}
