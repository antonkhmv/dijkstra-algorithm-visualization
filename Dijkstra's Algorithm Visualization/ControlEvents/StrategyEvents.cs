using System.Windows;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentStrategy.Border_MouseDown(this, sender, e);
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            currentStrategy.Border_MouseMove(this, sender, e);
        }

        private void Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            currentStrategy.Border_MouseUp(this, sender, e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {   
            currentStrategy.Window_KeyDown(this, sender, e);
        }
    }
}