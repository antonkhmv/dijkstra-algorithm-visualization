using Drawing;
using System.Linq;
using System.Security.Authentication;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class Sequence
    {

        private ArrowStyle relaxedStyle = ArrowStyle.Relaxed;
        private ArrowStyle waitingStyle = ArrowStyle.Waiting;


        public int CurrentStep = 0;
        public int CurrentCheckedIndex = 0;
        public int CurrentRelaxedIndex = 0;

        /// <summary>
        /// Moves the algorithm one step forward.
        /// </summary>
        public void MoveNext()
        {
            var step = steps[CurrentStep];

            // visualizing finding minimum node.
            if (CurrentCheckedIndex < step.checkedNodes.Count)
            {
                var node = step.checkedNodes[CurrentCheckedIndex];

                // Set this node as the one that is being checked
                Shapes.SetCircleStyle(nodes[node.ind], Shapes.CircleChecked);

                if (CurrentCheckedIndex > 0)
                {
                    var prev = step.checkedNodes[CurrentCheckedIndex - 1];
                    // If last node is currently min, paint it as min.
                    if (node.minNode == prev.ind)
                    {
                        Shapes.SetCircleStyle(nodes[prev.ind], Shapes.CircleMin);
                    }
                    else
                    {
                        // If this node is min then clear the last min.
                        if (node.minNode == node.ind)
                        {
                            Shapes.SetCircleStyle(nodes[prev.minNode], Shapes.CircleStyle);
                        }
                        Shapes.SetCircleStyle(nodes[prev.ind], Shapes.CircleStyle);
                    }
                }
                if (CurrentCheckedIndex == step.checkedNodes.Count - 1)
                {
                    // Select all relaxed edges.
                    foreach (var edge in step.relaxedEdges)
                    {
                        waitingStyle.SetStlye(edges[step.minNode, edge.to].Arrow);
                    }
                }
            }
            // Relaxed edges
            else
            {
                if (CurrentRelaxedIndex == 0)
                {   
                    // Make the last visited node black
                    Shapes.SetCircleStyle(nodes[step.checkedNodes.Last().ind], Shapes.CircleStyle);

                    // The min node set to visited.
                    Shapes.SetCircleStyle(nodes[step.minNode], Shapes.CircleVisitedStyle);
                }

                if (step.relaxedEdges.Count != 0)
                {
                    var edge = step.relaxedEdges[CurrentRelaxedIndex];
                    relaxedStyle.SetStlye(edges[step.minNode, edge.to].Arrow);
                }
                else
                {
                    // if this list is empty, then do the next step of the algorithm.
                    MoveIteratorForward();

                    if (!IsLast)
                    {
                        MoveNext();
                        --Iterator; 
                    }

                    window.OnPropertyChanged("Iterator");
                    window.OnPropertyChanged("CurrentStep");
                    window.OnPropertyChanged("CurrentChecked");
                    window.OnPropertyChanged("CurrentRelaxed");
                    return;
                }
            }

            MoveIteratorForward();
            
            window.OnPropertyChanged("Iterator");
            window.OnPropertyChanged("CurrentStep");
            window.OnPropertyChanged("CurrentChecked");
            window.OnPropertyChanged("CurrentRelaxed");
        }

        private void MoveIteratorForward()
        {
            var curr = steps[CurrentStep];

            ++Iterator;

            // Check (findMin) is always first.
            if (CurrentCheckedIndex < curr.checkedNodes.Count)
            {
                ++CurrentCheckedIndex;
                return;
            }

            // if checked index reached its end.
            if (CurrentRelaxedIndex < curr.relaxedEdges.Count - 1)
            {
                ++CurrentRelaxedIndex;
                return;
            }

            // if both indexes reached the end
            ++CurrentStep;
            CurrentCheckedIndex = 0;
            CurrentRelaxedIndex = 0;
        }
    }
}