using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public class Coordinates
    {
        public Coordinates(int xCoords, int yCoords)
        {
            _xCoords = xCoords;
            _yCoords = yCoords;
            AsString = _coordinatesAsString();
        }

        private int _xCoords;
        private int _yCoords;
        public string AsString { get; private set; }

        private string _coordinatesAsString() => _xCoords + " " + _yCoords;
    }
}
