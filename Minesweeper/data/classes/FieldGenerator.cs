using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public class FieldGenerator
    {
        public FieldGenerator(int highestXAxis, int highestYAxis)
        {
            _highestXAxis = highestXAxis;
            _highestYAxis = highestYAxis;
            PlayGround = CreatePrototypePlayGround();
        }

        public Dictionary<string, bool> PlayGround { get; private set; }

        private MineGenerator _mineGenerator = new MineGenerator();
        private int _highestXAxis;
        private int _highestYAxis;

        private Dictionary<string, bool> CreatePrototypePlayGround()
        {
            var map = new Dictionary<string, bool>();
            for (int xCoordinates = 0; xCoordinates < _highestXAxis; xCoordinates++)
            {
                for (int yCoordinates = 0; yCoordinates < _highestYAxis; yCoordinates++)
                {
                    bool isMine = _mineGenerator.MineOrFree;
                    map.Add(new Coordinates(xCoordinates, yCoordinates).AsString, isMine);
                }
            }
            return map;
        }
    }
}
