using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Minesweeper.data.classes;

public static class Closer
{
    public static void closeWindow(Button currentButton)
    {
        DependencyObject parent = VisualTreeHelper.GetParent(currentButton);

        while (parent != null && !(parent is Window))
        {
            parent = VisualTreeHelper.GetParent(parent);
        }

        if (parent is Window window)
        {
            window.Close();
        }
        //Assembly currentassembly = Assembly.GetExecutingAssembly();
        //foreach (Window window in Application.Current.Windows)
        //{
        //    if (window.GetType().Assembly == currentassembly && window == currentWindow)
        //    {
        //        window.Close();
        //    }
        //}
    }
}
