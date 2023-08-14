using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public class FieldGenerator
    {
        private MineGenerator _mineGenerator = new MineGenerator();

        private LogicChecker _checkFieldLogic = new LogicChecker();

        public Dictionary<string, bool> GenerateFieldMap(int x_axis, int y_axis)
        {
            var map = new Dictionary<string, bool>();
            for (int loader_x = 0; loader_x < x_axis; loader_x++)
            {
                for (int loader_y = 0; loader_y < y_axis; loader_y++)
                {
                    bool isMine = _mineGenerator.MineOrFree;
                    map.Add(loader_x + " " + loader_y, isMine);
                }
            }
            map = _checkFieldLogic.CheckLogic(map);
            
            return map;
        }


    }
}
