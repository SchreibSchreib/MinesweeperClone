using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public class MineCounter
    {
        public MineCounter(string currentButton, Dictionary<string, bool> gameField)
        {
            CurrentButton = currentButton;
            GameField = gameField;
            Count = CountMinesAround();
        }

        private List<string> _positionOfMines = new List<string>();

        public List<string> PositionOfMines
        {
            get { return _positionOfMines; }
        }

        public int Count { get; set; }
        public readonly string CurrentButton;
        private Dictionary<string, bool> GameField;


        private int CountMinesAround()
        {
            int mineCount = 0;
            int[] searchScope = ScopeFinder.GetSearchScope(CurrentButton);

            for (int x_axis = searchScope[0]; x_axis <= searchScope[2]; x_axis++)
            {
                for (int y_axis = searchScope[1]; y_axis <= searchScope[3]; y_axis++)
                {
                    string position = x_axis + " " + y_axis;

                    if (new FieldCoordsValidator(position,GameField).IsMineAndPositionOfField)
                    {
                        PositionOfMines.Add(position);
                        mineCount++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return mineCount;
        }
    }
}
