using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCD349FinalProject.Characters;
using CSCD349FinalProject.GamePlay.BattleView;

namespace CSCD349FinalProject.States
{
    class BattleState: IState
    {
        public void RunBattle(Party goodguys, Party badguys)
        {
            BattleWindow battle = new BattleWindow(goodguys.getImg(),badguys.getImg());

            battle.Show();
        }
        public void BattleSequence(Party goodguys, Party badguys)
        {
            
        }
    }
}
