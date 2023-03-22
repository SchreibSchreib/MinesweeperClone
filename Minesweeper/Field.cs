using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xaml;

namespace Minesweeper
{
    public class Field
    {
        public Field(int längeX, int längeY)
        {
            this.playGround = fieldMap(längeX, längeY);
        }
        public Dictionary<string, bool> playGround;
        private Dictionary<string,bool> fieldMap(int x_axis,int y_axis) //spuckt mir ein Dictionary mit Feldkoordinaten aus und den dazugehörigen Bools (false - frei, true - Mine)--->Diese werden gleich über "checkLogic" auf Spielbarkeit geprüft
        {
            string maxButtons;
            Dictionary<string,bool> map = new Dictionary<string,bool>();
            for (int loader_x = 0; loader_x < x_axis; loader_x++) 
            {
                for (int loader_y = 0; loader_y < y_axis; loader_y++)
                {
                    maxButtons = loader_x + " " + loader_y;
                    Random mineGenerator = new Random();
                    bool mineOrFree = Convert.ToBoolean(mineGenerator.Next(0,2));
                    map.Add(maxButtons,mineOrFree);
                }
            }
            checkLogic(map);
            return map;
        }
        private void checkLogic(Dictionary<string, bool> playgroundDictionary)
        {
            string nameofCheckedField = "";
            int neighbourMines = 0;
            int maxMines = 5;
            int mineCount = 0;
            List<string> nameContainer = new List<string>();
            for (int iterate = 0; iterate < playgroundDictionary.Count - 1; iterate++)
            {
                nameofCheckedField = playgroundDictionary.Keys.ElementAt(iterate);
                for (int x_count = -1; x_count < 2; x_count++)
                {
                    for (int y_count = -1; y_count < 2; y_count++)
                    {
                        int[] namecode = new int[] { Convert.ToInt32(playgroundDictionary.Keys.ElementAt(iterate).Split(' ')[0]), Convert.ToInt32(playgroundDictionary.Keys.ElementAt(iterate).Split(' ')[1]) };
                        string dictKey = namecode[0] + x_count + " " + namecode[1] + y_count;
                        if (playgroundDictionary.ContainsKey(dictKey))
                        {
                            if (dictKey == Convert.ToString(namecode[0] + " " + namecode[1]))
                            {
                                continue; // wenn dictKey gleich Name des Feldes (playgroundDictionary(iterate) ---> Loop überspringen
                            }
                            else
                            {
                                if (playgroundDictionary[dictKey] == true)
                                {
                                    mineCount++;
                                    nameContainer.Add(dictKey);
                                }
                            }
                        }
                        else
                        {
                            maxMines--;
                            if (maxMines <= 0)
                            {
                                maxMines = 0;
                            }
                        }
                    }
                }
            }
            while (mineCount >= maxMines)
            {
                Random iterator = new Random();
                if (playgroundDictionary[nameContainer[iterator.Next(0, nameContainer.Count - 1)]] == true)
                {
                    playgroundDictionary[nameContainer[iterator.Next(0, nameContainer.Count - 1)]] = false;
                    mineCount--;
                }
                neighbourMines = mineCount;
            }
            Playbutton.neighbourMines.Add(nameofCheckedField, neighbourMines);
        } //Checkt ob: mehr als 5 Minen angrenzen -> schreibt diese ggf. um und erhöht auf minimal eine angrenzende Mine.
          //außerdem zählt er nochmal die angrenzenden Minen und speichert diese in "Playbutton.neighbourMines"
    }
    public class Playbutton : Button
    {
        public Playbutton(KeyValuePair<string, bool> buttonBehaviour)
        {
            this.fadingColor = new ColorAnimation(Color.FromRgb(100, 100, 100), Color.FromRgb(211, 211, 211), new Duration(new TimeSpan(5000000)));
            this.coordinates = buttonBehaviour.Key;
            this.behaviour = buttonBehaviour.Value;
            this.Background = new SolidColorBrush(Colors.LightGray);
            this.Height = 20;
            this.Width = 20;
            Click += Playbutton_Click;
            MouseLeave += Playbutton_Leave;
        }
        public static Spielbrett? currentSession { set; get; }
        public static Dictionary<string, int> neighbourMines { get; set; }
        private ColorAnimation fadingColor { set; get; }
        public string coordinates { get; }
        public bool behaviour { get; }
        private void Playbutton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Playbutton;
            if (btn?.behaviour == true) //Mine
            {
#pragma warning disable CS8604 // Mögliches Nullverweisargument.
                Closer.closeWindow(currentSession);
#pragma warning restore CS8604 // Mögliches Nullverweisargument.
            }
            else //keine Mine
            {

            }
        }
        private void Playbutton_Leave(object sender, MouseEventArgs e)
        {
            this.Background.BeginAnimation(SolidColorBrush.ColorProperty,fadingColor);
        }
    }
    public static class Closer
    {
        public static void closeWindow(Window window)
        {
            Assembly currentassembly = Assembly.GetExecutingAssembly();
            foreach (Window w in Application.Current.Windows)
            {
                if (w.GetType().Assembly == currentassembly && w == window)
                {
                    w.Close();
                }
            }
        }
    }
}
