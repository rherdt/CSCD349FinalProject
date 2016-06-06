using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSCD349FinalProject.Characters
{
    class Zombies : IEnemyParty
    {
        private string name;
        private int attack;
        private int defense;
        private ImageBrush img = new ImageBrush();
        private int hp;

        public Zombies()
        {
            this.name = "Zombies";
            this.attack = 7;
            this.defense = 7;
            this.hp = 100;
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
