using System;
using System.Windows.Media;
using System.Windows;
using System.Linq;

namespace Drawing
{
    public partial class ArrowStyle
    {
        /// <summary>
        /// Creates a PathGeometry obeject of an arrow.
        /// </summary>
        /// <param name="start">The initial point of the arrow.</param>
        /// <param name="end">The terminating point of the arrow.</param>
        /// <param name="angle">The arrow head angle.</param>
        /// <param name="headLength">The arrow head length.</param>
        public PathGeometry StraightArrow(Point start, Point end)
        {
            // Create a PathFigure object of the arrow
            var arrow = new PathFigure() { StartPoint = start, IsClosed = false, IsFilled = true };
            
            // Find a vector collinear to the arrow and with length {headLength}
            var vec = (start-end);
            vec.Normalize();
            vec *= HeadLength;
            
            // Find a point in the middle of arrow head points.
            var pnt = Geometry.ToVector(end) + vec;

            // Find a normal vector of the arrow vector.
            var normalVec = Geometry.NormalVector(start, end);
            normalVec.Normalize();
            normalVec *= Math.Tan(HeadAngle) * HeadLength;

            var tVec = 0.5 * Thickness * normalVec / normalVec.Length;

            var points = new Vector[]
            {
                Geometry.ToVector(start) + tVec,
                pnt + tVec, pnt + normalVec,
                Geometry.ToVector(end),
                pnt - normalVec, pnt - tVec,
                Geometry.ToVector(start) - tVec
            }  
            .Select(x => Geometry.ToPoint(x));

            foreach (var p in points)
            {
                arrow.Segments.Add(new LineSegment(p, true));
            }

            var pg = new PathGeometry();
            pg.Figures.Add(arrow);
            return pg;
        }
    }
}
