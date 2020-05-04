using System.Windows;
using System;

namespace Drawing
{
    public partial class Geometry
    {
        /// <summary>
        /// Finds the distance between two points.
        /// </summary>
        /// <param name="first">The first point.</param>
        /// <param name="second">The second point.</param>
        /// <returns>The distance between the points.</returns>
        public static double Distance(Point first, Point second)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2.0) + Math.Pow(first.Y - second.Y, 2.0));
        }

        /// <summary>
        /// Finds the distance between the end points of two vectors
        /// </summary>
        /// <param name="first">The first vector.</param>
        /// <param name="second">The second vector.</param>
        /// <returns>The distance between the end points.</returns>
        public static double Distance(Vector first, Vector second)
        {
            return Math.Sqrt(Math.Pow(first.X-second.X, 2.0) + Math.Pow(first.Y-second.Y, 2.0));
        }

        /// <summary>
        /// Returns the midpoint of a segment
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point Midpoint(Point a, Point b) => (Point)(((Vector)a + (Vector)b) / 2);

        /// <summary>
        /// Returns angle from two points
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double GetAngle(Point a, Point b)
        {
            if (a == b)
            {
                return 0;
            }

            return Math.Atan2((a - b).Y, (a - b).X) * 180.0 / Math.PI;
        }
    }
}
