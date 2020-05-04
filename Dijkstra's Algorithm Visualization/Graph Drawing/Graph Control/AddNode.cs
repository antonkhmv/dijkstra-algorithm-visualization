using System.Windows;
using System.Windows.Controls;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Adds a node to the canvas at the point "position".
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public void AddNode(Point position)
        {
            var node = new Node(position.X, position.Y, edges.Nodes);
            nodes.Add(node);
            edges.Expand();

            graphCanvas.Children.Add(node.Circle);
            graphCanvas.Children.Add(node.Text);

            if (!Node.isIndexTextVisible)
            {
                node.Text.SetValue(VisibilityProperty, Visibility.Hidden);
            }

            // Z index for for the arrow to be seen when the it crosses other nodes.
            Panel.SetZIndex(node.Circle, 1);
            Panel.SetZIndex(node.Text, 1);

            // Update the adjacency table
            OnPropertyChanged("Adjacent");
        }
    }
}