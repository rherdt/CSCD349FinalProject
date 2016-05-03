﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CSCD349FinalProject.Spaces
{
    class EdgeSquare:ISpace
    {
        private Rectangle sprite;
        private bool traversed;

        public EdgeSquare()
        {
            traversed = false;
        }

        public bool Traversed
        {
            get
            {
                return traversed;
            }
        }

        public Rectangle getSpace()
        {
            return sprite;
        }
        public void runAction(/*party object*/)
        {
            //could use this to deal with change state?
            //redirect back onto playing board
            //traversed = true;
        }
    }
}
