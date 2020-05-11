using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Dijkstra_Algorithm_Visualization
{
    /// <summary>
    /// Type (direction) of the arrow.
    /// </summary>
    public enum DirectionType
    {
        /// <summary>
        /// From the first node to the second.
        /// </summary>
        Forward = 1,

        /// <summary>
        /// From the second node to the first.
        /// </summary>
        Backward = -1,

        /// <summary>
        /// Both ways.
        /// </summary>
        Double = 0
    }

    public class Edge
    {
        /// <summary>
        /// The length of the distance between the center of the label and the center of the arrow
        /// for Single arrow edges.
        /// </summary>
        private static readonly double TextSingleLength = 10.0;

        /// <summary>
        /// The length of the distnace between the center of the label and the center of the arrow
        /// for Double arrow edges.
        /// </summary>
        private static readonly double TextDoubleLength = 13.0;

        /// <summary>
        /// How many pixels are in one unit of length.
        /// </summary>
        private static readonly double UnitLenth = 40.0;

        /// <summary>
        /// The weight of the edge. 
        /// </summary>
        public double Weight
        {
            get => System.Math.Round(WeightHasValue ? 
                weight : Drawing.Geometry.Distance(FirstNode.Center, SecondNode.Center) / UnitLenth, 1);
            set => weight = value;
        }

        /// <summary>
        /// Determines if the weight of the edge has a value.
        /// </summary>
        public bool WeightHasValue => !double.IsNaN(weight);

        /// <summary>
        /// The first number in the key of this edge.
        /// </summary>
        public int First { get => FirstNode.Index; }

        /// <summary>
        /// The second number in the key of this edge.
        /// </summary>
        public int Second { get => SecondNode.Index; }

        /// <summary>
        /// The node the edge is coming from.
        /// </summary>
        public int From => Direction == DirectionType.Forward ? First : Second;

        /// <summary>
        /// The node the edge is coming into.
        /// </summary>
        public int To => Direction == DirectionType.Forward ? Second : First;

        /// <summary>
        /// Actual weight of the edge (set by an adjacency list); default value: NaN.
        /// </summary>
        private double weight;

        /// <summary>
        /// Forward - from {This} to {Other}, Backward - from {Other} to {This}, Double - both directions.
        /// </summary>
        public DirectionType Direction { get; set; }

        /// <summary>
        /// The path object of the arrow.
        /// </summary>
        public Path Arrow { get; set; }

        /// <summary>
        /// Always returns the first added edge 
        /// </summary>
        public Edge FirstEdge { get; set; }

        /// <summary>
        ///  Always returns the last added edge 
        /// </summary>
        public Edge SecondEdge { get => FirstEdge.Opposite; }

        /// <summary>
        /// The first node of the edge.
        /// </summary>
        public Node FirstNode { get; set; }

        /// <summary>
        /// The second node of the edge.
        /// </summary>
        public Node SecondNode { get; set; }

        /// <summary>
        /// TextBlock with the wieght of the edge.
        /// </summary>
        public TextBlock WeightText { get; set; }

        /// <summary>
        /// Updates the position and the rotation of the wieght text.
        /// </summary>
        public void UpdateText()
        {
            WeightText.Text = Weight.ToString();

            double angle = Drawing.Geometry.GetAngle(SecondNode.Center, FirstNode.Center);

            var normalVec = Drawing.Geometry.NormalVector(FirstNode.Center, SecondNode.Center);
            normalVec.Normalize();

            if (System.Math.Abs(angle) > 90.0)
            {
                if (Direction != DirectionType.Double || Weight == Opposite.Weight)
                    normalVec *= -1;

                angle += 180.0;
            }
            normalVec *= Direction == DirectionType.Double ? TextDoubleLength : TextSingleLength;
            Point p = normalVec + Drawing.Geometry.Midpoint(FirstNode.Center, SecondNode.Center);

            WeightText.SetValue(Window.LeftProperty, System.Math.Round(p.X - WeightText.ActualWidth / 2.0, 1));
            WeightText.SetValue(Window.TopProperty, System.Math.Round(p.Y - WeightText.ActualHeight/ 2.0, 1));

            WeightText.RenderTransform = new RotateTransform(angle, WeightText.ActualWidth / 2.0, WeightText.ActualHeight / 2.0);
        }

        /// <summary>
        /// Changes opposite edge weight visibilty when the weights are not equal.
        /// </summary>
        public void UpdateTextVisiblity()
        {
            if (SecondEdge.Weight == FirstEdge.Weight && SecondEdge.WeightText.IsVisible)
            {
                SecondEdge.WeightText.SetValue(UIElement.VisibilityProperty, Visibility.Hidden);
            }
            if (SecondEdge.Weight != FirstEdge.Weight && !SecondEdge.WeightText.IsVisible)
            {
                SecondEdge.WeightText.SetValue(UIElement.VisibilityProperty, Visibility.Visible);
            }
        }
                    
        /// <summary>
        /// Calculates the Boundries of the weight text
        /// </summary>
        public void UpdateTextBoundries()
        {
            // Measures the size of the new textblock.
            WeightText.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            WeightText.Arrange(new Rect(WeightText.DesiredSize));
        }

        // Edges are used in the collection EdgeCollection, so it makes sence to give every edge a 
        // From, To, First and Second property; First and Second are for identifying the key of that edge,
        // and From and To are for identifying the end and the begining nodes of that edge.

        /// <summary>
        /// Creates an Edge object from this to other with an arrow object "arrow"
        /// </summary>
        /// <param name="this">The begining node of the edge.</param>
        /// <param name="other">The ending node of the edge.</param>
        /// <param name="arrow">The arrow object of the edge.</param>
        public Edge(Node firstNode, Node secondNode, DirectionType type, Path arrow, double weight = double.NaN)
        {
            FirstNode = firstNode;
            SecondNode = secondNode;
            Direction = type;
            Arrow = arrow;
            this.weight = weight;

            WeightText = new TextBlock()
            {
                Foreground = Brushes.Black
            };

            WeightText.Text = Weight.ToString();

            UpdateTextBoundries();
            UpdateText();
        }

        /// <summary>
        /// Creates an arrow with an opposite direction and with the same endnodes, but in a different order.
        /// </summary>
        /// <returns></returns>
        public Edge Opposite { get; set; }
    }
}