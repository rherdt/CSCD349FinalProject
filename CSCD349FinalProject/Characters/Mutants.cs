using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Characters
{
    class Mutants : IBadGuy
    {
        private string name;
        private int attack;
        private int defense;
        private int hp;

        public Mutants()
        {
            this.name = "Mutants";
            this.attack = 10;
            this.defense = 4;
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
