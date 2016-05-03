using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Accessories
{
    interface IAccessory
    {

        int getWeight();
        string getName();
        int getNumberOfUses();
        
        //possibly a getter for a sprite?
    }
}
