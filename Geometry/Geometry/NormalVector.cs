using System.Windows;

namespace Drawing
{
    public partial class Geometry
    {
        /// <summary>
        /// Finds the normal vector of a given vector.
        /// </summary>
        /// <param name="start">The initial point of a vector.</param>
        /// <param name="end">The terminating point of a vector.</param>
        /// <returns>The normal vector of the given vector.</returns>
        public static Vector NormalVector(Point start, Point end)
        {
            var vec = end - start;
            return new Vector(vec.Y, -vec.X);
        }

        /// <summary>
        /// Finds the normal vector of a given vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The normal vector of the given vector.</returns>
        public static Vector NormalVector(Point vector)
        {
            return new Vector(vector.Y, -vector.X);
        }
    }
}