using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Minesweeper.data.classes
{
    internal class GridCreator
    {
        public GridCreator(int maxXCoords, int maxYCoords)
        {
            _columns = maxXCoords;
            _rows = maxYCoords;
            CurrentGrid = DefineSpawnGrid();
        }

        public Grid CurrentGrid { get; private set; }

        private int _columns;
        private int _rows;

        public Grid DefineSpawnGrid()
        {
            Grid newGrid = new Grid();
            for (int row = 0; row < _rows; row++)
            {
                newGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int column = 0; column < _columns; column++)
            {
                newGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            return newGrid;
        }
    }
}
