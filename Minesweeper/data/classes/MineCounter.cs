using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    internal class MineCounter
    {
        public MineCounter(string currentButton, Dictionary<string, bool> gameField)
        {
            _currentButton = currentButton;
            GameField = gameField;
            MinesAround = CountMinesAround();
        }

        public int MinesAround;
        private string _currentButton;
        private Dictionary<string, bool> GameField;


        private int CountMinesAround()
        {
            int mineCount = 0;
            int[] searchScope = GetSearchScope(_currentButton);

            for (int x_axis = searchScope[0]; x_axis <= searchScope[2]; x_axis++)
            {
                for (int y_axis = searchScope[1]; y_axis <= searchScope[3]; y_axis++)
                {
                    string position = x_axis + " " + y_axis;

                    if (IsValidField(position))
                    {
                        continue;
                    }
                    else
                    {
                        mineCount++;
                    }
                }
            }
            return mineCount;
        }

        private int[] GetSearchScope(string currentButton)
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

        private bool IsValidField(string posInDictionary)
            => posInDictionary == _currentButton || !GameField.ContainsKey(posInDictionary);
    }
}
