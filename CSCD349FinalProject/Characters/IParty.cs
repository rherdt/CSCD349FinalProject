using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD349FinalProject.Characters
{
    interface IParty
    {
        int GetPartyHealth();
        void Damage(int hp);
        int GetPartyAttack();
        int GetPartyDefense();
        int GetLevel();
        ImageBrush GetImg();
        void LevelUp();
    }
}
