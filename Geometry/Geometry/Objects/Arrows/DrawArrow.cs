using Dijkstra_Algorithm_Visualization;
using System.Windows;
using System.Windows.Shapes;

namespace Drawing
{
    /// <summary>
    /// Arrow display variations
    /// </summary>
    public enum ArrowDirection
    {
        /// <summary>
        /// An arrow that looks like "<---" or "--->"
        /// </summary>
        Single,

        /// <summary>
        /// Two single arrows pointing in opposite directions.
        /// </summary>
        Double,
    }

    /// <summary>
    /// An enum for all possible arrow colors
    /// </summary>
    public enum ArrowType
    {
        /// <summary>
        /// Standard (black) color of the arrow.
        /// </summary>
        Standard,

        /// <summary>
        /// Arrow color when it is seleced for its edge weight to be changed
        /// </summary>
        Selected,

        /// <summary>
        /// Arrow color after being relaxed
        /// </summary>
        Relaxed,

        /// <summary>
        /// Arrow color after not being relaxed
        /// </summary>
        NotRelaxed,

        /// <summary>
        /// Arrow color when it is waiting to be relaxed, or if it hasn't relaxed at all.
        /// </summary>
        Waiting
    }

    public static partial class Shapes
    {
        /// <summary>
        /// Half of the angle between the arrows in edges with direction "Double".
        /// </summary>
        public static double doubleArrowAngle = System.Math.PI / 15.0;

        /// <summary>
        /// Draw a single arrow from point "from" to point "to"
        /// </summary>
        /// <param name="arrow">The Arrow object.</param>
        /// <param name="from">Begining point.</param>
        /// <param name="to">Ending point.</param>
        public static void DrawArrow(Path arrow, Point from, Point to)
        {
            arrow.Data = StraightArrow(from, to);
       
        }

        /// <summary>
        /// Updates the position of an arrow.
        /// </summary>
        /// <param name="edge">The edge to be updated.</param>
        /// <param name="type">The new type of the arrow.</param>
        public static void UpdateArrowPosition(Edge edge, ArrowDirection type)
        {

            Edge forward = edge.FirstEdge, backward = edge.SecondEdge;

            // Get first and second arrow.
            Path arrow = forward.Arrow, opposite = backward.Arrow;
            
            // Node centers of this edge.
            Point from = forward.FirstNode.Center, to = forward.SecondNode.Center;

            // Draw a single arrow
            if (type == ArrowDirection.Single)
            {
                // The begining & end points of this single arrow.
                var begin = Shapes.FindPointOnCircle(to, from);
                var end = Shapes.FindPointOnCircle(from, to);

                arrow.Data = StraightArrow(begin, end);
                return;
            }

            // Draw two single arrows pointing in opposite directions.
            if (type == ArrowDirection.Double)
            {
                // If the second arrow is invsible (since the edge was "Single" before)
                if (opposite.Visibility == Visibility.Hidden)
                {
                    // Show it.
                    opposite.SetValue(UIElement.VisibilityProperty, Visibility.Visible);
                }

                // The begining & end points of the first arrow.
                Point begin1 = FindPointOnCircle(to, from, doubleArrowAngle);
                Point end1 = FindPointOnCircle(from, to, -doubleArrowAngle);

                // The begining & end points of the second arrow.
                Point begin2 = FindPointOnCircle(to, from, -doubleArrowAngle);
                Point end2 = FindPointOnCircle(from, to, doubleArrowAngle);

                arrow.Data = StraightArrow(begin1, end1);
                opposite.Data = StraightArrow(end2, begin2);
                return;
            }
        }
    }
}