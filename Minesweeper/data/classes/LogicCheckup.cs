using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public class LogicCheckup
    {
        public LogicCheckup(Dictionary<string, bool> playgroundDitctionary)
        {
            GetPlaygroundDictionary = CheckLogic(playgroundDitctionary);
            MaxMines = CalculateMaxMines();
        }

        public readonly int MaxMines;
        private Random _random = new Random();
        public Dictionary<string, bool> GetPlaygroundDictionary { get; private set; }

        private Dictionary<string, bool> CheckLogic(Dictionary<string, bool> rearrangeMines)
        {
            foreach (KeyValuePair<string, bool> entry in rearrangeMines)
            {

                string currentButton = entry.Key;
                MineCounter minesAroundButton = new MineCounter(currentButton, rearrangeMines);

                ReforgeMines(rearrangeMines, minesAroundButton);
            }
            return rearrangeMines;
        }

        private void ReforgeMines(Dictionary<string, bool> playgroundDictionary, MineCounter minesAroundButton)
        {
            while (minesAroundButton.Count > MaxMines)
            {
                List<string> trueValues = minesAroundButton.PositionOfMines;
                int index = _random.Next(0, trueValues.Count);

                playgroundDictionary[trueValues[index]] = false;
                minesAroundButton.Count--;
            }
        }

        private int CalculateMaxMines() => 4; // space for more logic (i.e. difficulty)
    }
}
