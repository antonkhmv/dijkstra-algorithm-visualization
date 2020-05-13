using Drawing;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class DrawingStrategy : Strategy
    {
        /// <summary>
        /// The center of the first node of the previewArrow.
        /// </summary>
        static Point newArrowPoint;

        /// <summary>
        /// Starting node for the previewArrow.
        /// </summary>
        static int newArrowNode;

        /// <summary>
        /// Whether the arrow is being added and the preview arrow is visible.
        /// </summary>
        static bool addNewArrow = false;

        public override void Border_MouseDown(MainWindow window, object sender, MouseButtonEventArgs e)
        {
            // The position of the mouse.   
            Point p = GetMousePosition(e, sender);

            // The index of the node.
            bool mouseOnNode = window.FindNodeInRange(out int mouseNode, p, Node.Diameter / 2.0);
            bool isInRange = window.FindNodeInRange(out int nodeInRange, p, window.radiusScale * Node.Diameter);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Try to start drawing the arrow (preview arrow).
                if (isInRange)
                {
                    if (!moveNode)
                    {
                        Node node = window.nodes[nodeInRange];

                        // Start drawing the arrow.
                        newArrowPoint = node.Center;

                        // The preview arrow starts not on the edge of the circle, but on the center,
                        // so that when the cursor is inside the node, the arrow isn't visible.
                        Shapes.DrawArrow(window.previewArrow, newArrowPoint, p);
                        newArrowNode = nodeInRange;
                        addNewArrow = true;

                        // Z index for the arrow not to be seen when the cursor is inside the node.
                        Panel.SetZIndex(node.Circle, 100000);
                        Panel.SetZIndex(node.IndexText, 100000);
                        
                        return;
                    }
                }
                else
                {
                    // Add a node to the position of the mouse.
                    window.AddNode(p);
                    return;
                }
            }

            // Try to start moving the node that is being dragged.
            if (mouseOnNode && e.RightButton == MouseButtonState.Pressed)
            {
                // Start Moving the node
                Node node = window.nodes[mouseNode];

                movedNode = mouseNode;
                moveNode = true;

                // Remember the position of the cursor on the node, so that dragging seems natural.
                movedNodePosition = new Point(p.X - (double)node.Circle.GetValue(Window.LeftProperty),
                                              p.Y - (double)node.Circle.GetValue(Window.TopProperty));
                return;
            }

            // If the delete button is pressed and the cursor is in range of the node.
            if (e.MiddleButton == MouseButtonState.Pressed && mouseOnNode)
            {
                // Remove the node
                window.RemoveNode(mouseNode);
                return;
            }

            // The key of the arrow in the dictionary.
            bool arrowIsInRange = window.FindArrowInRange(out Edge edge, p, window.arrowHitBoxSize);

            // If the delete button is pressed and the cursor is in range of the arrow.
            if (e.MiddleButton == MouseButtonState.Pressed && arrowIsInRange)
            {
                // Remove that arrow.
                window.RemoveEdge(edge);
                return;
            }
        }

    }
}