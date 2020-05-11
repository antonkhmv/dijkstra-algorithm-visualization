using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Removes an edge from the canvas and the edge collection.
        /// </summary>
        /// <param name="first">The first node of the edge.</param>
        /// <param name="second">The second node of the edge.</param>
        public void RemoveEdge(int first, int second)
        {
            var edge = edges[first, second];
            graphCanvas.Children.Remove(edge.Arrow);
            graphCanvas.Children.Remove(edge.Opposite.Arrow);
            graphCanvas.Children.Remove(edge.WeightText);
            graphCanvas.Children.Remove(edge.Opposite.WeightText);
            edges.Remove(first, second);
        }

        /// <summary>
        /// Removes an edge from the canvas and the edge collection.
        /// </summary>
        /// <param name="edge">The edge to be removed.</param>
        public void RemoveEdge(Edge edge) => RemoveEdge(edge.First, edge.Second);

    }

}