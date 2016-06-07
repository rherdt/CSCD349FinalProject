﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CSCD349FinalProject.Inventory
{
    class Molotov : IInvItem
    {
        private string name = "Molotov";
        private ImageBrush img = new ImageBrush(new BitmapImage(new Uri(@"../../Images/Molotov.png", UriKind.Relative)));

        public string GetName()
        {
            return name;
        }

        //Damage enemy more than grenade
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
