using CSCD349FinalProject.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CSCD349FinalProject.Spaces
{
    class TreasureSquare: ASpace
    {
        //set an item object to add to player inventory
        public TreasureSquare() : base()
        {
        }

        public override void runAction(Party user)
        {
            //could use this to deal with change state?
            //redirect back onto playing board
            //traversed = true;
        }

        public override string ToString()
        {
            return "Treasure Square";
        }
    }
}
