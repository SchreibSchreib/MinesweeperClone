using Minesweeper.data.classes;
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
using System.Windows.Shapes;

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
            GamePage newSession = new GamePage(currentGameField);
            ContentFrame.Navigate(newSession);
        }
    }
}
