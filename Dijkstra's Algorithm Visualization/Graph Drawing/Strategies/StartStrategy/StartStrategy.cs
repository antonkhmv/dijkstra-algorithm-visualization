using Drawing;
using System.Windows;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class StartStrategy : Strategy
    {
        public override void Border_MouseDown(MainWindow window, object sender, MouseButtonEventArgs e)
        {
            // The position of the mouse.   
            Point p = GetMousePosition(e, sender);

            bool mouseOnNode = window.FindNodeInRange(out int node, p, Node.Diameter / 2.0);

            // If a node is selected.
            if (window.selectedNode != -1)
            {
                Shapes.SetCircleStyle(window.nodes[window.selectedNode], Shapes.CircleStyle);
                if (!mouseOnNode)
                {
                    window.selectedNode = -1;
                }
            }

            // If the select button is pressed and the mouse is on the node.
            if (e.LeftButton == MouseButtonState.Pressed && mouseOnNode)
            {
                // Select the node
                window.selectedNode = node;
                Shapes.SetCircleStyle(window.nodes[node], Shapes.CircleSelectedStyle);
                return;
            }
        }
    }
}


