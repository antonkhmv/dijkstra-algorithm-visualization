using Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class DrawingStrategy : Strategy
    {

        public override void Border_MouseUp(MainWindow window, object sender, MouseButtonEventArgs e)
        {
            Point p = GetMousePosition(e, sender);

            bool isInRange = window.FindNodeInRange(out int node, p, MainWindow.radiusScale * Node.Diameter);

            // Try to add a new edge between two selected nodes.
            if (addNewArrow)
            {
                // Remove the preview arrow.
                window.previewArrow.Data = new PathGeometry();

                // If the cursor is near a node, the first node of the arrow is not equal
                // to the second, and the arrow is not already in the graph.
                if (isInRange && node != newArrowNode && !(window.edges.Contains(newArrowNode, node)
                    && window.edges[newArrowNode, node].Direction != DirectionType.Backward))
                {
                    // Set the Z-index of the last node back to 1, so that it is not seen over the arrow.
                    Panel.SetZIndex(window.nodes[newArrowNode].Circle, 1);
                    Panel.SetZIndex(window.nodes[newArrowNode].IndexText, 1);

                    // If there is an edge between the selected nodes in the opposite direction.
                    if (window.edges.Contains(node, newArrowNode) && window.edges[node, newArrowNode].Direction == DirectionType.Forward)
                    {
                        window.MakeDouble(newArrowNode, node);
                    }
                    else
                    {
                        window.AddSingleEdge(newArrowNode, node);
                    }
                }
                addNewArrow = false;
            }
            // Stop moving the node that was beging dragged.
            if (moveNode)
            {
                // Set the Z index of the node to its original value.
                Panel.SetZIndex(window.nodes[movedNode].Circle, 1);
                Panel.SetZIndex(window.nodes[movedNode].IndexText, 1);
                moveNode = false;
            }
        }
    }
}