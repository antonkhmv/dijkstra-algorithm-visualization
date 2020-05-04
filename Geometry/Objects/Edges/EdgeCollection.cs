using System;
using System.Collections;
using System.Collections.Generic;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class EdgeCollection : IEnumerable<Edge>
    {
        private Dictionary<Tuple<int, int>, Edge> edges = new Dictionary<Tuple<int, int>, Edge>();

        // Debug
        public List<List<Edge>> adjacent = new List<List<Edge>>();

        /// <summary>
        /// The number of edges in the collection.
        /// </summary>
        public int Count => edges.Count;

        /// <summary>
        /// The number of nodes in the collection.
        /// </summary>
        public int Nodes => adjacent.Count;

        /// <summary>
        /// Returns the same edge with the opposite to a given edge.
        /// </summary>
        public Edge Opposite(Edge edge) => this[edge.Second, edge.First];

        /// <summary>
        /// Returnes the value of an edge from first to second.
        /// </summary>
        /// <param name="first">The first node of the edge.</param>
        /// <param name="second">The second node of the edge.</param>
        public Edge this[int first, int second]
        {
            get {
                if (!edges.ContainsKey(new Tuple<int, int>(first, second)))
                {
                    throw new ArgumentException($"No edge from node #{first} to node #{second}.");
                }
                return edges[new Tuple<int, int>(first, second)];
            }
        }

        /// <summary>
        /// All the edges that have index as an endnode.
        /// </summary>
        /// <param name="index">The index of the node.</param>
        public List<Edge> this[int index]
        {
            get {
                if (!(index < adjacent.Count))
                {
                    throw new ArgumentException($"No node #{index + 1}");
                }
                return adjacent[index];
            }
        }

        /// <summary>
        /// Remove all elements from the collection.
        /// </summary>
        public void Clear()
        {
            adjacent.Clear();
            edges.Clear();
        }

        /// <summary>
        /// Expand the list of adjacent node.
        /// </summary>
        public void Expand()
        {
            adjacent.Add(new List<Edge>());
        }

        /// <summary>
        /// Adds an edge to the collection.
        /// </summary>
        public void Add(Edge edge)
        {
            if (edge == null)
            {
                throw new ArgumentNullException("The edge is null");
            }
            else
            {
                edges[new Tuple<int, int>(edge.First, edge.Second)] = edge;
                adjacent[edge.First].Add(edge);
            }
        }

        /// <summary>
        /// Remove an edge from the collection.
        /// </summary>
        /// <param name="first">The first node of the edge.</param>
        /// <param name="second">The second node of the edge.</param>
        public void Remove(int first, int second)
        {
            if (!edges.ContainsKey(new Tuple<int, int>(first, second)))
            {
                throw new ArgumentException($"No edge from {first} to {second}.");
            }
            else
            {
                adjacent[first].Remove(this[first, second]);
                adjacent[second].Remove(this[second, first]);
                edges.Remove(new Tuple<int, int>(first, second));
                edges.Remove(new Tuple<int, int>(second, first));
            }
        }

        /// <summary>
        /// Checks if an edge is in the collection.
        /// </summary>
        /// <param name="first">The first node of the edge.</param>
        /// <param name="second">The second node of the edge.</param>
        public bool Contains(int first, int second)
        {
            if (adjacent.Count > first && adjacent.Count > second)
            {
                return edges.ContainsKey(new Tuple<int, int>(first, second));
            }
            return false;
        }

        /// <summary>
        /// Get the enumerator of the collection (of type Edge).
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Edge> GetEnumerator()
        {
            if (edges.Count == 0)
            {
                return new EdgeEnumerator(new List<Edge>());
            }
            return new EdgeEnumerator(new List<Edge>(edges.Values));
        }

        /// <summary>
        /// Get the enumerator of the collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
