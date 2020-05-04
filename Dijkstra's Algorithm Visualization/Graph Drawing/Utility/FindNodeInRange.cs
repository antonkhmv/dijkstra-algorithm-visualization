using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Finds a node in range of a point.
        /// </summary>
        /// <param name="node">The index of the node (if found).</param>
        /// <param name="p">The point to search from.</param>
        /// <param name="radius">The range of the search.</param>
        /// <returns>true if a node is found and false otherwise.</returns>
        public bool FindNodeInRange(out int node, Point p, double radius)
        {
            bool isFound = false;
            node = -1;
            // Find the last added node (that has the largest z-index)
            for(int i = nodes.Count-1; i >= 0; --i)
            {
                if (Drawing.Geometry.Distance(p, nodes[i].Center) < radius)
                {
                    isFound = true;
                    node = i;
                    break;
                }
            }
            return isFound;
        }
    }
}