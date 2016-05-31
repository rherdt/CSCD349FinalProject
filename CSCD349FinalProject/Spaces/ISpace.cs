﻿using CSCD349FinalProject.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CSCD349FinalProject.Spaces
{
    interface ISpace
    {
        Border getSpace();
        void runAction(Party user, MainWindow gameboard);

    }
}
