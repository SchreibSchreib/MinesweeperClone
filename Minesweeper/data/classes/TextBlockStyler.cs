using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Minesweeper.data.classes
{
    internal class TextBlockStyler
    {
        public TextBlockStyler(TextBlock thisTextBlock)
        {
            StyledTextBox = thisTextBlock;
            GetInPosition();
            GetColor();
            GetSize();
        }

        public TextBlock StyledTextBox { get; private set; }

        private void GetInPosition()
        {
            StyledTextBox.HorizontalAlignment = HorizontalAlignment.Center;
            StyledTextBox.VerticalAlignment = VerticalAlignment.Center;
        }

        private void GetColor()
        {
            StyledTextBox.Foreground = new SolidColorBrush(Colors.White);
        }

        private void GetSize()
        {
            StyledTextBox.FontSize = 40;
        }
    }
}
