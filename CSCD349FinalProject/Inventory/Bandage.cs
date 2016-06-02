using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Inventory
{
    class Bandage : IInvItem
    {
        private string name = "Bandage";

        public string GetName()
        {
            return name;
        }
        
        //Replenish health less than medkit
        public void GetEffect()
        {
            throw new NotImplementedException();
        }
    }
}
