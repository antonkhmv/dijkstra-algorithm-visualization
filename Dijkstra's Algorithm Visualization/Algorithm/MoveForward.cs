using Drawing;
using System.Linq;
using System.Threading.Tasks;

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
        private void MoveNext()
        {
            var step = steps[CurrentStep];

            // Finding Minimum node
            if (CurrentCheckedIndex < step.checkedNodes.Count)
            {
                var node = step.checkedNodes[CurrentCheckedIndex];

                // Set this node as the one that is being checked
                Shapes.SetCircleType(nodes[node.ind], CircleType.Checked);

                // Change description params: checkedDistance, minDistance
                window.ChangeDescription(MainWindow.CodeBlock.FindMin,
                    nodes[node.ind].Distance, nodes[node.minNode].Distance);

                if (CurrentCheckedIndex > 0)
                {
                    var prev = step.checkedNodes[CurrentCheckedIndex - 1];
                    // If last node is currently min, paint it as min.
                    if (node.minNode == prev.ind)
                    {
                        Shapes.SetCircleType(nodes[prev.ind], CircleType.Min);
                    }
                    else
                    {
                        // If this node is min then clear the last min.
                        if (node.minNode == node.ind)
                        {
                            Shapes.SetCircleType(nodes[prev.minNode], CircleType.Standard);
                        }
                        Shapes.SetCircleType(nodes[prev.ind], CircleType.Standard);
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
                        Shapes.SetArrowType(edges[step.minNode, to].Arrow, ArrowType.Waiting);
                    }
                }
            }
            // Relaxed edges         
            else
            {
                if (CurrentRelaxedIndex == 0)
                {
                    if (step.checkedNodes.Count > 0)
                    {
                        // Make the last visited node black
                        Shapes.SetCircleType(nodes[step.checkedNodes.Last().ind], CircleType.Standard);
                    }

                    // Move Pseudocode to relxed edges.
                    window.SelectCodeBlock(MainWindow.CodeBlock.RelaxedEdges);

                    // The min node set to visited.
                    Shapes.SetCircleType(nodes[step.minNode], CircleType.Visited);
                }

                if (step.relaxedEdges.Count != 0)
                {
                    var (to, weight) = step.relaxedEdges[CurrentRelaxedIndex];
                    var edge = edges[step.minNode, to];
                    var distMin = nodes[step.minNode].Distance;

                    // params: dist, edgeWeight, nodeDist
                    window.ChangeDescription(MainWindow.CodeBlock.RelaxedEdges,
                        distMin, edge.Weight, nodes[to].Distance);

                    double value;

                    if (distMin + edge.Weight < nodes[to].Distance)
                    {
                        value = distMin + edge.Weight;
                        Shapes.SetArrowType(edge.Arrow, ArrowType.Relaxed);
                    }
                    else
                    {
                        value = nodes[to].Distance;
                        Shapes.SetArrowType(edge.Arrow, ArrowType.NotRelaxed);
                    }

                    nodes[to].Distance = value;
                    nodes[to].UpdateDistanceText();
                }

            }

            MoveIteratorForward();

            if (IsLast)
            {
                // params: compelxity
                window.ChangeDescription(MainWindow.CodeBlock.None,
                    complexity);
                window.SelectCodeBlock(MainWindow.CodeBlock.None);
            }
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