using Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Add nodes and edges from a graph to the canvas.
        /// </summary>
        /// <param name="graph"></param>
        public bool DrawFromGraph(Graph graph)
        {
            foreach (var p in graph.Nodes)
            {
                AddNode(p);
            }

            int n = graph.Nodes.Count;
            for (int i = 0; i < edges.Nodes; ++i)
            {
                foreach (var edge in graph.AdjacentEdges[i])
                {
                    int to = edge.Node;
                    double weight = (double)(edge.Weight == null ? double.NaN : edge.Weight);

                    // Graph is not valid
                    if (to == i || to < 0 || to > n)
                        return false;

                    if (edges.Contains(to, i) && edges[to, i].Direction == DirectionType.Forward)
                    {
                        MakeDouble(i, to);
                        edges[i, to].Weight = weight;
                    }
                    else
                    {
                        AddSingleEdge(i, to, weight: weight);
                    }
                }
            }
            // if a node is selected.
            if (graph.SelectedNode >= 0 && graph.SelectedNode < edges.Nodes)
            {
                SelectedNode = graph.SelectedNode;
                Shapes.SetCircleType(nodes[SelectedNode], CircleType.Selected);
                return true;
            }
            // if the selected node is not -1 (unselected), then the graph is invalid
            return graph.SelectedNode == -1;
        }
    }
}