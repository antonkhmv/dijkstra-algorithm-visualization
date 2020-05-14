using Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            // Disable start button panels
            Code.Visibility = Visibility.Collapsed;
            SidebarPanel.Visibility = Visibility.Visible;

            // Set the previos strategy to the current strategy.
            currentStrategy = previousStrategy;

            // Stop the player and clear the nodes and edges.
            StopPlayer();
            ClearAllNodesAndEdges();
            Shapes.SetCircleType(nodes[SelectedNode], CircleType.Selected);
        }
    }
}