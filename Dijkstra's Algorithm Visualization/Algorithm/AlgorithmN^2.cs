using System.Collections.Generic;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class Sequence
    {
        private readonly bool[] used;
        private readonly double[] dist;

        public List<(// Checked nodes
                    List<(int ind, int minNode)> checkedNodes, int minNode,
                    // Relaxed edges
                    List<(int to, double weight)> relaxedEdges
            )> steps =
            new List<(List<(int node, int minNode)> checkedNodes, int minNode,
                List<(int to, double wt)> relaxedEdges)>();

        private int minNode = -1;

        /// <summary>
        /// The total amount of steps the algorithm makes (relaxed edges + checked nodes).
        /// </summary>
        public int complexity = 0;

        /// <summary>
        /// Save every step of the O(N^2) algorithm.
        /// </summary>
        public void BuildN2()
        {
            int from = window.SelectedNode;
            dist[from] = 0.0;

            for (int i = 0; i < nodes.Count; ++i)
            {
                minNode = -1;
                var checkedNodes = FindMin();
                var relaxedEdges = new List<(int ind, double wt)>();

                if (minNode != -1 && dist[minNode] != double.PositiveInfinity)
                {
                    for (int j = 0; j < edges[minNode].Count; ++j)
                    {
                        Edge edge = edges[minNode][j];

                        int u = edge.Second;
                        if (edge.Direction != DirectionType.Backward)
                        {
                            // Remember the edge distance before relaxing for reversing the algorithm.
                            relaxedEdges.Add((u, dist[u]));

                            if (dist[minNode] + edge.Weight < dist[u])
                            {
                                dist[u] = dist[minNode] + edge.Weight;
                            }
                        }
                    }
                }

                used[minNode] = true;
                steps.Add((checkedNodes, minNode, relaxedEdges));
                complexity += checkedNodes.Count + relaxedEdges.Count;
                maxIndex += checkedNodes.Count + System.Math.Max(1, relaxedEdges.Count);
            }
        }

        /// <summary>
        /// Save all the findmin checks.
        /// </summary>
        private List<(int ind, int minNode)> FindMin()
        {
            var checkNodes = new List<(int ind, int minNode)>();
            minNode = -1;
            for (int j = 0; j < nodes.Count; ++j)
            {
                if (!used[j])
                {
                    if (minNode == -1 || dist[j] < dist[minNode])
                    {
                        minNode = j;
                    }
                    // don't update the current min node.
                    checkNodes.Add((j, minNode));
                }
            }
            return checkNodes;
        }
    }
}
