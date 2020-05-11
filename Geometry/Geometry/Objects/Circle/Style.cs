using Dijkstra_Algorithm_Visualization;
using System.Windows.Media;

namespace Drawing
{
    public partial class Shapes
    {
        public struct Style
        {
            public SolidColorBrush Fill;
            public SolidColorBrush Stroke;
            public double StrokeThickness;
        }

        // For inherertance
        public static SolidColorBrush NodeFillColor = Brushes.GhostWhite;

        public static Style CircleStyle = new Style
        {
            Stroke = Brushes.Black,
            StrokeThickness = 2,
            Fill = NodeFillColor
        };

        public static Style CircleSelectedStyle = new Style
        {
            Stroke = new SolidColorBrush(Color.FromArgb(0xff, 0x32, 0x97, 0xFD)),
            StrokeThickness = 2,
            Fill = NodeFillColor
        };

        public static Style CircleVisitedStyle = new Style
        {
            Stroke = Brushes.OrangeRed,
            StrokeThickness = 2,
            Fill = NodeFillColor
        };

        public static Style CircleChecked = new Style
        {
            Stroke = Brushes.LawnGreen,
            StrokeThickness = 2,
            Fill = NodeFillColor
        };

        public static Style CircleMin = new Style
        {
            Stroke = Brushes.Aqua,
            StrokeThickness = 2,
            Fill = NodeFillColor
        };
    }
}