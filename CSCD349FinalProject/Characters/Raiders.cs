using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Characters
{
    class Raiders : ICharacter
    {
        private string name;
        private int attack;
        private int defense;

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
    }
}
