using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public class LogicCheckup
    {
        public LogicCheckup()
        {
            MaxMines = CalculateMaxMines();
        }

        public readonly int MaxMines;
        private Random _random = new Random();

        public Dictionary<string, bool> CheckLogic(Dictionary<string, bool> playgroundDictionary)
        {
            foreach (KeyValuePair<string, bool> entry in playgroundDictionary)
            {

                string currentButton = entry.Key;
                MineCounter minesAroundButton = new MineCounter(currentButton, playgroundDictionary);

                AdjustMines(playgroundDictionary, currentButton, minesAroundButton);
            }
            return playgroundDictionary;
        }

        private void AdjustMines(Dictionary<string, bool> playgroundDictionary, string currentButton, MineCounter minesAroundButton)
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
