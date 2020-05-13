using System;
using System.Windows;

namespace Drawing
{
    public partial class Geometry
    {
        /// <summary>
        /// Finds out if a point is within the range of an arrow.
        /// </summary>
        /// <param name="pt">The point checked.</param>
        /// <param name="p1">The begining of the arrow.</param>
        /// <param name="p2">The end of the arrow.</param>
        /// <param name="radius">The range of the arrow</param>
        /// <returns></returns>
        public static bool IsInRangeOfLine(Point pt, Point p1, Point p2, double a, double b)
        {
            // x & y components of the arrow vector.
            Vector d = p2 - p1;

            // The length of the projection of the vector from p1 to pt.
            double t = ((pt.X - p1.X) * d.X + (pt.Y - p1.Y) * d.Y) / (d.X * d.X + d.Y * d.Y);

            // The projection of the point on that arrow.
            var projection = p1 + t * d;

            d = pt - projection;

            // If the projection of pt is in between p1 and p2, this number is zero, otherwise, it's not zero.
            bool check = Math.Abs(Distance(p1, p2) - Distance(p1, projection) - Distance(projection, p2)) < 1e-8;
            double direction = Vector.CrossProduct(d, p2 - p1);

            // If is in range and the number is zero (within a margin of error) and pt is within the range of the arrow.
            if (check && ((Math.Sqrt(d.X * d.X + d.Y * d.Y) <= -a && direction >= 0)
                || (Math.Sqrt(d.X * d.X + d.Y * d.Y) <= b && direction < 0)))
            {
                return true;
            }
            return false;
        }
    }
}