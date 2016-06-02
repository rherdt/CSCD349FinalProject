using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Inventory
{
    class Grenade : IInvItem
    {
        private string name = "Grenade";

        public string GetName()
        {
            return name;
        }

        //Damage enemy
        public void GetEffect()
        {
            throw new NotImplementedException();
        }
    }
}
