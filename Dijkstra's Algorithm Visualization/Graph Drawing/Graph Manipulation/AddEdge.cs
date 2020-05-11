using Drawing;
using System;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        static Random rand = new Random();

        /// <summary>
        /// Add an edge to the canvas and to the collection.
        /// </summary> 
        /// <param name="first">The first node of the edge.</param>
        /// <param name="second">The second node of the edge.</param>
        /// <param name="direction">The direction of the edge.</param>
        public void AddSingleEdge(int first, int second, double weight = double.NaN)
        {
            // Create a new arrow.
            var newArrow = ArrowStyle.Normal.NewArrow();

            Edge edge = new Edge(nodes[first], nodes[second], DirectionType.Forward, newArrow, weight);
            edge.FirstEdge = edge;
                                  
            if (!double.IsNaN(weight))
                edge.Weight = weight;    

            Edge opposite = new Edge(nodes[second], nodes[first], DirectionType.Backward, newArrow)
            {
                FirstEdge = edge,
                Opposite = edge
            };
            edge.Opposite = opposite;
            ArrowStyle.Normal.UpdateEdgePosition(edge, ArrowType.Single);

            this.graphCanvas.Children.Add(edge.Arrow);
            this.graphCanvas.Children.Add(edge.WeightText);

            // Add the arrow to the edges and the arrows.
            edges.Add(edge);
            edges.Add(opposite);
        }
    }
}