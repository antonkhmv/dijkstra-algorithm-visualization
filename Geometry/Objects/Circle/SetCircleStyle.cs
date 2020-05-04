using Dijkstra_Algorithm_Visualization;

namespace Drawing
{
    public partial class Shapes
    {
        /// <summary>
        /// Sets the style of a cirle to "style"
        /// </summary>
        public static void SetCircleStyle(Node node, Style style)
        {
            node.Circle.Fill = style.Fill;
            node.Circle.Stroke = style.Stroke;
            node.Circle.StrokeThickness = style.StrokeThickness;
        }
    }
}