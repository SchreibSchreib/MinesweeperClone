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
    static class ObjectFinder
    {
        public static List<CheckBox> GetCheckBoxes(DependencyObject gridOrPanel)
        {
            List<CheckBox> listCheckboxes = new List<CheckBox>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(gridOrPanel); i++)
            {
                var child = VisualTreeHelper.GetChild(gridOrPanel, i);
                if (child is CheckBox checkBox)
                {
                    listCheckboxes.Add(checkBox);
                }
                else
                {
                    listCheckboxes.AddRange(GetCheckBoxes(child));
                }
            }
            return listCheckboxes;
        }
    }
}
