using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class Graph
    {
        /// <summary>
        /// Builds a graph from the canvas.
        /// </summary>
        /// <param name="edges">Collection of edges from the canvas.</param>
        /// <param name="nodes">List of nodes from the canvas.</param>
        public void GetFromDrawing(EdgeCollection edges, List<Node> nodes, int selectedNode)
        {
            this.vertices = nodes.Select(x => x.Center).ToList();
            this.edges = new List<List<Tuple<int, double>>>();
            for (int i = 0; i < nodes.Count; ++i)
            {
                this.edges.Add(new List<Tuple<int, double>>());
            }
            foreach (var edge in edges)
            {
                if (edge.Direction != DirectionType.Backward)
                {
                    this.edges[edge.First].Add(new Tuple<int, double>(edge.Second, 
                        edge.WeightHasValue && !Edge.isDistanceEuclidean ? edge.Weight : double.NaN));
                }
            }
            this.selectedNode = selectedNode;
            this.isDistanceEucledian = Edge.isDistanceEuclidean;
        }
    }
}
