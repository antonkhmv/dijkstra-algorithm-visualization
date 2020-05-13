using Drawing;
using System.Windows;
using System.Windows.Media;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Unselects the current selected node if any node is selected.
        /// </summary>
        public void UnselectCurrentNode()
        {
            if (SelectedNode != -1)
            {
                Shapes.SetCircleType(nodes[SelectedNode], CircleType.Standard);
                SelectedNode = -1;
            }
        }

        /// <summary>
        /// Selects a node.
        /// </summary>    
        public void SelectNode(int node)
        {
            if (node < 0 || node >= nodes.Count)
                return;
            UnselectCurrentNode();
            SelectedNode = node;
            Shapes.SetCircleType(nodes[node], CircleType.Selected);
        }
    }
}
