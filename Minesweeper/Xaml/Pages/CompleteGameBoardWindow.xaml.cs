using Minesweeper.data.classes;
using Minesweeper.data.classes.AbstractClasses;
using System.Windows;

namespace Minesweeper
{
    /// <summary>
    /// Interaktionslogik für CompleteGameBoardWindow.xaml
    /// </summary>
    public partial class CompleteGameBoardWindow : Window
    {
        public CompleteGameBoardWindow(WholeSessionData currentGameField)
        {
            InitializeComponent();
            _gameButton = currentGameField.Buttons[0];
            GamePage newSession = new GamePage(currentGameField);
            ContentFrame.Navigate(newSession);
        }

        private GameButton _gameButton;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow backToMain = new MainWindow();
            backToMain.Show();
            Closer.closeWindow(_gameButton);
        }
    }
}
