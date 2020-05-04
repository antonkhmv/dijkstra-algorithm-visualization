using Dijkstra_Algorithm_Visualization;
using System.Windows;
using System.Windows.Shapes;

namespace Drawing
{
    /// <summary>
    /// Arrow display variations
    /// </summary>
    public enum ArrowType
    {
        /// <summary>
        /// An arrow that looks like "<---" or "--->"
        /// </summary>
        Single,

        /// <summary>
        /// An arrow that looks like "<-->" 
        /// </summary>
        Double,

        /// <summary>
        /// Two "Single" arrows pointing in opposite directions.
        /// </summary>
        TwoSingles,
    }

    public partial class ArrowStyle
    {
        /// <summary>
        /// Half of the angle between the arrows in TwoSngles-typed edges.
        /// </summary>
        public static double twoSinglesAngle = System.Math.PI / 15.0;

        /// <summary>
        /// Draw a single arrow from point "from" to point "to"
        /// </summary>
        /// <param name="arrow">The Arrow object.</param>
        /// <param name="from">Begining point.</param>
        /// <param name="to">Ending point.</param>
        public void DrawArrow(Path arrow, Point from, Point to)
        {
            arrow.Data = StraightArrow(from, to);
        }

        /// <summary>
        /// Updates the position of an arrow.
        /// </summary>
        /// <param name="edge">The edge to be updated.</param>
        /// <param name="type">The new type of the arrow.</param>
        public void UpdateEdgePosition(Edge edge, ArrowType type)
        {
            Edge forward = edge.FirstEdge, backward = edge.SecondEdge;
            Path arrow = forward.Arrow, opposite = backward.Arrow;
            Point from = forward.FirstNode.Center, to = forward.SecondNode.Center;

            if (type == ArrowType.Single)
            {
                var begin = Arrows.FindPointOnCircle(to, from);
                var end = Arrows.FindPointOnCircle(from, to);

                arrow.Data = StraightArrow(begin, end);
                return;
            }

            if (type == ArrowType.TwoSingles)
            {
                if (opposite.Visibility == Visibility.Hidden)
                {
                    opposite.SetValue(UIElement.VisibilityProperty, Visibility.Visible);
                }

                Point begin1 = Arrows.FindPointOnCircle(to, from, twoSinglesAngle);
                Point end1 = Arrows.FindPointOnCircle(from, to, -twoSinglesAngle);

                Point begin2 = Arrows.FindPointOnCircle(to, from, -twoSinglesAngle);
                Point end2 = Arrows.FindPointOnCircle(from, to, twoSinglesAngle);

                arrow.Data = StraightArrow(begin1, end1);
                opposite.Data = StraightArrow(end2, begin2);
                return;
            }
        }
    }
}