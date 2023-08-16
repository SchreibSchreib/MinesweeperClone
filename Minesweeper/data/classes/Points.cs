using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    internal class Points
    {
        public Points() 
        {
        
        }

        public int CurrentPoints { get; private set; }

        public void AddPoints()
        {
            CurrentPoints += 10;
        }
    }
}
