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

        public override void runAction(Party user)
        {
            //could use this to deal with change state?
            //could use this to deal with change state?
            //redirect back onto playing board
            //traversed = true;
            BattleMainWindow bv = new BattleMainWindow(user, enemy);
            bv.Show();
        }

        public override string ToString()
        {
            return "Enemy Square";
        }
    }
}
