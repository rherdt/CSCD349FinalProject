using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CSCD349FinalProject.Characters
{
    class Mutants : IEnemyParty
    {
        private string name;
        private int attack;
        private int defense;
        private int hp;
        private ImageBrush img = new ImageBrush();

        public Mutants()
        {
            this.name = "Mutants";
            this.attack = 10;
            this.defense = 4;
            this.hp = 100;
            img.ImageSource = new BitmapImage(new Uri(@"../../Images/Mutants.png", UriKind.Relative));
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

        public int getHP()
        {
            return hp;
        }
        public bool TakeDamage(int amount)
        {
            hp = hp - amount;
            if (hp < 1)
            {
                return true;
            }
            return false;
        }

        public ImageBrush GetImg()
        {
            return img;
        }
    }
}
