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
            foreach (var p in graph.vertices)
            {
                AddNode(p);
            }

            int n = graph.vertices.Count;
            for (int i = 0; i < edges.Nodes; ++i)
            {
                foreach(var edge in graph.edges[i])
                {
                    int to = edge.Item1;

                    if (to == i || to < 0 || to > n) continue;

                    if (edges.Contains(to, i) && edges[to, i].Direction == DirectionType.Forward)
                    {
                        MakeDouble(i, to, mainArrowStyle);
                        edges[i, to].Weight = edge.Item2;
                    }
                    else
                    {
                        AddSingleEdge(i, to, weight: edge.Item2);
                    }
                }
            }
            ;
            if (graph.selectedNode != -1 && graph.selectedNode < edges.Nodes)
            {
                selectedNode = graph.selectedNode;
                Shapes.SetCircleStyle(nodes[selectedNode], Shapes.CircleSelectedStyle);
            }
        }
    }
}