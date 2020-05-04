using System.Collections.Generic;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class Sequence
    {
        private bool[] used;
        private double[] dist;

        public List<(
                    // Checked nodes
                    List<(int ind, int minNode)> checkedNodes, int minNode,
                    // Relaxed edges
                    List<(int to, double wt)> relaxedEdges
            )> steps =
            new List<(List<(int node, int minNode)> checkedNodes, int minNode,
                List<(int to, double wt)> relaxedEdges)>();

        private int minNode = -1;

        /// <summary>
        /// Save every step of the O(N^2) algorithm.
        /// </summary>
        public void BuildN2()
        {
            int from = window.selectedNode;
            dist[from] = 0.0;

            for (int i = 0; i < nodes.Count; ++i)
            {
                minNode = -1;
                var checkedNodes = FindMin();
                var relaxedEdges = new List<(int ind, double wt)>();

                if (minNode != -1)
                {
                    for (int j = 0; j < edges[minNode].Count; ++j)
                    {
                        Edge edge = edges[minNode][j];

                        int u = edge.Second;
                        if (!used[u] && edge.Direction != DirectionType.Backward)
                        {
                            if (dist[minNode] + edge.Weight < dist[u])
                            {
                                dist[u] = dist[minNode] + edge.Weight;
                                // edge relaxed
                                relaxedEdges.Add((u, dist[u]));
                            }
                            else
                            {
                                // edge not relaxed.
                                relaxedEdges.Add((u, double.NaN));
                            }
                        }
                    }
                }

                used[minNode] = true;
                steps.Add((checkedNodes, minNode, relaxedEdges));
                MaxIndex += checkedNodes.Count + relaxedEdges.Count;
            }
        }

        /// <summary>
        /// Save all the findmin checks.
        /// </summary>
        private List<(int ind, int minNode)> FindMin()
        {
            var checkNodes = new List<(int ind, int minNode)>();
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
