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
            Nodes = nodes.Select(x => x.Center).ToList();
            AdjacentEdges = new List<List<AdjacentEdgeElement>>();
            for (int i = 0; i < nodes.Count; ++i)
            {
                this.AdjacentEdges.Add(new List<AdjacentEdgeElement>());
            }
            foreach (var edge in edges)
            {
                if (edge.Direction != DirectionType.Backward)
                {
                    this.AdjacentEdges[edge.First].Add(new AdjacentEdgeElement(edge.Second, 
                        edge.WeightHasValue ? (double?) edge.Weight : null));
                }
            }
            this.SelectedNode = selectedNode;
        }
    }
}
