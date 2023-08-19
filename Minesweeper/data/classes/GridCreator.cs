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
        public GridCreator(int maxXCoords, int maxYCoords, Grid actualGrid)
        {
            _columns = maxYCoords;
            _rows = maxXCoords;
            ActualGrid = actualGrid;
            DefineSpawnGrid();
        }

        public Grid ActualGrid { get; private set; }

        private int _columns;
        private int _rows;

        private void DefineSpawnGrid()
        {
            for (int row = 0; row <= _rows; row++)
            {
                ActualGrid.RowDefinitions.Add(new RowDefinition());

                for (int column = 0; column <= _columns; column++)
                {
                    ActualGrid.ColumnDefinitions.Add(new ColumnDefinition());
                }
            }

        }
    }
}
