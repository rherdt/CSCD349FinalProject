using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD349FinalProject.Inventory
{
    class Medkit : IInvItem
    {
        private string name = "Medkit";
        private ImageBrush img = new ImageBrush();

        public string GetName()
        {
            return name;
        }

        //Replenish health
        public void GetEffect()
        {
            throw new NotImplementedException();
        }

        public ImageBrush GetImg()
        {
            return img;
        }
    }
}
