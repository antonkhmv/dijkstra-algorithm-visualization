using Drawing;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Move the arrow to the new position of its edges' nodes.
        /// </summary>
        /// <param name="from">The index of the first node of the edge.</param>
        /// <param name="to">The index of the second node of the edge.</param>
        public void MoveArrow(int from, int to)
        {
            var edge = edges[from, to].FirstEdge;
            var opposite = edges[from, to].SecondEdge;

            edge.UpdateTextVisiblity();

            edge.UpdateText();
            opposite.UpdateText();

            Shapes.UpdateArrowPosition(edge, edge.Direction == DirectionType.Double
                ? ArrowDirection.Double : ArrowDirection.Single);
        }
    }
}