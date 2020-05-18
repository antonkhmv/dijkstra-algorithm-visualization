using System;
using System.Windows;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class DeleteStrategy : Strategy
    {
        public override void Border_MouseDown(MainWindow window, object sender, MouseButtonEventArgs e)
        {
            // The position of the mouse.   
            Point p = GetMousePosition(e, sender);

            // The index of the node.
            bool nodeIsInRange = window.FindNodeInRange(out int node, p, Node.Diameter / 2.0);

            // If the delete button is pressed and the cursor is in range of the node.
            if (e.LeftButton == MouseButtonState.Pressed && nodeIsInRange)
            {
                // Remove the node
                window.RemoveNode(node);
                return;
            }

            // The key of the arrow in the dictionary.
            bool arrowIsInRange = window.FindArrowInRange(out Edge edge, p, MainWindow.arrowHitBoxSize);

            // If the delete button is pressed and the cursor is in range of the arrow.
            if (e.LeftButton == MouseButtonState.Pressed && arrowIsInRange)
            {
                // Remove that arrow.
                window.RemoveEdge(edge);
                return;
            }
        }
    }
}