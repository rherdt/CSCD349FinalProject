using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CSCD349FinalProject.Spaces
{
    class StairSquare : ASpace
    {
        public StairSquare() : base()
        {
        }

        public override void runAction(MainWindow gameboard)
        {
            
            gameboard.NextFloor();
        }
        public override string ToString()
        {
            return "Stair Square";
        }
    }


}