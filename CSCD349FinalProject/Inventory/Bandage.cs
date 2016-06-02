﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD349FinalProject.Inventory
{
    class Bandage : IInvItem
    {
        private string name = "Bandage";
        private ImageBrush img = new ImageBrush();

        public string GetName()
        {
            return name;
        }
        
        //Replenish health less than medkit
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