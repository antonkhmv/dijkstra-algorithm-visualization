using Drawing;
using System.Windows;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ArrowStyle.Normal.SetStlye(previewArrow);
            selectedButton = drawButton;          
            selectedSidebarButton = examplesButton;          
        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            mainGrid.Focus();
        }
    }
}
