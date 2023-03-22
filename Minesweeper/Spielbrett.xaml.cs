using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaktionslogik für Spielbrett.xaml
    /// </summary>
    public partial class Spielbrett : Window
    {
        public Spielbrett(List<Playbutton> playButtons,int buttonsX,int buttonsY)
        {
            this.buttonsX = buttonsX;
            this.buttonsY = buttonsY;
            this.buttons = playButtons;
            InitializeComponent();
        }
        private List<Playbutton> buttons;
        private int buttonsX;
        private int buttonsY;

        private void SpawnGrid_Loaded(object sender, RoutedEventArgs e)
        {
            for (int row = 0; row < buttonsY; row++)
            {
                SpawnGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int column = 0; column < buttonsX; column++)
            {
                SpawnGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            foreach (Playbutton button in buttons)
            {
                SpawnGrid.Children.Add(button);
                Grid.SetRow(button, Convert.ToInt32(button.coordinates.Split(' ')[0]));
                Grid.SetColumn(button, Convert.ToInt32(button.coordinates.Split(' ')[1]));
            }
           
        }
    }
}
