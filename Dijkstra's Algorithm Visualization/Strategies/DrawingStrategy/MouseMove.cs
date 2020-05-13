using Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class DrawingStrategy : Strategy
    {
        /// <summary>
        /// The position of the cursor on the node when it is being dragged.
        /// </summary>
        public Point movedNodePosition;

        /// <summary>
        /// Wether the node is being dragged.
        /// </summary>
        public bool moveNode = false;

        /// <summary>
        /// The index of the node being dragged.
        /// </summary>
        public int movedNode = -1;

        public override void Border_MouseMove(MainWindow window, object sender, MouseEventArgs e)
        {
            // The position of the mouse.    
            Point p = GetMousePosition(e, sender);

            // The index of the node the mouse is over.
            bool mouseOnNode = window.FindNodeInRange(out int ind, p, Node.Diameter / 2.0);

            // Trying to draw the arrow to the new mouse position.
            if (addNewArrow)
            {
                // If the arrow drawing button is pressed.
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    // Check that mouse is not inside the first node
                    if (!mouseOnNode || ind != newArrowNode)
                    {
                        Shapes.DrawArrow(window.previewArrow, newArrowPoint, p);
                    }
                    else
                    {
                        // Delete the preview arrow.
                        window.previewArrow.Data = new PathGeometry();
                    }
                    return;
                }
                else
                {
                    // Prevents a bug where if the cursor leaves the border, and then enters again, the arrow is still being drawn.
                    window.previewArrow.Data = new PathGeometry();
                }
                addNewArrow = false;
            }

            // Trying to move the arrrow when a node is dragged.
            if (e.RightButton == MouseButtonState.Pressed)
            {
                if (moveNode)
                {
                    var node = window.nodes[movedNode];

                    // Move the node.
                    node.SetPosition((Point)(p - movedNodePosition));

                    // Move the arrows.
                    foreach (var edge in window.edges[movedNode])
                    {             
                        window.MoveArrow(edge.From, edge.To);
                    }
                }
            }
        }
    }
}