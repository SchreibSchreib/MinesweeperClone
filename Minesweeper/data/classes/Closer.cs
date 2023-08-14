using System.Reflection;
using System.Windows;

namespace Minesweeper
{
    public static class Closer
    {
        public static void closeWindow(Window currentWindow)
        {
            Assembly currentassembly = Assembly.GetExecutingAssembly();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType().Assembly == currentassembly && window == currentWindow)
                {
                    window.Close();
                }
            }
        }
    }
}
