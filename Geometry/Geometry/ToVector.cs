using System.Windows;

namespace Drawing
{
    public partial class Geometry
    {
        /// <summary>
        /// Converts a point to a vector.
        /// </summary>
        /// <param name="p">The point.</param>
        /// <returns>The vector.</returns>
        public static Vector ToVector(Point p)
        {
            return new Vector(p.X, p.Y);
        }
    }
}