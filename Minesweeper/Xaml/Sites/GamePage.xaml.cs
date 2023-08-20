using Minesweeper.data.classes.AbstractClasses;
using Minesweeper.data.classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Minesweeper.data.Scores;

namespace Minesweeper
{
    public partial class GamePage : Page
    {
        public GamePage(WholeSessionData currentGameField)
        {
            InitializeComponent();
            _currentSession = currentGameField;
            _buttonsList = _currentSession.Buttons;
            _gridLengthCalculator = new GridLengthCalculator(_buttonsList);
            _xMaxLength = _gridLengthCalculator.CalculateX();
            _yMaxLength = _gridLengthCalculator.CalculateY();
            _undiscoveredMines = GetAllMinesOnBoard();
            _seconds = _currentSession.CurrentPlayer.CurrentTimer.GetSeconds;
            _firstClickOfGame = true;
            SpawnGrid = GetGameGrid();
            MinesLeft.Text = _undiscoveredMines.ToString();
            Timer.Text = _seconds.ToString();
            LoadButtonsToGrid();
        }

        private WholeSessionData _currentSession;
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

        private void UpdateGameInformation(GameButton clickedButton)
        {
            if (_firstClickOfGame && !clickedButton.Behaviour)
            {
                _firstClickOfGame = _currentSession.FirstClickOfGame;
                _currentSession.CurrentPlayer.CurrentTimer.Seconds.Start();
                _currentSession.CurrentPlayer.CurrentTimer.Seconds.Tick += Seconds_Tick; ;
            }
            else if (IsGameFinished() || clickedButton.Behaviour)
            {
                EvaluateWinOrLose(clickedButton);
                _currentSession.CurrentPlayer.CurrentTimer.Stop(_currentSession.CurrentPlayer);
                LeaderBoardWriter.WritePlayerList(_currentSession.CurrentPlayer);
                if (clickedButton.Behaviour)
                {
                    MainWindow backToMain = new MainWindow();
                    backToMain.Show();
                    Closer.closeWindow(clickedButton);
                }
            }
            MinesLeft.Text = (GetAllMinesOnBoard() - GetDefuses()).ToString();
        }

        private bool IsGameFinished()
        {
            int clickedButtons = 0;
            int ButtonsToClickForWin = _buttonsList.Count - GetAllMinesOnBoard();
            foreach (GameButton button in _buttonsList)
            {
                if (button.IsClicked)
                {
                    clickedButtons++;
                }
            }
            return clickedButtons == ButtonsToClickForWin;
        }

        private void Seconds_Tick(object? sender, EventArgs e)
        {
            _seconds++;
            Timer.Text = _seconds.ToString();
        }

        private void Button_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var clickedButton = sender as GameButton;
            if (clickedButton != null)
            {
                UpdateGameInformation(clickedButton);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as GameButton;
            if (clickedButton != null)
            {
                UpdateGameInformation(clickedButton);
            }

        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            string name = _currentSession.CurrentPlayer.Name;
            Points newPoints = new Points();
            Difficulty currentDifficulty = _currentSession.CurrentPlayer.CurrentDifficulty;
            Player newPlayer = new Player(name, newPoints, currentDifficulty, new TimeMeasure());
            WholeSessionData currentField = new WholeSessionData(newPlayer);
            CompleteGameBoardWindow newSession = new CompleteGameBoardWindow(currentField);
            newSession.Show();
            Closer.closeWindow(_currentSession.Buttons[0]);
        }

        private void EvaluateWinOrLose(GameButton clickedButton)
        {
            if (clickedButton.Behaviour)
            {
                string path = "/data/graphics/LoseFace.png";
                resetButton.Content = new Image() { Source = new BitmapImage(new Uri(path, UriKind.Relative)) };
                MessageBox.Show("You Lose :(");
            }
            else
            {
                string path = "/data/graphics/WinFace.png";
                resetButton.Content = new Image() { Source = new BitmapImage(new Uri(path, UriKind.Relative)) };
                MessageBox.Show("You Win :)");
            }
        }
    }
}
