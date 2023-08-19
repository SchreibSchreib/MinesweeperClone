using System.Collections.Generic;
using Minesweeper.data.classes.InheritedClasses;
using Minesweeper.data.classes.AbstractClasses;

namespace Minesweeper.data.classes
{
    internal class BroadSearchAlgorithm
    {
        public BroadSearchAlgorithm(GameButton actualButton, Dictionary<string, bool> mineField, List<GameButton> buttonList, WholeSessionData wholeSessionData)
        {
            _wholeSessionData = wholeSessionData;
            _actualButton = actualButton;
            _mineField = mineField;
            _buttonList = buttonList;
        }

        private WholeSessionData _wholeSessionData;
        private GameButton _actualButton;
        private Dictionary<string, bool> _mineField;
        private List<GameButton> _buttonList;
        private Queue<string> _buttonsToCheck = new Queue<string>();
        private HashSet<string> _connectedButtonNames = new HashSet<string>();

        public void CheckForButtonsWithZeroMines()
        {
            LoadActualButtonToQueue();

            while (_buttonsToCheck.Count > 0)
            {
                LoadActualButtonToHashset();
            }
        }

        private void LoadActualButtonToQueue() => _buttonsToCheck.Enqueue(_actualButton.Coordinates.AsString);

        private void LoadActualButtonToHashset()
        {
            string currentButtonCoordinates = _buttonsToCheck.Dequeue();
            _connectedButtonNames.Add(currentButtonCoordinates);
            int x = int.Parse(currentButtonCoordinates.Split(' ')[0]);
            int y = int.Parse(currentButtonCoordinates.Split(' ')[1]);
            SearchForNeighbourButtonsWithZeroMines(currentButtonCoordinates, x, y);
        }

        private void SearchForNeighbourButtonsWithZeroMines(string currentButtonCoordinates, int xCoords, int yCoords)
        {
            if (_mineField.ContainsKey(currentButtonCoordinates))
            {
                bool areZeroMinesAround = new MineCounter(currentButtonCoordinates, _mineField).Count == 0;
                if (areZeroMinesAround)
                {
                    foreach (string coordinatesOfNeighbourButtons in GetNeighbours(xCoords, yCoords))
                    {
                        if (!_connectedButtonNames.Contains(coordinatesOfNeighbourButtons)
                         && !_buttonsToCheck.Contains(coordinatesOfNeighbourButtons))
                        {
                            _buttonsToCheck.Enqueue(coordinatesOfNeighbourButtons);
                        }
                    }
                }
            }
        }

        private IEnumerable<string> GetNeighbours(int xCoords, int yCoords)
        {
            for (int xCount = xCoords - 1; xCount <= xCoords + 1; xCount++)
            {
                for (int yCount = yCoords - 1; yCount <= yCoords + 1; yCount++)
                {
                    if (_mineField.ContainsKey($"{xCount} {yCount}"))
                    {
                        yield return $"{xCount} {yCount}";
                    }
                }
            }
        }

        public void ToggleButtons()
        {
            foreach (string buttonName in _connectedButtonNames)
            {
                foreach (GameButton gameButton in _buttonList)
                {
                    if (gameButton.Coordinates.AsString == buttonName && !gameButton.IsDefused)
                    {
                        ClickHandler clickHandler = new ClickHandlerNoMine(gameButton, _wholeSessionData);
                        clickHandler.Handle();
                    }
                }
            }
        }
    }
}