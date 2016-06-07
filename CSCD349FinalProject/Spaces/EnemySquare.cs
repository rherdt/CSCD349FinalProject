using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using BattleView;
using CSCD349FinalProject.Characters;
using System.Windows;

namespace CSCD349FinalProject.Spaces
{
    class EnemySquare: ASpace
    {
        public override void runAction(Party user, MainWindow gameboard)
        {
            if(traversed == false)
            {
                BattleMainWindow bv = new BattleMainWindow();
                traversed = true;
                bv.User = user;
                bv.Floor = gameboard.GetFloor();
                bv.ShowDialog();

                gameboard.InitializeInventory();
                gameboard.RedrawInventory();
            }
        }
        public override string ToString()
        {
            return "Enemy Square";
        }
    }
}
