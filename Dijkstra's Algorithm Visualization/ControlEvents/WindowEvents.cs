using System.Windows;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainArrowStyle.SetStlye(previewArrow);
            selectedButton = startButton;
        }
    }
}
