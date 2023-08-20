using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public static class LogicCheckup
    {
        private static Random _randomMinePicker = new Random();
        private static int _maxMines;

        public static Dictionary<string, bool> Check(Dictionary<string, bool> rearrangeMines, int maxMines)
        {
            _maxMines = maxMines;
            foreach (KeyValuePair<string, bool> entry in rearrangeMines)
            {
                string currentButton = entry.Key;
                MineCounter minesAroundButton = new MineCounter(currentButton, rearrangeMines);

                ReforgeMines(rearrangeMines, minesAroundButton);
            }
            return rearrangeMines;
        }

        private static void ReforgeMines(Dictionary<string, bool> playgroundDictionary, MineCounter minesAroundButton)
        {
            while (minesAroundButton.Count > _maxMines)
            {
                List<string> trueValues = minesAroundButton.PositionOfMines;
                int index = _randomMinePicker.Next(0, trueValues.Count);

                playgroundDictionary[trueValues[index]] = false;
                minesAroundButton.Count--;
            }
        }
        private static int CalculateMaxMines() => 3; // space for more logic (i.e. difficulty)
    }
}
