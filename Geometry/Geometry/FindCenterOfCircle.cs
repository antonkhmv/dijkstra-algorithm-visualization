using System.Windows.Shapes;
using System.Windows;

namespace Drawing
{
    public partial class Geometry
    {
        /// <summary>
        /// Finds the center of a given circle.
        /// </summary>
        /// <param name="circle">The circle.</param>
        /// <returns>The center of that circle.</returns>
        public static Point FindCenterOfCircle(Ellipse circle)
        {
            var circleRadius = circle.Width / 2.0;
            return new Point((double)circle.GetValue(Window.LeftProperty) + circleRadius, 
                             (double)circle.GetValue(Window.TopProperty) + circleRadius);
        }
    }
}