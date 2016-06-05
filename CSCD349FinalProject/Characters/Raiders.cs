using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Characters
{
    class Raiders : IBadGuy
    {
        private string name;
        private int attack;
        private int defense;
        private int hp;

        public Raiders()
        {
            this.name = "Raiders";
            this.attack = 4;
            this.defense = 10;
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

        public int GetHP()
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
    }
}
