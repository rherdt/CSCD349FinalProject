using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using CSCD349FinalProject.States;

namespace CSCD349FinalProject.Spaces
{
    class TravelSpace : ISpace
    {
        private Rectangle space;
        private IState state;

        public TravelSpace()
        {
            this.space = new Rectangle();
            this.state = new TravelState();
        }

        public Rectangle getSpace()
        {
             return this.space;
        }

    }
}
