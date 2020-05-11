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
        public List<Point> Nodes;

        /// <summary>
        /// Adjacency list of pairs <node, weight> of the edges.
        /// </summary>
        public List<List<AdjacentEdgeElement>> AdjacentEdges;

        public int SelectedNode = -1;
                    
    }

    /// <summary>
    /// A class for saving elements of the adjacentEdges list as a json file.
    /// </summary>
    public struct AdjacentEdgeElement
    {
        public int Node;
        public double? Weight;
        public AdjacentEdgeElement(int node, double? weight)
        {
            Node = node;
            Weight = weight;
        }
    }
}
