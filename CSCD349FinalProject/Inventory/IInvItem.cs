using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD349FinalProject.Inventory
{
    interface IInvItem
    {
        string GetName();
        void GetEffect();
        ImageBrush GetImg();
    }
}
