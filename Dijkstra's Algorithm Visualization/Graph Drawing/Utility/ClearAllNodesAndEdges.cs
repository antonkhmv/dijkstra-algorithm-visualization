using Drawing;
using System.Windows;
using System.Windows.Media;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Sets the colors of all edges and nodes to black.
        /// </summary>
        public void ClearAllNodesAndEdges()
        {
            foreach (var node in nodes)
            {
                Shapes.SetCircleStyle(node, Shapes.CircleStyle);
                node.UpdateText(node.Index.ToString());
                graphCanvas.Children.Remove(node.DistanceText);
            }
            foreach (var edge in edges)
            {
                ArrowStyle.Normal.SetStlye(edge.Arrow);
            }
        }
    }
}
