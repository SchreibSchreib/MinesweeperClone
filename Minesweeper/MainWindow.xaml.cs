using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
using Minesweeper.data.classes;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            _difficulty = "medium";
            _pointEvaluator = new PointEvaluater(_difficulty);
            InitializeComponent();
        }

        private string _difficulty;
        private PointEvaluater _pointEvaluator;

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox == null)
            {
                return;
            }

            SetDifficulty(checkBox);
            UncheckOtherCheckBoxes(checkBox);
        }

        private void SetDifficulty(CheckBox checkBox)
        {
            _difficulty = new Difficulty(checkBox).GetDifficulty;
        }

        private void UncheckOtherCheckBoxes(CheckBox checkBox)
        {
            Panel? parentPanel = PanelFinder.GetParentPanel(checkBox);
            if (parentPanel == null)
            {
                Debug.WriteLine("No Panel as Parent found.");
                return;
            }
            List<CheckBox> checkBoxes = ObjectFinder.GetCheckBoxes(parentPanel);
            foreach (CheckBox box in checkBoxes)
            {
                Debug.WriteLine($"{box.Name} found.  Value: {box.IsChecked}");
                if (box != checkBox)
                {
                    box.IsChecked = false;
                }
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void leaderBoardButton_Click(object sender, RoutedEventArgs e)
        {

        }


        //        private void startButton_Click(object sender, RoutedEventArgs e)
        //        {
        //            Field.FirstClickOfGame = true;
        //            Field startField = new Field(Convert.ToInt32(TextBox_X_Direction.Text),Convert.ToInt32(TextBox_Y_Direction.Text));
        //            Dictionary<string,Playbutton> loadDictionary = new Dictionary<string,Playbutton>();
        //            List<Playbutton> playButtons= new List<Playbutton>();
        //            foreach (KeyValuePair<string,bool> fieldKey in startField.PlayGround)
        //            {
        //                Playbutton loader = new Playbutton(fieldKey);
        //                playButtons.Add(loader);
        //                loadDictionary.Add(loader.coordinates, loader);
        //            }
        //            Playbutton.currentSessionButtons = loadDictionary;
        //            Spielbrett newSession = new Spielbrett(playButtons, Convert.ToInt32(TextBox_X_Direction.Text), Convert.ToInt32(TextBox_Y_Direction.Text));
        //            Playbutton.currentSession = newSession;
        //            newSession.Show();
        //        }
    }
}
