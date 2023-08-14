using System.Reflection;
using System.Windows;

namespace Minesweeper
{
    public static class Closer
    {
        public static void closeWindow(Window currentWindow)
        {
            Assembly currentassembly = Assembly.GetExecutingAssembly();
            foreach (Window win in Application.Current.Windows)
            {
                if (win.GetType().Assembly == currentassembly && win == currentWindow)
                {
                    win.Close();
                }
            }
        }
    }
}
