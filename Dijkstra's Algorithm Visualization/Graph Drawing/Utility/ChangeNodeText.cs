using System.Windows;
using System.Windows.Media;

namespace Dijkstra_Algorithm_Visualization
{
    public enum NodeText
    {
        Index,
        Distance
    }

    public partial class MainWindow : Window
    {
        public void ChangeNodeText(NodeText nodeText)
        {

            foreach (var node in nodes)
            {
                switch (nodeText)
                {
                    case NodeText.Index:
                        node.Text.Background = Brushes.Transparent;
                        node.UpdateText(node.Index.ToString());
                        break;
                    case NodeText.Distance:
                        node.Text.Background = Drawing.Shapes.NodeFillColor;
                        node.UpdateText(node.Distance.ToString());
                        break;
                }
            }
        }

        public bool IsNodeTextIndex
        {
            get => Node.isNodeTextIndex;
            set {
                Node.isNodeTextIndex = value;

                if (value)
                {
                    ChangeNodeText(NodeText.Index);
                }
                else
                {
                    ChangeNodeText(NodeText.Distance);
                }
            }
        }
    }
}
