using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Characters
{
    interface IParty
    {
        int GetPartyAttack();
        int GetPartyDefense();
        int GetLevel();
        void LevelUp();
    }
}
