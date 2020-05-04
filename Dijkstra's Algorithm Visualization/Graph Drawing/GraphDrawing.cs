using Drawing;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {

        /// <summary>
        /// The scale of radius for the range of drawing an arrow.
        /// </summary>
        public double radiusScale = 1.5;

        /// <summary>
        /// The hit box size of the arrow (half of thickness of a rectangle the arrow is contained in).
        /// </summary>
        public double arrowHitBoxSize = 5.0;

        /// <summary>
        /// A collection of edges that stores the arrows in a dictionary, and adjacent nodes in a nested list.
        /// </summary>
        public EdgeCollection edges = new EdgeCollection();

        /// <summary>
        /// List of all nodes.
        /// </summary>
        public List<Node> nodes = new List<Node>();

        /// <summary>
        /// Current strategy for drawing the graph (create, delete and select nodes and edges).
        /// </summary>
        public Strategy currentStrategy = new StartStrategy();

        /// <summary>
        /// The main arrow style of the canvas.
        /// </summary>
        public ArrowStyle mainArrowStyle = ArrowStyle.Normal;

        public int selectedNode = -1;

        public bool IsDistanceEuclidean
        {
            get => Edge.isDistanceEuclidean;

            set {
                Edge.isDistanceEuclidean = value;
                UpdateAllWeightText();
            }
        }

        public bool IsIndexTextVisible
        {
            get => Node.isIndexTextVisible;
            set {
                Node.isIndexTextVisible = value;
                if (value)
                    ChangeNodeTextVisibility(Visibility.Visible);
                else
                    ChangeNodeTextVisibility(Visibility.Hidden);
            }
        }

    }
}