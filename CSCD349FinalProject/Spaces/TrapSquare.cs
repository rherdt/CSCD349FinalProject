using CSCD349FinalProject.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace CSCD349FinalProject.Spaces
{
    class TrapSquare: ASpace
    {

        public TrapSquare(): base()
        {

        }

        public override void runAction(Party user, MainWindow gameboard)
        {
            if (!traversed)
            {
                traversed = true;
                MessageBox.Show("You landed on a trap!");
                user.TakeDamage(5);
            }
        }

        public override string ToString()
        {
            return "Trap Square";
        }
    }
}
