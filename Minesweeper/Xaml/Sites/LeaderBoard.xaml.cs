using Minesweeper.data.classes;
using Minesweeper.data.Scores;
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

namespace Minesweeper.Xaml.Sites
{
    /// <summary>
    /// Interaktionslogik für LeaderBoard.xaml
    /// </summary>
    public partial class LeaderBoard : Page
    {
        public LeaderBoard()
        {
            _playerData = LeaderboardReader.GetPlayerList();
            SortData();
            _splittedData = SplitData();
            InitializeComponent();
            WriteToLeaderBoard();
        }

        private List<Player> _playerData;
        private string[][] _splittedData;

        private void SortData()
        {
            _playerData = _playerData.OrderByDescending(player => player.CalculateHisPoints()).ToList();
        }

        private string[][] SplitData()
        {
            string[][] splittedData = new string[10][];
            for (int i = 0; i < 10; i++)
            {
                string[] singlePlayerData = new string[3];
                singlePlayerData[0] = _playerData[i].Name;
                singlePlayerData[1] = _playerData[i].CalculateHisPoints().ToString();
                singlePlayerData[2] = _playerData[i].CurrentDifficulty.Get;
                splittedData[i] = singlePlayerData;
            }
            return splittedData;
        }

        private void WriteToLeaderBoard()
        {
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    string text = _splittedData[row][column];
                    TextBlock textBlock = new TextBlockStyler(new TextBlock()).StyledTextBox;
                    textBlock.Text = text;

                    Grid.SetRow(textBlock, row);
                    Grid.SetColumn(textBlock, column);
                    CurrentLeaderBoard.Children.Add(textBlock);
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                // Leere den Frame, um zur Hauptansicht zurückzukehren
                mainWindow.FrameForLeaderBoard.NavigationService.Navigate(null);
            }
        }
    }
}
