using Drawing;
using System.Windows;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class ChangeEdgeWeightStartegy : Strategy
    {
        public override void Border_MouseDown(MainWindow window, object sender, MouseButtonEventArgs e)
        {
            // The position of the mouse.   
            Point p = GetMousePosition(e, sender);

            bool edgeFound = window.FindArrowInRange(out Edge edge, p, window.arrowHitBoxSize);

            // If the select button is pressed and the mouse is on the node.
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // If a node is selected.
                if (window.selectedEdge != null)
                {
                    // Unselected it.
                    ArrowStyle.Normal.SetStlye(window.selectedEdge.Arrow);
                    window.selectedEdge = null;
                }

                if (edgeFound) {
                    // Select an edge.
                    ArrowStyle.Selected.SetStlye(edge.Arrow);
                    window.selectedEdge = edge;
                }
            }

        }
    }
}


