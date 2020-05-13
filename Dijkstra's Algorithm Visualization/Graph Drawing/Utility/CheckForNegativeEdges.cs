using Drawing;
using System.Windows;
using System.Windows.Media;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Checks for whether or not there are negative edges in the graph.
        /// </summary>
        public bool CheckForNegativeEdges()
        {
            foreach (var edge in edges)
            {
                if (edge.Weight < 0)
                    return true;
            }
            return false;
        }
    }
}
