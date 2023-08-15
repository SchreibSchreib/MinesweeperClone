﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Minesweeper.data.classes
{
    public abstract class GameButton : Button
    {
        protected GameButton(Coordinates coordOfButton, Dictionary<string, bool> currentGameField)
        {
            Coordinates = coordOfButton;
            MinesAround = new MineCounter(coordOfButton.AsString, currentGameField).Count;
            Behaviour = currentGameField[coordOfButton.AsString];
            Foreground = GetSolidColorBrushOfNumber();
            Background = GetSolidColorBrushOfBackGround();
            ColorOfButton = GetColorOfButton();
            FadingColor = GetColorAnimation();
            FontWeight = FontWeights.Bold;
            Click += GameButton_Click;
            MouseLeave += PlayButton_MouseLeave;
        }

        private void PlayButton_MouseLeave(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected Coordinates Coordinates;
        protected Color ColorOfButton;
        protected int MinesAround;
        protected bool Behaviour;
        protected bool IsClicked;
        protected ColorAnimation FadingColor;

        protected SolidColorBrush GetSolidColorBrushOfNumber()
        {
            switch (MinesAround)
            {
                case 1:
                    return new SolidColorBrush(Colors.LightGreen);
                case 2:
                    return new SolidColorBrush(Colors.Green);
                case 3:
                    return new SolidColorBrush(Colors.GreenYellow);
                case 4:
                    return new SolidColorBrush(Colors.Yellow);
                case 5:
                    return new SolidColorBrush(Colors.Orange);
                default:
                    return null;
            }
        }
        protected SolidColorBrush GetSolidColorBrushOfBackGround()
        {
            if (!IsClicked)
            {
                return new SolidColorBrush(Colors.LightGray);
            }
            return new SolidColorBrush(Colors.LightSlateGray);
        }
        protected Color GetColorOfButton()
        {
            if (!IsClicked)
            {
                return Colors.LightGray;
            }
            return Colors.LightSlateGray;
        }
        protected ColorAnimation GetColorAnimation()
        {
            if (!IsClicked)
            {
                return new ColorAnimation(Color.FromRgb(100, 100, 100), ColorOfButton, new Duration(new TimeSpan(5000000)));
            }
            return new ColorAnimation(Color.FromRgb(100, 100, 100), ColorOfButton, new Duration(new TimeSpan(5000000)));
        }

        protected void GameButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Playbutton_Leave(object sender, MouseEventArgs e)
        {
            Background.BeginAnimation(SolidColorBrush.ColorProperty, FadingColor);
        }
    }
}
