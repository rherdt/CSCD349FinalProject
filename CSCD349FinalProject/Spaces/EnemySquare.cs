using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using BattleView;
using CSCD349FinalProject.Characters;

namespace CSCD349FinalProject.Spaces
{
    class EnemySquare: ASpace
    {
        Party enemy;
        public EnemySquare(): base()
        {
            enemy = null;
        }

        public override void runAction(Party user, MainWindow gameboard)
        {
            if(traversed == false)
            {
                BattleMainWindow bv = new BattleMainWindow();
                bv.ShowDialog();
                traversed = true;
            }
            
        }
        public override string ToString()
        {
            return "Enemy Square";
        }
    }
}
