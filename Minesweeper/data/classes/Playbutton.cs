using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Minesweeper.data.classes
{
    public class Playbutton : Button
    {
        public Playbutton(KeyValuePair<string, bool> buttonBehaviour)
        {
            coordinates = buttonBehaviour.Key.Split('-')[0];
            behaviour = buttonBehaviour.Value;
            nearbyMines = int.Parse(buttonBehaviour.Key.Split('-')[1]);
            Height = 20;
            Width = 20;
            FontWeight = FontWeights.Bold;
            if (behaviour == true)
            {
                Background = new SolidColorBrush(Colors.Red);
                thisBackgroundField = Colors.Red;
            }
            else
            {
                Background = new SolidColorBrush(Colors.LightGray);
                thisBackgroundField = Colors.LightGray;
            }
           
            Click += Playbutton_Click;
            MouseRightButtonUp += Playbutton_MouseRightButtonUp;
            MouseLeave += Playbutton_Leave;
        }
        private Color thisBackgroundField;
        private bool isClicked = false;
        private int nearbyMines { set; get; }
        public static Spielbrett? currentSession { set; get; }
        public static Dictionary<string, Playbutton> currentSessionButtons { set; get; }
        private ColorAnimation fadingColor { set; get; }
        public string coordinates { get; }
        public bool behaviour { get; set; }
        private void Playbutton_Click(object sender, RoutedEventArgs e)
        {
            isClicked = true;
            var btn = sender as Playbutton;
            if (Field.firstClick == true)
            {
                Field.firstClick = false;
                Spielbrett.timer_start();
                if (btn.behaviour == true)
                {
                    btn.behaviour = false;
                    foreach (string surroundings in getNeighbours(int.Parse(coordinates.Split(' ')[0]), int.Parse(coordinates.Split(' ')[1])))
                    {
                        if (currentSessionButtons.ContainsKey(surroundings) && surroundings != coordinates)
                        {
                            Playbutton tempButton = currentSessionButtons[surroundings];
                            tempButton.nearbyMines -= 1;
                            switch (tempButton.nearbyMines)
                            {
                                case 0:
                                    tempButton.Foreground = null;
                                    break;
                                case 1:
                                    tempButton.Foreground = new SolidColorBrush(Colors.LightGreen);
                                    break;
                                case 2:
                                    tempButton.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 3:
                                    tempButton.Foreground = new SolidColorBrush(Colors.GreenYellow);
                                    break;
                                case 4:
                                    tempButton.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 5:
                                    tempButton.Foreground = new SolidColorBrush(Colors.Orange);
                                    break;
                            }
                        }
                    }
                }
            }
            if (btn?.behaviour == true) //Mine
            {
#pragma warning disable CS8604 // Mögliches Nullverweisargument.
                Closer.closeWindow(currentSession);
#pragma warning restore CS8604 // Mögliches Nullverweisargument.
            }
            else //keine Mine
            {
                Background = new SolidColorBrush(Colors.LightSlateGray);
                thisBackgroundField = Colors.LightSlateGray;
                fadingColor = new ColorAnimation(Color.FromRgb(100, 100, 100), thisBackgroundField, new Duration(new TimeSpan(5000000)));
                Content = nearbyMines.ToString();
                CheckZeros(this, currentSessionButtons);
            }
        }
        private void Playbutton_Leave(object sender, MouseEventArgs e)
        {
            Background.BeginAnimation(SolidColorBrush.ColorProperty, fadingColor);
        }
        private void Playbutton_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (behaviour == true) //Mine
            {

            }
            else if (behaviour == false && isClicked == true)
            {

            }
            else //keine Mine
            {
                Spielbrett.lifes--;
                MessageBox.Show("Keine Mine!\n" + Spielbrett.lifes + " Leben übrig!");
            }
        }
        private void CheckZeros(Playbutton actualButton, Dictionary<string, Playbutton> mineField)
        {
            if (actualButton.nearbyMines > 0)
            {
                return;
            }
            HashSet<string> connectedFields = new HashSet<string>();
            Queue<string> fieldsToCheck = new Queue<string>();
            fieldsToCheck.Enqueue(actualButton.coordinates);
            while (fieldsToCheck.Count > 0)
            {
                string currentcheckedField = fieldsToCheck.Dequeue();
                connectedFields.Add(currentcheckedField);
                int x = int.Parse(currentcheckedField.Split(' ')[0]);
                int y = int.Parse(currentcheckedField.Split(' ')[1]);
                if (mineField.ContainsKey(currentcheckedField))
                {
                    Playbutton tempButtonforLogicCheck = mineField[currentcheckedField];
                    if (tempButtonforLogicCheck.nearbyMines == 0)
                    {
                        foreach (string coordinates in getNeighbours(x, y))
                        {
                            if (!connectedFields.Contains(coordinates) && !fieldsToCheck.Contains(coordinates))
                            {
                                fieldsToCheck.Enqueue(coordinates);
                            }
                        }
                    }
                }
            }
            foreach (string fieldKey in connectedFields)
            {
                Playbutton tempButtonForOverride = mineField[fieldKey];
                tempButtonForOverride.isClicked = true;
                tempButtonForOverride.Background = new SolidColorBrush(Colors.LightSlateGray);
                tempButtonForOverride.thisBackgroundField = Colors.LightSlateGray;
                tempButtonForOverride.fadingColor = new ColorAnimation(Color.FromRgb(100, 100, 100), thisBackgroundField, new Duration(new TimeSpan(5000000)));
                if (tempButtonForOverride.nearbyMines > 0)
                {
                    tempButtonForOverride.Content = tempButtonForOverride.nearbyMines.ToString();
                }
                mineField[fieldKey] = tempButtonForOverride;
            }
        }
        private IEnumerable<string> getNeighbours(int x, int y)
        {
            for (int xCount = x - 1; xCount <= x + 1; xCount++)
            {
                for (int yCount = y - 1; yCount <= y + 1; yCount++)
                {
                    if (currentSessionButtons.ContainsKey($"{xCount} {yCount}"))
                    {
                        yield return $"{xCount} {yCount}";
                    }
                }
            }
        }
    }
}
