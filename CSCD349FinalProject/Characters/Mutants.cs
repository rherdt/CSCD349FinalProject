using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD349FinalProject.Characters
{
    class Mutants : IEnemyParty
    {
        private string name;
        private int attack;
        private int defense;
        private ImageBrush img = new ImageBrush();

        public Mutants()
        {
            this.name = "Mutants";
            this.attack = 10;
            this.defense = 4;
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
