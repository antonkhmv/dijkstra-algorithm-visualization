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
        public static bool IsInRangeOfLine(Point pt, Point p1, Point p2, double radius)
        {
            // x & y components of the arrow vector.
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;

            // The length of the projection of the vector from p1 to pt.
            double t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) /
                (dx * dx + dy * dy);

            // The projection of the point on that arrow.
            var projection = new Point(p1.X + t * dx, p1.Y + t * dy);
            dx = pt.X - projection.X;
            dy = pt.Y - projection.Y;

            // If the projection of pt is in between p1 and p2, this number is zero, otherwise, it's not zero.
            double check = Distance(p1, p2) - Distance(p1, projection) - Distance(projection, p2);

            // If is in range and the number is zero (within a margin of error) and pt is within the range of the arrow.
            if (Math.Abs(check) < 1e-8 &&
                Math.Sqrt(dx * dx + dy * dy) <= radius)
            {
                return true;
            }
            return false;
        }
    }
}