﻿using System;
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
            InitializeComponent();
            _currentGameField = currentGameField;
            _buttonsList = currentGameField.Buttons;
            _gridLengthCalculator = new GridLengthCalculator(_buttonsList);
            _xMaxLength = _gridLengthCalculator.CalculateX();
            _yMaxLength = _gridLengthCalculator.CalculateY();
            SpawnGrid = GetGameGrid();
            LoadButtonsToGrid();
        }

        private Field _currentGameField;
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