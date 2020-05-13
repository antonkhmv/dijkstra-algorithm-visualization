using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Removes the node from the canvas, from the edgecollection and from the list of nodes.
        /// </summary>
        /// <param name="ind">The index of that node.</param>
        public void RemoveNode(int ind)
        {
            // Remove from graph
            foreach (var edge in edges[ind])
            {
                graphCanvas.Children.Remove(edge.Arrow);
                graphCanvas.Children.Remove(edge.Opposite.Arrow);
                graphCanvas.Children.Remove(edge.WeightText);
                graphCanvas.Children.Remove(edge.Opposite.WeightText);
            }
            var node = nodes[ind];
            graphCanvas.Children.Remove(node.Circle);
            graphCanvas.Children.Remove(node.IndexText);

            edges.DeleteNode(ind);
            nodes.Remove(node);

            // Relabel the indexes of the nodes.
            for (int i = ind; i < nodes.Count; ++i)
            {
                nodes[i].Index--;
                // Update the index text of the nodes.
                nodes[i].UpdateIndexText();
            }

            if (SelectedNode == ind)
            {
                SelectedNode = -1;
            }
        }
    }
}