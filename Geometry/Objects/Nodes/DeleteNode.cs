using System;
using System.Collections.Generic;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class EdgeCollection : IEnumerable<Edge>
    {
        /// <summary>
        /// Deletes a node from the collection.
        /// </summary>
        public void DeleteNode(int node)
        {
            var adj = new List<int>();
            for(int i = 0; i < adjacent[node].Count; ++i)
            {
                var edge = adjacent[node][i];
                adj.Add(adjacent[edge.Second].FindIndex(x => x.Second == edge.First));
            }

            for(int i = 0; i < adjacent[node].Count; ++i)
            {
                var edge = adjacent[node][i];
                // Deletes all edges in the adjacency list of the node.
                adjacent[edge.Second].RemoveAt(adj[i]);
            }
            // Deletes the adjacency list of the node.
            adjacent.RemoveAt(node);

            // Update all keys and values in the dictionary, so that every node
            // that is bigger than the deleted node is decreased by one.
            Dictionary<Tuple<int, int>, Edge> newEdges = new Dictionary<Tuple<int, int>, Edge>();
            foreach (var key in edges.Keys)
            {
                var newKey = new Tuple<int, int>(key.Item1 > node ? key.Item1 - 1 : key.Item1,
                                                 key.Item2 > node ? key.Item2 - 1 : key.Item2);

                // If an edge didn't have the deleted node as one of the ends, keep it
                if (key.Item1 != node && key.Item2 != node)
                {
                    newEdges[newKey] = edges[key];
                }
            }
            edges = newEdges;
        }
    }
}