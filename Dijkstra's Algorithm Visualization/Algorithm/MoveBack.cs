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
            window.OnPropertyChanged("Iterator");
            window.OnPropertyChanged("CurrentStep");
            window.OnPropertyChanged("CurrentChecked");
            window.OnPropertyChanged("CurrentRelaxed");

            var step = steps[CurrentStep];

            // Relaxed edges.
            if (CurrentCheckedIndex == step.checkedNodes.Count)
            {
                // if the index reached the end.
                if (CurrentRelaxedIndex == 0)
                {
                    // The min node set to min
                    Shapes.SetCircleStyle(nodes[step.minNode], Shapes.CircleMin);

                    // Make the last checked node checked
                    Shapes.SetCircleStyle(nodes[step.checkedNodes.Last().ind], Shapes.CircleChecked);
                }

                if (step.relaxedEdges.Count != 0)
                {
                    var edge = step.relaxedEdges[CurrentRelaxedIndex];
                    waitingStyle.SetStlye(edges[step.minNode, edge.to].Arrow);
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
                    foreach (var edge in step.relaxedEdges)
                    {
                        window.mainArrowStyle.SetStlye(edges[step.minNode, edge.to].Arrow);
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
                else
                {
                    Shapes.SetCircleStyle(nodes[node.ind], Shapes.CircleStyle);
                    if (CurrentStep > 0 && steps[CurrentStep - 1].relaxedEdges.Count == 0)
                    {
                        // if this list is empty, then do the next step of the algorithm.
                        MoveBack();
                        // We don't have to move the iterator.                     
                        ++Iterator;
                    }
                    if (CurrentStep == 0)
                    {
                        Shapes.SetCircleStyle(nodes[node.ind], Shapes.CircleSelectedStyle);
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