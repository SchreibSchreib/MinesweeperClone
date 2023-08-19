using Minesweeper.data.classes.AbstractClasses;
using Minesweeper.data.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minesweeper
{
    public partial class GamePage : Page
    {
        public GamePage(WholeSessionData currentGameField)
        {
            InitializeComponent();
            _currentGameField = currentGameField;
            _buttonsList = _currentGameField.Buttons;
            _gridLengthCalculator = new GridLengthCalculator(_buttonsList);
            _xMaxLength = _gridLengthCalculator.CalculateX();
            _yMaxLength = _gridLengthCalculator.CalculateY();
            _undiscoveredMines = GetAllMinesOnBoard();
            _seconds = _currentGameField.CurrentPlayer.CurrentTimer.GetSeconds;
            _firstClickOfGame = true;
            SpawnGrid = GetGameGrid();
            MinesLeft.Text = _undiscoveredMines.ToString();
            Timer.Text = _seconds.ToString();
            LoadButtonsToGrid();
        }

        private WholeSessionData _currentGameField;
        private List<GameButton> _buttonsList;
        private GridLengthCalculator _gridLengthCalculator;
        private bool _firstClickOfGame;
        private int _xMaxLength;
        private int _yMaxLength;
        private int _undiscoveredMines;
        private int _seconds;

        private Grid GetGameGrid() => new GridCreator(_xMaxLength, _yMaxLength, SpawnGrid).ActualGrid;

        private void LoadButtonsToGrid()
        {
            foreach (GameButton button in _buttonsList)
            {
                SpawnGrid.Children.Add(button);
                Grid.SetColumn(button, int.Parse(button.Coordinates.AsString.Split(" ")[0]));
                Grid.SetRow(button, int.Parse(button.Coordinates.AsString.Split(" ")[1]));
                button.Click += Button_Click;
                button.MouseRightButtonUp += Button_MouseRightButtonUp;
            }
        }

        private int GetAllMinesOnBoard()
        {
            int mines = 0;
            foreach (GameButton button in _buttonsList)
            {
                if (button.Behaviour)
                {
                    mines++;
                }
            }
            return mines;
        }

        private int GetDefuses()
        {
            int defuses = 0;
            foreach (GameButton button in _buttonsList)
            {
                if (button.IsDefused)
                {
                    defuses++;
                }
            }
            return defuses;
        }

        private void UpdateGameInformation()
        {
            if (_firstClickOfGame)
            {
                _firstClickOfGame = _currentGameField.FirstClickOfGame;
                _currentGameField.CurrentPlayer.CurrentTimer.Seconds.Start();
                _currentGameField.CurrentPlayer.CurrentTimer.Seconds.Tick += Seconds_Tick; ;
            }
            MinesLeft.Text = (GetAllMinesOnBoard() - GetDefuses()).ToString();
        }

        private void Seconds_Tick(object? sender, EventArgs e)
        {
            _seconds++;
            Timer.Text = _seconds.ToString();
        }

        private void Button_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            UpdateGameInformation();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateGameInformation();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            string name = _currentGameField.CurrentPlayer.Name;
            Points newPoints = new Points();
            Difficulty currentDifficulty = _currentGameField.CurrentPlayer.CurrentDifficulty;
            Player newPlayer = new Player(name, newPoints, currentDifficulty, new TimeMeasure());
            WholeSessionData currentField = new WholeSessionData(newPlayer);
            CompleteGameBoardWindow newSession = new CompleteGameBoardWindow(currentField);
            newSession.Show();
            Closer.closeWindow(_currentGameField.Buttons[0]);
        }
    }
}
