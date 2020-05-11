using Drawing;
using System;
using System.Linq;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class Sequence
    {
        /// <summary>
        /// Reverses MoveForward();
        /// </summary>
        public void MoveBack()
        {
            MoveIteratorBackward();

            var step = steps[CurrentStep];

            // Relaxed edges.
            if (CurrentCheckedIndex == step.checkedNodes.Count)
            {
                // if the index reached the end.
                if (CurrentRelaxedIndex == 0)
                {
                    // Move Pseudocode to findmin.
                    window.SelectCodeBlock(MainWindow.CodeBlock.RelaxedEdges);

                    // The min node set to min
                    Shapes.SetCircleStyle(nodes[step.minNode], Shapes.CircleMin);

                    if (step.checkedNodes.Count > 0)
                    {
                        var last = step.checkedNodes.Last();

                        // Change description params: checkedDistance, minDistance
                        window.ChangeDescription(MainWindow.CodeBlock.FindMin,
                            nodes[last.ind].Distance, nodes[last.minNode].Distance);

                        // Make the last checked node checked
                        Shapes.SetCircleStyle(nodes[last.ind], Shapes.CircleChecked);
                    }
                }

                if (step.relaxedEdges.Count != 0)
                {
                    var (to, weight) = step.relaxedEdges[CurrentRelaxedIndex];
                    ArrowStyle.Waiting.SetStlye(edges[step.minNode, to].Arrow);

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


                    // if this is the first relaxed edge.
                    if (CurrentRelaxedIndex == step.relaxedEdges.Count - 1)
                    {
                        // Move code to start
                        window.SelectCodeBlock(MainWindow.CodeBlock.RelaxedEdges);
                    }
                }
            }
            // Checked nodes.
            else
            {
                var node = step.checkedNodes[CurrentCheckedIndex];

                // Set this node to normal
                Shapes.SetCircleStyle(nodes[node.ind], Shapes.CircleStyle);

                if (CurrentCheckedIndex == step.checkedNodes.Count - 1)
                {
                    // Unselect all relaxed edges.
                    foreach (var (to, _) in step.relaxedEdges)
                    {
                        ArrowStyle.Normal.SetStlye(edges[step.minNode, to].Arrow);
                    }
                }

                if (CurrentCheckedIndex > 0)
                {
                    var prev = step.checkedNodes[CurrentCheckedIndex - 1];

                    // If last node is currently min, paint it as min.               
                    if (node.minNode == prev.ind)
                    {
                        Shapes.SetCircleStyle(nodes[prev.minNode], Shapes.CircleMin);
                    }
                    else
                    {
                        // If this node is min, then make the previous min node min
                        if (node.minNode == node.ind)
                        {
                            Shapes.SetCircleStyle(nodes[prev.minNode], Shapes.CircleMin);
                        }
                    }
                    // Set the previous to min.
                    Shapes.SetCircleStyle(nodes[prev.ind], Shapes.CircleChecked);
                }
                else // if CurrentCheckedIndex == 0
                {
                    Shapes.SetCircleStyle(nodes[node.ind], Shapes.CircleStyle);

                    if (IsFirst)
                    {
                        window.ChangeDescription(MainWindow.CodeBlock.Start);
                    }
                    else
                    {
                        var prevStep = steps[CurrentStep - 1];

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

                    // Move Pseudocode to start.
                    window.SelectCodeBlock(MainWindow.CodeBlock.Start);

                    // if the previous step is the firt.
                    if (CurrentStep == 0)
                    {
                        Shapes.SetCircleStyle(nodes[window.SelectedNode], Shapes.CircleSelectedStyle);
                    }
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