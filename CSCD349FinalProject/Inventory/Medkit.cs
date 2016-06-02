using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Inventory
{
    class Medkit : IInvItem
    {
        private string name = "Medkit";

        public string GetName()
        {
            return name;
        }

        //Replenish health
        public void GetEffect()
        {
            throw new NotImplementedException();
        }
    }
}
