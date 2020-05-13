using Drawing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class Sequence
    {
        /// <summary>
        /// Reverses MoveForward();
        /// </summary>
        private void MoveBack()
        {
            MoveIteratorBackward();

            var step = steps[CurrentStep];

            // Relaxed edges.
            if (CurrentCheckedIndex == step.checkedNodes.Count)
            {
                // if the index reached the end.
                if (CurrentRelaxedIndex == 0 && step.checkedNodes.Count > 0)
                {
                    // The min node set to min
                    Shapes.SetCircleType(nodes[step.minNode], CircleType.Min);

                    // Move Pseudocode to findmin.
                    window.SelectCodeBlock(MainWindow.CodeBlock.FindMin);
                    var last = step.checkedNodes.Last();

                    // Change description params: checkedDistance, minDistance
                    window.ChangeDescription(MainWindow.CodeBlock.FindMin,
                        nodes[last.ind].Distance, nodes[last.minNode].Distance);

                    // Make the last checked node checked
                    Shapes.SetCircleType(nodes[last.ind], CircleType.Checked);
                }

                if (step.relaxedEdges.Count > 0)
                {
                    var (to, weight) = step.relaxedEdges[CurrentRelaxedIndex];
                    Shapes.SetArrowType(edges[step.minNode, to].Arrow, ArrowType.Waiting);

                    if (CurrentRelaxedIndex > 0)
                    {
                        var prevState = step.relaxedEdges[CurrentRelaxedIndex - 1];
                        var edge = window.edges[step.minNode, prevState.to];
                        nodes[prevState.to].Distance = prevState.weight;

                        // params: dist, edgeWeight, nodeDist
                        window.ChangeDescription(MainWindow.CodeBlock.RelaxedEdges,
                            dist[step.minNode], edge.Weight, nodes[prevState.to].Distance);
                    }

                    // Weight before relaxing the edge.
                    double value = weight;

                    nodes[to].Distance = value;
                    nodes[to].UpdateDistanceText(DoubleToString(value));
                }
            }
            // Checked nodes.
            else
            {
                var node = step.checkedNodes[CurrentCheckedIndex];

                // Set this node to normal
                Shapes.SetCircleType(nodes[node.ind], CircleType.Standard);

                if (CurrentCheckedIndex == step.checkedNodes.Count - 1)
                {
                    // Unselect all relaxed edges.
                    foreach (var (to, _) in step.relaxedEdges)
                    {
                        Shapes.SetArrowType(edges[step.minNode, to].Arrow, ArrowType.Standard);
                    }
                }

                if (CurrentCheckedIndex > 0)
                {
                    var prev = step.checkedNodes[CurrentCheckedIndex - 1];

                    // If last node is currently min, paint it as min.               
                    if (node.minNode == prev.ind)
                    {
                        Shapes.SetCircleType(nodes[prev.minNode], CircleType.Min);
                    }
                    else
                    {
                        // If this node is min, then make the previous min node min
                        if (node.minNode == node.ind)
                        {
                            Shapes.SetCircleType(nodes[prev.minNode], CircleType.Min);
                        }
                    }
                    // Set the previous to min.
                    Shapes.SetCircleType(nodes[prev.ind], CircleType.Checked);
                }
                else // if CurrentCheckedIndex == 0
                {
                    Shapes.SetCircleType(nodes[node.ind], CircleType.Standard);

                    if (IsFirst)
                    {
                        window.ChangeDescription(MainWindow.CodeBlock.Start);
                        window.SelectCodeBlock(MainWindow.CodeBlock.Start);
                    }
                    // If currentCheckedIndex == 0, but the previous step exists
                    else
                    {
                        var prevStep = steps[CurrentStep - 1];

                        // Move Pseudocode to Relaxed Nodes.
                        window.SelectCodeBlock(MainWindow.CodeBlock.RelaxedEdges);

                        if (prevStep.relaxedEdges.Count > 0)
                        {

                            var (to, weight) = prevStep.relaxedEdges.Last();
                            var edge = window.edges[prevStep.minNode, to];
                            nodes[to].Distance = weight;


                            // params: dist, edgeWeight, nodeDist
                            window.ChangeDescription(MainWindow.CodeBlock.RelaxedEdges,
                                dist[prevStep.minNode], edge.Weight, nodes[to].Distance);
                        }
                    }
                }

                // if the previous step is the firt.
                if (CurrentStep == 0)
                {
                    Shapes.SetCircleType(nodes[window.SelectedNode], CircleType.Selected);
                }
            }


        }

        private void MoveIteratorBackward()
        {
            --Iterator;

            // If checked index reached its begining.
            if (CurrentRelaxedIndex > 0)
            {
                --CurrentRelaxedIndex;
                return;
            }

            // Decrease checked index after relaxed edges, because the order is reverse.
            if (CurrentCheckedIndex > 0)
            {
                --CurrentCheckedIndex;
                return;
            }

            // if both indexes reached the begining  
            --CurrentStep;
            CurrentCheckedIndex = steps[CurrentStep].checkedNodes.Count;
            CurrentRelaxedIndex = Math.Max(steps[CurrentStep].relaxedEdges.Count - 1, 0);
        }
    }
}
