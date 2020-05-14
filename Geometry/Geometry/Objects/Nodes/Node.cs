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

        public TextBlock IndexText { get; set; }
        public TextBlock DistanceText { get; set; }

        public Ellipse Circle { get; set; }

        private int index;

        public int Index
        {
            get => index;
            set
            {
                index = value;
                UpdateIndexText();
            }
        }

        /// <summary>
        /// Displayed distance to this node.
        /// </summary>
        public double Distance { get; set; }

        public void UpdateIndexText()
        {
            string value = Index.ToString();

            if (value != (string)IndexText.Text)
            {
                // Every time the text inside the node changes, update it.
                IndexText.Text = value;

                // Measures the size of the new textblock.
                IndexText.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                IndexText.Arrange(new Rect(IndexText.DesiredSize));
            }
            IndexText.SetValue(Window.LeftProperty,
                (double)Circle.GetValue(Window.LeftProperty) + Diameter / 2.0 - IndexText.ActualWidth / 2.0);

            IndexText.SetValue(Window.TopProperty,
                (double)Circle.GetValue(Window.TopProperty) + Diameter / 2.0 - IndexText.ActualHeight / 2.0);
        }

        /// <summary>
        /// Converts double to string and if the value is infinty, returns the symbol for inf.
        /// </summary>
        /// <returns></returns>
        public static string DoubleToString(double value)
        {
            if (double.IsPositiveInfinity(value))
                return "\u221E";
            return value.ToString();
        }

        public void UpdateDistanceText()
        {
            string value = DoubleToString(Distance);

            if (value != (string)DistanceText.Text)
            {
                // Every time the text inside the node changes, update it.
                DistanceText.Text = value;

                // Measures the size of the new textblock.
                DistanceText.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                DistanceText.Arrange(new Rect(DistanceText.DesiredSize));
            }

            DistanceText.SetValue(Window.LeftProperty,
                (double)Circle.GetValue(Window.LeftProperty) + Diameter / 2.0 - DistanceText.ActualWidth / 2.0);
            DistanceText.SetValue(Window.TopProperty,
                (double)Circle.GetValue(Window.TopProperty) + 25 + Diameter / 2.0 - DistanceText.ActualHeight / 2.0);


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
            Circle = new Ellipse() { Width = Diameter, Height = Diameter };
            Shapes.SetCircleType(this, CircleType.Standard);
            Circle.SetValue(Window.LeftProperty, x - Diameter / 2.0);
            Circle.SetValue(Window.TopProperty, y - Diameter / 2.0);

            DistanceText = new TextBlock()
            {
                Foreground = Brushes.Black,
                FontWeight = FontWeights.SemiBold,
                Padding = new Thickness(1, 0, 1, 0),
            };

            IndexText = new TextBlock()
            {
                Foreground = Brushes.Black,
                FontWeight = FontWeights.SemiBold,
                Padding = new Thickness(1, 0, 1, 0)
            };

            Index = index;
            Distance = double.PositiveInfinity;

            IndexText.SetValue(Window.LeftProperty, x - IndexText.ActualWidth / 2.0);
            IndexText.SetValue(Window.TopProperty, y - IndexText.ActualHeight / 2.0);

        }

        public void SetPosition(Point p)
        {
            Circle.SetValue(Window.LeftProperty, p.X);
            Circle.SetValue(Window.TopProperty, p.Y);

            IndexText.SetValue(Window.LeftProperty, p.X + Diameter / 2.0 - IndexText.ActualWidth / 2.0);
            IndexText.SetValue(Window.TopProperty, p.Y + Diameter / 2.0 - IndexText.ActualHeight / 2.0);
        }
    }
}