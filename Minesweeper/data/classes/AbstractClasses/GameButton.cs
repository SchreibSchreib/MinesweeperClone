﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Minesweeper.data.classes.AbstractClasses
{
    public abstract class GameButton : Button
    {
        protected GameButton(Coordinates coordOfButton, Dictionary<string, bool> currentGameField)
        {
            Coordinates = coordOfButton;
            IsClicked = false;
            MinesAround = new MineCounter(Coordinates.AsString, currentGameField).Count;
            CurrentGameField = currentGameField;
            Behaviour = currentGameField[Coordinates.AsString];
            Foreground = GetSolidColorBrushOfNumber();
            Background = GetSolidColorBrushOfBackGround();
            ColorOfButton = GetColorOfButton();
            FadingColor = GetColorAnimation();
            FontWeight = FontWeights.Bold;
            Click += GameButton_Click;
            MouseLeave += PlayButton_MouseLeave;
        }

        public bool IsClicked { protected get; set; }
        public int MinesAround { get; protected set; }
        public Coordinates Coordinates { get; protected set; }

        protected Dictionary<string, bool> CurrentGameField;
        protected Color ColorOfButton;
        protected bool Behaviour;
        protected ColorAnimation FadingColor;

        protected SolidColorBrush? GetSolidColorBrushOfNumber()
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

        protected abstract void GameButton_Click(object sender, RoutedEventArgs e);

        protected void PlayButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Background.BeginAnimation(SolidColorBrush.ColorProperty, FadingColor);
        }

        protected void ShowContent()
        {
            if (!IsClicked)
            {
                Content = MinesAround.ToString();
            }
        }

        public void UpDateButtonInformation()
        {
            ShowContent();
            Background = GetSolidColorBrushOfBackGround();
            ColorOfButton = GetColorOfButton();
            FadingColor = GetColorAnimation();
        }
    }
}
