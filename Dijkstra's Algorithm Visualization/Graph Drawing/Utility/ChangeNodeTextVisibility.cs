using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        public void ChangeNodeTextVisibility(Visibility visibility)
        {
            foreach(var node in nodes)
            {
                node.Text.SetValue(VisibilityProperty, visibility);
            }
        }
    }
}
