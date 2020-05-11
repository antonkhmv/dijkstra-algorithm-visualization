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
        public Strategy currentStrategy = new DrawingStrategy();

        /// <summary>
        /// The node that the algorithm starts with.
        /// </summary>
        public int selectedNode = -1;

        /// <summary>
        /// Property for automatically changing the SelectedNodeText.
        /// </summary>
        public int SelectedNode
        {
            get => selectedNode;
            set {
                selectedNode = value;
                OnPropertyChanged("SelectedNodeText");
            }
        }

        /// <summary>
        /// The edge that is selected to have its weight changed.
        /// </summary>
        public Edge selectedEdge = null;


    }
}