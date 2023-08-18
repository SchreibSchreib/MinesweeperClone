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
    /// <summary>
    /// Interaktionslogik für GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage(WholeSessionData currentGameField)
        {
            InitializeComponent();
            //_currentGameField = currentGameField;  ???
            _buttonsList = currentGameField.Buttons;
            _gridLengthCalculator = new GridLengthCalculator(_buttonsList);
            _xMaxLength = _gridLengthCalculator.CalculateX();
            _yMaxLength = _gridLengthCalculator.CalculateY();
            SpawnGrid = GetGameGrid();
            LoadButtonsToGrid();
        }

        //private Field _currentGameField; ???
        private List<GameButton> _buttonsList;
        private GridLengthCalculator _gridLengthCalculator;
        private int _xMaxLength;
        private int _yMaxLength;

        private Grid GetGameGrid() => new GridCreator(_xMaxLength, _yMaxLength, SpawnGrid).ActualGrid;

        private void LoadButtonsToGrid()
        {
            foreach (GameButton button in _buttonsList)
            {
                SpawnGrid.Children.Add(button);
                Grid.SetRow(button, int.Parse(button.Coordinates.AsString.Split(" ")[0]));
                Grid.SetColumn(button, int.Parse(button.Coordinates.AsString.Split(" ")[1]));
            }
        }
    }
}
