using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Minesweeper.data.classes;
using Minesweeper.data.classes.AbstractClasses;

namespace Minesweeper
{
    /// <summary>
    /// Interaktionslogik für Spielbrett.xaml
    /// </summary>
    public partial class GameBoard : Window
    {
        public GameBoard(Field currentGameField, PointEvaluater pointEvaluaterThisSession, Difficulty difficultyThisSession)
        {
            _currentGameField = currentGameField;
            _buttonsList = currentGameField.Buttons;
            _gridLengthCalculator = new GridLengthCalculator(_buttonsList);
            _xMaxLength = _gridLengthCalculator.CalculateX();
            _yMaxLength = _gridLengthCalculator.CalculateY();
            _gridForMines = GetGameGrid();
            LoadButtonsToGrid();
            InitializeComponent();
        }

        private Field _currentGameField;
        private List<GameButton> _buttonsList;
        private GridLengthCalculator _gridLengthCalculator;
        private Grid _gridForMines;
        private int _xMaxLength;
        private int _yMaxLength;

        private Grid GetGameGrid() => new GridCreator(_xMaxLength, _yMaxLength).CurrentGrid;

        private void LoadButtonsToGrid()
        {
            foreach (GameButton button in _buttonsList)
            {
                _gridForMines.Children.Add(button);
                Grid.SetRow(button, int.Parse(button.Coordinates.AsString.Split(" ")[0]));
                Grid.SetColumn(button, int.Parse(button.Coordinates.AsString.Split(" ")[1]));
            }
        }
    }
}






//public Spielbrett(List<Playbutton> playButtons,int buttonsX,int buttonsY)
//{
//    this.buttonsX = buttonsX;
//    this.buttonsY = buttonsY;
//    this.buttons = playButtons;
//    InitializeComponent();
//}
//private List<Playbutton> buttons;
//private int buttonsX;
//private int buttonsY;

//private void SpawnGrid_Loaded(object sender, RoutedEventArgs e)
//{


//    foreach (Playbutton button in buttons)
//    {
//        SpawnGrid.Children.Add(button);
//        Grid.SetRow(button, Convert.ToInt32(button.coordinates.Split(' ')[0]));
//        Grid.SetColumn(button, Convert.ToInt32(button.coordinates.Split(' ')[1]));
//    }

//}
//public void resetButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
//{
//    Image tempImage = resetButtonImage;
//    tempImage.Source = new BitmapImage(new Uri("/data/graphics/ScaredFace.png", UriKind.Relative));
//    resetButton.Content = tempImage;
//    e.Handled = true;

//}
//public void resetButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
//{
//    Image tempImage = resetButtonImage;
//    tempImage.Source = new BitmapImage(new Uri("/data/graphics/MinesweeperFace.png", UriKind.Relative));
//    resetButton.Content = tempImage;
//}

//public void resetButtonImage_MouseLeave(object sender, MouseEventArgs e)
//{
//    Image tempImage = resetButtonImage;
//    tempImage.Source = new BitmapImage(new Uri("/data/graphics/MinesweeperFace.png", UriKind.Relative));
//    resetButton.Content = tempImage;
//}

//private void minesLeft_Loaded(object sender, RoutedEventArgs e)
//{
//    int totalmines = 0;
//    foreach (Playbutton mineCounter in buttons)
//    {
//        if (mineCounter.behaviour == true)
//        {
//            totalmines++;
//        }
//    }
//    minesLeft.Text = totalmines.ToString();
//}

//private void timer_Loaded(object sender, RoutedEventArgs e)
//{
//    timer.Text = displayTime.ToString();
//}
//public static void timer_start()
//{
//    ticker.Start();
//}
//private void Ticker_Tick(object? sender, EventArgs e)
//{
//    displayTime++;
//    timer.Text = displayTime.ToString();
//}
