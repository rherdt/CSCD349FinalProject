using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CSCD349FinalProject.Spaces
{
    abstract class ASpace : ISpace
    {

        protected Border sprite;
        protected bool traversed;

        public ASpace()
        {
            this.sprite = new Border();
            this.traversed = false;
        }
        public Border getSpace()
        {
            return this.sprite;
        }

        public bool Traversed()
        {
            return traversed;
        }
        public abstract void runAction();


    }
}
