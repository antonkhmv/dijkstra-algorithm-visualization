using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Removes the node from the canvas, from the edgecollection and from the list of nodes.
        /// </summary>
        /// <param name="ind">The index of that node.</param>
        void RemoveAllNodes()
        {
            // Remove all edges from graph
            foreach (var edge in edges)
            {
                graphCanvas.Children.Remove(edge.Arrow);
                graphCanvas.Children.Remove(edge.Opposite.Arrow);
                graphCanvas.Children.Remove(edge.WeightText);
                graphCanvas.Children.Remove(edge.Opposite.WeightText);
            }
            edges.Clear();

            // Remove all nodes.
            for (int i = 0; i < nodes.Count; ++i)
            {
                graphCanvas.Children.Remove(nodes[i].Circle);
                graphCanvas.Children.Remove(nodes[i].IndexText);
            }
            nodes.Clear();
            SelectedNode = -1;
        }
    }
}