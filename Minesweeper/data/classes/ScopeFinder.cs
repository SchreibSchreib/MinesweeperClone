using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public static class ScopeFinder
    {
        public static int[] GetSearchScope(string currentButton)
        {
            int[] coordinates = currentButton.Split(' ').Select(int.Parse).ToArray();
            int x = coordinates[0];
            int y = coordinates[1];

            int xMin = Math.Max(x - 1, 0);
            int xMax = Math.Min(x + 1, int.MaxValue);
            int yMin = Math.Max(y - 1, 0);
            int yMax = Math.Min(y + 1, int.MaxValue);

            return new int[] { xMin, yMin, xMax, yMax };
        }
    }
}
