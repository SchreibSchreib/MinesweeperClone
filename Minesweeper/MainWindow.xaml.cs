using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_X_Direction_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox? boxClicked = sender as TextBox;
            if (boxClicked?.Name == "TextBox_Y_Direction")
            {
                if (boxClicked.Text == "Felder Y")
                {
                    boxClicked.Text = null;
                }
            }
            else
            {
                if (boxClicked?.Text == "Felder X")
                {
                    boxClicked.Text = null;
                }
            }
        }

        private void TextBox_X_Direction_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox? boxLostFocus = sender as TextBox;
#pragma warning disable CS8602 // Dereferenzierung eines möglichen Nullverweises.
            if (boxLostFocus.Text.Contains(" ") || boxLostFocus.Text.Length == 0 || boxLostFocus.Text == null || Convert.ToInt32(boxLostFocus.Text) < 10 || Convert.ToInt32(boxLostFocus.Text) > 50)
            {
                if (boxLostFocus.Name == "TextBox_Y_Direction")
                {
                    if ((boxLostFocus.Text.Contains(" ") || boxLostFocus.Text.Length == 0 || boxLostFocus.Text == null || Convert.ToInt32(boxLostFocus.Text) < 10 || Convert.ToInt32(boxLostFocus.Text) > 50 || boxLostFocus.Text.Length == 0 || boxLostFocus.Text == null))
                    { 
                        MessageBox.Show("Aktuell werden nur Zahlen zwischen 10 und 50 supportet."); 
                    }
                    boxLostFocus.Text = "Felder Y";
                }
                else
                {
#pragma warning disable CS8602 // Dereferenzierung eines möglichen Nullverweises.
                    if (boxLostFocus.Text.Contains(' ') || boxLostFocus.Text.Length == 0 || boxLostFocus.Text == null || Convert.ToInt32(boxLostFocus.Text) < 10 || Convert.ToInt32(boxLostFocus.Text) > 50)
                    {
                        MessageBox.Show("Aktuell werden nur Zahlen zwischen 10 und 50 supportet.");
                    }
#pragma warning restore CS8602 // Dereferenzierung eines möglichen Nullverweises.
                    boxLostFocus.Text = "Felder X";
                }
            }
#pragma warning restore CS8602 // Dereferenzierung eines möglichen Nullverweises.
        }
        private void NumberValidation(object sender, TextCompositionEventArgs e) 
        {
            Regex checkOnlyNumbers = new Regex("[^0-9]+");
            e.Handled = checkOnlyNumbers.IsMatch(e.Text);
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            Field.firstClick = true;
            Field startField = new Field(Convert.ToInt32(TextBox_X_Direction.Text),Convert.ToInt32(TextBox_Y_Direction.Text));
            Dictionary<string,Playbutton> loadDictionary = new Dictionary<string,Playbutton>();
            List<Playbutton> playButtons= new List<Playbutton>();
            foreach (KeyValuePair<string,bool> fieldKey in Field.playGround)
            {
                Playbutton loader = new Playbutton(fieldKey);
                playButtons.Add(loader);
                loadDictionary.Add(loader.coordinates, loader);
            }
            Playbutton.currentSessionButtons = loadDictionary;
            Spielbrett newSession = new Spielbrett(playButtons, Convert.ToInt32(TextBox_X_Direction.Text), Convert.ToInt32(TextBox_Y_Direction.Text));
            Playbutton.currentSession = newSession;
            newSession.Show();
        }

        private void leaderBoardButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
