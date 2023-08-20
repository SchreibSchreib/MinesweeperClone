using System;
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
            IsClickable = true;
            CurrentGameField = currentGameField;
            Behaviour = currentGameField[Coordinates.AsString];
            Background = GetSolidColorBrushOfBackGround();
            ColorOfButton = GetColorOfButton();
            FadingColor = GetColorAnimation();
            FontWeight = FontWeights.Bold;
            Click += GameButton_Click;
            MouseRightButtonUp += GameButton_MouseRightButtonUp;
            MouseLeave += PlayButton_MouseLeave;
            Height = 20;
            Width = 20;
        }

        public bool IsClicked { get; set; }
        public bool Behaviour { get; set; }
        public int MinesAround { get; protected set; }
        public Coordinates Coordinates { get; protected set; }
        public bool IsDefused { get; protected set; }
        public bool IsClickable { get; protected set; }

        protected Dictionary<string, bool> CurrentGameField;
        protected Color ColorOfButton;
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
            if (!IsClicked && !IsDefused)
            {
                return new SolidColorBrush(Colors.LightGray);
            }
            else if (!IsClicked && IsDefused)
            {
                return new SolidColorBrush(Colors.YellowGreen);
            }
            return new SolidColorBrush(Colors.LightSlateGray);
        }

        protected Color GetColorOfButton()
        {
            SolidColorBrush currentColor = GetSolidColorBrushOfBackGround();
            return currentColor.Color;
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

        protected void GameButton_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ToggleDefuse();
            UpDateButtonInformation();
        }

        protected void PlayButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Background.BeginAnimation(SolidColorBrush.ColorProperty, FadingColor);
        }

        protected void ShowContent()
        {
            if (IsClicked && !IsDefused)
            {
                MinesAround = new MineCounter(Coordinates.AsString, CurrentGameField).Count;
                Foreground = GetSolidColorBrushOfNumber();
                Content = MinesAround.ToString();
            }
            else if (IsDefused)
            {

            }
        }

        protected void ToggleDefuse()
        {
            IsDefused = !IsDefused;
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
