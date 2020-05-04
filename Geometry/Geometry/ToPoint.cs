using System.Windows;

namespace Drawing
{
    public partial class Geometry
    {
        /// <summary>
        /// Converts a vector to a point.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>The point.</returns>
        public static Point ToPoint(Vector v)
        {
            return new Point(v.X, v.Y);
        }
    }
}