using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Minesweeper.data.classes
{
    class PanelFinder
    {
        public static Panel? GetParentPanel(UIElement element)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(element);

            while (parent != null && !(parent is Panel))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as Panel;
        }
    }
}
