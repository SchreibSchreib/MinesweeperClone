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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            _difficulty = new Difficulty();
            _pointEvaluator = new PointEvaluater(_difficulty);
            InitializeComponent();
        }

        private Difficulty _difficulty;
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
            _difficulty = new Difficulty(checkBox);
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

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Field currentField = new Field(20, 20);
            CompleteGameBoardWindow newGame = new CompleteGameBoardWindow(currentField, _pointEvaluator, _difficulty);
            newGame.Show();
        }

        private void leaderBoardButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
