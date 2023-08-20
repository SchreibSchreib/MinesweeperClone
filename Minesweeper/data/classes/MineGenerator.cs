using System;

namespace Minesweeper.data.classes
{
    internal class MineGenerator
    {
        private Random _mineGenerator = new Random();

        public bool MineOrFree => Convert.ToBoolean(_mineGenerator.Next(0, 2));
    }
}
