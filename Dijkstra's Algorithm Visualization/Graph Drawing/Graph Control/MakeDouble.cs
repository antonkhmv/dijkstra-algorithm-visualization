using Drawing;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Change the direction of the edge to Double.
        /// </summary>
        /// <param name="first">The first node of the edge.</param>
        /// <param name="second">The second node of the edge.</param>
        /// <param name="arrowStyle">The arrow style of the edge.</param>
        public void MakeDouble(int first, int second, ArrowStyle arrowStyle)
        {
            var edge = edges[first, second].FirstEdge;
            var opposite = edge.SecondEdge;

            opposite.Arrow = mainArrowStyle.NewArrow();
            arrowStyle.UpdateEdgePosition(edge, ArrowType.TwoSingles);

            if (opposite.Weight == edge.Weight)
            {
                opposite.WeightText.SetValue(VisibilityProperty, Visibility.Hidden);
            }

            graphCanvas.Children.Add(opposite.WeightText);
            graphCanvas.Children.Add(opposite.Arrow);

            edge.Direction = DirectionType.Double;
            opposite.Direction = DirectionType.Double;

            edge.UpdateText();
            opposite.UpdateText();

            // Update the adjacency table
            OnPropertyChanged("Adjacent");
        }
    }
}