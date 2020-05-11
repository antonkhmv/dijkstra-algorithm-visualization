using Dijkstra_Algorithm_Visualization;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Drawing
{
    public partial class Shapes
    {
        public static Ellipse Circle(Style style)
        {
            var circle = new Ellipse() { Height = Node.Diameter, Width = Node.Diameter };
            circle.Fill = style.Fill;
            circle.Stroke = style.Stroke;
            circle.StrokeThickness = style.StrokeThickness;
            return circle;
        }
    }
}