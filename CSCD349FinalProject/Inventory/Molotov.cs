using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Inventory
{
    class Molotov : IInvItem
    {
        private string name = "Molotov";

        public string GetName()
        {
            return name;
        }

        //Damage enemy more than grenade
        public void GetEffect()
        {
            throw new NotImplementedException();
        }
    }
}
