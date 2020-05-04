using System;
using System.Windows;
using Dijkstra_Algorithm_Visualization;

namespace Drawing
{
    public partial class Arrows
    {
        /// <summary>
        /// Finds a point on a circle with center "to" and diameter "diameter" which intersects the segment {from, to}
        /// </summary>
        /// <param name="from">The first point of the segment.</param>
        /// <param name="to">The center of the circle and the second point of the segment.</param>
        /// <returns></returns>
        public static Point FindPointOnCircle(Point from, Point to)
        {
            var vec = to - from;
            return Geometry.ToPoint(Geometry.ToVector(to) - Node.Diameter * vec / (2 * vec.Length));
        }

        /// <summary>
        /// Finds a point on a circle with center "to" and diameter "diameter" which intersects the segment {from, to}
        /// </summary>
        /// <param name="from">The first point of the segment.</param>
        /// <param name="to">The center of the circle and the second point of the segment.</param>
        /// <returns></returns>
        public static Point FindPointOnCircle(Point from, Point to, 
            double angle)
        {
            var vec = to - from;

            // Rotate the vector by an angle
            vec = new Vector(vec.X * Math.Cos(angle) + vec.Y * Math.Sin(angle), 
                             vec.Y * Math.Cos(angle) - vec.X * Math.Sin(angle) );

            return Geometry.ToPoint(Geometry.ToVector(to) - Node.Diameter * vec / (2 * vec.Length));
        }
    }
}