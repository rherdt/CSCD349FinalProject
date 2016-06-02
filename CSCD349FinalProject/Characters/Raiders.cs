using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD349FinalProject.Characters
{
    class Raiders : IEnemyParty
    {
        private string name;
        private int attack;
        private int defense;
        private ImageBrush img = new ImageBrush();

        public Raiders()
        {
            this.name = "Raiders";
            this.attack = 4;
            this.defense = 10;
        }

        public string GetName()
        {
            return name;
        }

        public int GetAttack()
        {
            return attack;
        }

        public int GetDefense()
        {
            return defense;
        }

        public ImageBrush GetImg()
        {
            return img;
        }
    }
}
