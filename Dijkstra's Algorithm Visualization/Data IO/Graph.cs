using System;
using System.Collections.Generic;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    /// <summary>
    /// A graph class for loading and saving graphs to and from the canvas.
    /// </summary>
    [Serializable]
    public partial class Graph
    {
        /// <summary>
        /// List of points of the nodes.
        /// </summary>
        public List<Point> vertices;

        /// <summary>
        /// Adjacency list of pairs <node, weight> of the edges.
        /// </summary>
        public List<List<Tuple<int, double>>> edges;

        public int selectedNode = -1;

        public bool isDistanceEucledian = true;
    }
}
