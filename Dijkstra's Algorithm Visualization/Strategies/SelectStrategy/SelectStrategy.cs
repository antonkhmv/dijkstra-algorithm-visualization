using Drawing;
using System.Windows;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class SelectStrategy : Strategy
    {
        public override void Border_MouseDown(MainWindow window, object sender, MouseButtonEventArgs e)
        {
            // The position of the mouse.   
            Point p = GetMousePosition(e, sender);

            bool mouseOnNode = window.FindNodeInRange(out int node, p, Node.Diameter / 2.0);

            // If the select button is pressed and the mouse is on the node.
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // If a node is selected.
                if (window.SelectedNode != -1)
                {
                    // Unselect it
                    window.UnselectCurrentNode();
                }

                if (mouseOnNode)
                {
                    // Select the node  
                    window.SelectNode(node);
                    window.SelectedNodeErrorMessage.Text = string.Empty;
                }
            }

        }
    }
}


