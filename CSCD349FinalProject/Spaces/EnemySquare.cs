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
    class EnemySquare: ASpace
    {
        /*Enemy Party object*/
        public EnemySquare(): base()
        {
        }

        public override void runAction(MainWindow gameboard)
        {
            MessageBox.Show("Enemy!");
        }

        public override string ToString()
        {
            return "Enemy Square";
        }
    }
}
