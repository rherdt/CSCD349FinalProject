﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCD349FinalProject.Weapons
{
    class AWP : IWeapon
    {
        private int attack = 12;
        private string name = "AWP";

        public int getAttack()
        {
            return attack;
        }

        public string getName()
        {
            return name;
        }
    }
}