using Drawing;
using System.Linq;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class Sequence
    {
        public int CurrentStep = 0;
        public int CurrentCheckedIndex = 0;
        public int CurrentRelaxedIndex = 0;

        /// <summary>
        /// Moves the algorithm one step forward.
        /// </summary>    
        public void MoveNext()
        {
            var step = steps[CurrentStep];

            // Finding Minimum node
            if (CurrentCheckedIndex < step.checkedNodes.Count)
            {
                var node = step.checkedNodes[CurrentCheckedIndex];

                // Set this node as the one that is being checked
                Shapes.SetCircleStyle(nodes[node.ind], Shapes.CircleChecked);

                // Change description params: checkedDistance, minDistance
                window.ChangeDescription(MainWindow.CodeBlock.FindMin,
                    nodes[node.ind].Distance, nodes[node.minNode].Distance);

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
                else // if CurrentCheckedIndex == 0
                {
                    // Move Pseudocode to findmin
                    window.SelectCodeBlock(MainWindow.CodeBlock.FindMin);
                }

                if (CurrentCheckedIndex == step.checkedNodes.Count - 1)                                                                                                                                                                                                                                                                                                                                                         
                {
                    // Select all relaxed edges.
                    foreach (var (to, _) in step.relaxedEdges)
                    {
                        ArrowStyle.Waiting.SetStlye(edges[step.minNode, to].Arrow);
                    }
                }                                                                                                                                                                                                                                                                                                                                                                                         
            }
            // Relaxed edges         
            else
            {
                if (CurrentRelaxedIndex == 0)
                {
                    // Move Pseudocode to relxed edges.
                    window.SelectCodeBlock(MainWindow.CodeBlock.RelaxedEdges);

                    if (step.checkedNodes.Count > 0)
                    {
                        // Make the last visited node black
                        Shapes.SetCircleStyle(nodes[step.checkedNodes.Last().ind], Shapes.CircleStyle);
                    }

                    // The min node set to visited.
                    Shapes.SetCircleStyle(nodes[step.minNode], Shapes.CircleVisitedStyle);
                }

                if (step.relaxedEdges.Count != 0)
                {
                    var (to, _) = step.relaxedEdges[CurrentRelaxedIndex];
                    var edge = edges[step.minNode, to];

                    ArrowStyle.Relaxed.SetStlye(edge.Arrow);

                    // params: dist, edgeWeight, nodeDist
                    window.ChangeDescription(MainWindow.CodeBlock.RelaxedEdges,
                        dist[step.minNode], edge.Weight, nodes[to].Distance);
                                        
                    // Distance after relaxing the edge.
                    double value = System.Math.Min(dist[step.minNode] + edge.Weight,
                        nodes[to].Distance);

                    nodes[to].Distance = value;
                    nodes[to].UpdateDistanceText(DoubleToString(value));

                    // if this is the last relaxed edge.
                    if (CurrentRelaxedIndex == step.relaxedEdges.Count-1)
                    {
                        // Move code to start
                        window.SelectCodeBlock(MainWindow.CodeBlock.Start);
                    }
                }
                else
                {
                    // if this list is empty, then do the next step of the algorithm.
                    MoveIteratorForward();

                    // Move code to start
                    window.SelectCodeBlock(MainWindow.CodeBlock.Start);
                    
                    if (IsLast)
                    {
                        // params: compelxity
                        window.ChangeDescription(MainWindow.CodeBlock.None,
                            complexity);
                        window.SelectCodeBlock(MainWindow.CodeBlock.None);
                    }
                    return;
                }
            }

            MoveIteratorForward();
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