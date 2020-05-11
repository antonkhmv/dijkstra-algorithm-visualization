using Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        // Add nodes and edges from a graph to the canvas.
        public void DrawFromGraph(Graph graph)
        {
            foreach (var p in graph.Nodes)
            {
                AddNode(p);
            }

            int n = graph.Nodes.Count;
            for (int i = 0; i < edges.Nodes; ++i)
            {
                foreach(var edge in graph.AdjacentEdges[i])
                {
                    int to = edge.Node;
                    double weight = (double)(edge.Weight == null ? double.NaN : edge.Weight);

                    if (to == i || to < 0 || to > n) continue;

                    if (edges.Contains(to, i) && edges[to, i].Direction == DirectionType.Forward)
                    {
                        MakeDouble(i, to, ArrowStyle.Normal);
                        edges[i, to].Weight = weight;
                    }
                    else
                    {
                        AddSingleEdge(i, to, weight: weight);
                    }
                }
            }
            ;
            if (graph.SelectedNode != -1 && graph.SelectedNode < edges.Nodes)
            {
                SelectedNode = graph.SelectedNode;
                Shapes.SetCircleStyle(nodes[SelectedNode], Shapes.CircleSelectedStyle);
            }
        }
    }
}