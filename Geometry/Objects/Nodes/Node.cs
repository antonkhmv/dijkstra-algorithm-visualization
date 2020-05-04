using Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Dijkstra_Algorithm_Visualization
{
    public class Node
    {
        /// <summary>
        /// The diameter of a standard node.
        /// </summary>
        public static double Diameter = 26.0;
                                                 
        public static bool isIndexTextVisible = true;

        public static bool isNodeTextIndex = true;

        public TextBlock Text { get; set; }

        public Ellipse Circle { get; set; }

        private double distance;

        /// <summary>
        /// Shortest distance from the selected node to this node.
        /// </summary>
        public double Distance { 
            get => distance; 
            set {
                distance = value;
                if (!isNodeTextIndex)
                   UpdateText(value.ToString());
            }
        }

        private int index;
        public int Index
        {
            get => index;
            set {
                index = value;
                if (isNodeTextIndex)
                    UpdateText(value.ToString());
            }
        }

        public void UpdateText(string value)
        {
            // Every time the text inside the node changes, update it.
            Text.Text = value;

            // Measures the size of the new textblock.
            Text.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            Text.Arrange(new Rect(Text.DesiredSize));
            Text.SetValue(Window.LeftProperty,
                (double)Circle.GetValue(Window.LeftProperty) + Diameter / 2.0 - Text.ActualWidth / 2.0);
            Text.SetValue(Window.TopProperty,
                (double)Circle.GetValue(Window.TopProperty) + Diameter / 2.0 - Text.ActualHeight / 2.0);
        }

        /// <summary>
        /// The center of the circle.
        /// </summary>
        public Point Center { get => Drawing.Geometry.FindCenterOfCircle(Circle); }

        /// <summary>
        /// A node object with a circle, index and a center.
        /// </summary>
        public Node(double x, double y, int index)
        {
            Circle = Shapes.Circle(Shapes.CircleStyle);
            Circle.SetValue(Window.LeftProperty, x - Diameter / 2.0);
            Circle.SetValue(Window.TopProperty, y - Diameter / 2.0);

            Text = new TextBlock()
            {
                Foreground = Brushes.Black,
                FontWeight = FontWeights.SemiBold,
                Padding = new Thickness(1, 0, 1, 0)
            };

            Index = index;
            Distance = double.PositiveInfinity;
                                             
            Text.SetValue(Window.LeftProperty, x - Text.ActualWidth / 2.0);
            Text.SetValue(Window.TopProperty, y - Text.ActualHeight / 2.0);

        }

        public void SetPosition(Point p)
        {
            Circle.SetValue(Window.LeftProperty, p.X);
            Circle.SetValue(Window.TopProperty, p.Y);

            Text.SetValue(Window.LeftProperty, p.X + Diameter / 2.0 - Text.ActualWidth / 2.0);
            Text.SetValue(Window.TopProperty, p.Y + Diameter / 2.0 - Text.ActualHeight / 2.0);
        }
    }
}