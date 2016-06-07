using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CSCD349FinalProject.Inventory
{
    class Medkit : IInvItem
    {
        private string name = "Medkit";
        private ImageBrush img = new ImageBrush(new BitmapImage(new Uri(@"../../Images/Medkit.png", UriKind.Relative)));
        

        public string GetName()
        {
            return name;
        }

        //Replenish health
        public int GetEffect()
        {
            return 25;
        }

        public ImageBrush GetImg()
        {
            return img;
        }
    }
}
