﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    internal static class Points
    {
        public static int CurrentPoints { get; private set; }

        public static void Add()
        {
            CurrentPoints += 10;
        }
    }
}
