using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public class LogicChecker
    {
        public LogicChecker()
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
            while (minesAroundButton.MinesAround > MaxMines)
            {
                List<string> trueValues = GetTrueValues(currentButton, playgroundDictionary);
                int index = _random.Next(0, trueValues.Count);

                playgroundDictionary[trueValues[index]] = false;
                minesAroundButton.MinesAround--;
            }
        }

        private List<string> GetTrueValues( Dictionary<string, bool> playgroundDictionary)
        {
            List<string> trueValues = new List<string>();

            foreach (KeyValuePair<string, bool> entry in playgroundDictionary)
            {
                if (entry.Value)
                {
                    trueValues.Add(entry.Key);
                }
            }

            return trueValues;
        }

        private int CalculateMaxMines() => 4; // space for more logic (i.e. difficulty)
    }
}
