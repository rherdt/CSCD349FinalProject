using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD349FinalProject.Characters
{
    interface IEnemyParty : ICharacter
    {
        ImageBrush GetImg();
        int getHP();
        bool TakeDamage(int amount);
    }
}
