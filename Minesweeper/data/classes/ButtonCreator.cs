using Minesweeper.data.classes.AbstractClasses;
using Minesweeper.data.classes.InheritedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    internal class ButtonCreator
    {
        public ButtonCreator(Dictionary<string, bool> currentGameField, WholeSessionData fieldInformation)
        {
            _currentGameField = currentGameField;
            _fieldInformation = fieldInformation;
            CreateMineButtons();
        }

        public List<GameButton> GameButtons = new List<GameButton>();

        private Dictionary<string, bool> _currentGameField;
        private WholeSessionData _fieldInformation;

        private void CreateMineButtons()
        {
            foreach (KeyValuePair<string, bool> kvp in _currentGameField)
            {
                if (!kvp.Value)
                {
                    CreateNoMineButtons(kvp);
                }
                else
                {
                    CreateMineButtons(kvp);
                }
            }
        }

        private void CreateNoMineButtons(KeyValuePair<string, bool> kvp)
        {
            int xCoords = int.Parse(kvp.Key.Split(' ')[0]);
            int yCoords = int.Parse(kvp.Key.Split(' ')[1]);
            Coordinates newButtonCoords = new Coordinates(xCoords, yCoords);
            GameButtons.Add(new ButtonNoMine(newButtonCoords, _currentGameField, _fieldInformation));
        }
        private void CreateMineButtons(KeyValuePair<string, bool> kvp)
        {
            int xCoords = int.Parse(kvp.Key.Split(' ')[0]);
            int yCoords = int.Parse(kvp.Key.Split(' ')[1]);
            Coordinates newButtonCoords = new Coordinates(xCoords, yCoords);
            GameButtons.Add(new ButtonIsMine(newButtonCoords, _currentGameField, _fieldInformation));
        }
    }
}
