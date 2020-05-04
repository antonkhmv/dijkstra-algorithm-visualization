using Drawing;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Finds the arrow in range of a point.
        /// </summary>
        /// <param name="res">The nearest edge (if found)</param>
        /// <param name="p">The point to search from.</param>
        /// <param name="radius">The range of the search.</param>
        /// <returns>true if any arrow is found, and false otherwise.</returns>
        public bool FindArrowInRange(out Edge res, Point p, double radius)
        {
            res = null;
            bool isFound = false;
            foreach(var edge in edges) {
                if (Geometry.IsInRangeOfLine(p, edge.FirstNode.Center, edge.SecondNode.Center, radius))
                {
                    isFound = true;
                    res = edge;
                    break;
                }
            }
            return isFound;
        }
    }
}