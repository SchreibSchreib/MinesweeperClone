using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    internal class MineGenerator
    {
        private Random _mineGenerator = new Random();

        public bool MineOrFree => Convert.ToBoolean(_mineGenerator.Next(0, 2));
    }
}
