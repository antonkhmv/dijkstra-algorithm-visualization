using Dijkstra_Algorithm_Visualization;
using System.Windows.Media;

namespace Drawing
{
    /// <summary>
    /// Types for nodes colors for the visualization.
    /// </summary>
    public enum CircleType
    {
        /// <summary>
        /// Standard, black color of the node.
        /// </summary>
        Standard,

        /// <summary>
        /// Node color after it has been selected.
        /// </summary>
        Selected,

        /// <summary>
        /// Node color after it has been visited.
        /// </summary>
        Visited,

        /// <summary>
        /// Node color after it has been checked.
        /// </summary>
        Checked,

        /// <summary>
        /// Node color when it is currently the node with the minimum distance.
        /// </summary>
        Min
    }

    public static partial class Shapes
    {

        /// <summary>
        /// Fill color of all nodes.
        /// </summary>
        public static SolidColorBrush NodeFillColor = Brushes.GhostWhite;

        /// <summary>
        /// Border thickness of all nodes.
        /// </summary>
        public static double NodeThickness = 2;

        /// <summary>
        /// Sets the type of the node to "type".
        /// </summary>
        /// <param name="node"></param>
        /// <param name="type"></param>
        public static void SetCircleType(Node node, CircleType type)
        {
            node.Circle.Fill = NodeFillColor;
            node.Circle.StrokeThickness = NodeThickness;


            switch (type)
            {
                case CircleType.Standard:
                    node.Circle.Stroke = Brushes.Black;
                    break;

                case CircleType.Checked:
                    node.Circle.Stroke = Brushes.LawnGreen;
                    break;

                case CircleType.Min:
                    node.Circle.Stroke = Brushes.Aqua;
                    break;

                case CircleType.Selected:
                    node.Circle.Stroke = new SolidColorBrush(Color.FromArgb(0xff, 0x32, 0x97, 0xfd));
                    break;

                case CircleType.Visited:
                    node.Circle.Stroke = Brushes.OrangeRed;
                    break;
            }
        }
    }
}