using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CSCD349FinalProject.Characters
{
    class Raiders : IEnemyParty
    {
        private string name;
        private int attack;
        private int defense;
        private int hp;
        private ImageBrush img = new ImageBrush();

        public Raiders()
        {
            this.name = "Raiders";
            this.attack = 4;
            this.defense = 10;
            this.hp = 100;
            img.ImageSource = new BitmapImage(new Uri(@"../../Images/Raiders.png", UriKind.Relative));
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
