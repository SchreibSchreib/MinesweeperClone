using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public class Points
    {
        public Points()
        {
        }
        public int Current { get; set; }

        public void Add()
        {
            Current += 3;
        }
    }
}
