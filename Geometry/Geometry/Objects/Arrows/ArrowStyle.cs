using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Drawing
{
    /// <summary>
    /// Used to construct arrows from WPF Path objects.
    /// </summary>
    public static partial class Shapes
    {
        public static double Thickness = 1.7;

        public static double HeadAngle = Math.PI / 12.0;

        public static double HeadLength = 10.0;

        /// <summary>
        /// Creates a Path object of an arrow.
        /// </summary>
        public static Path NewArrow() => new Path
        {
            // Set the standard fill for the arrow.
            Fill = Brushes.Black
        };

        /// <summary>
        /// Changes the current arrow type.
        /// </summary>
        public static void SetArrowType(Path arrow, ArrowType type)
        {
            // Set the arrow fill according to the type.
            switch (type)
            {
                case ArrowType.Standard:
                    arrow.Fill = Brushes.Black;
                    break;

                case ArrowType.Selected:
                    arrow.Fill = new SolidColorBrush(Color.FromArgb(0xff, 0x32, 0x97, 0xfd));
                    break;

                case ArrowType.Relaxed:
                    arrow.Fill = Brushes.OrangeRed;
                    break;

                case ArrowType.NotRelaxed:
                    arrow.Fill = Brushes.LightGray;
                    break;

                case ArrowType.Waiting:
                    arrow.Fill = Brushes.LightGray;
                    break;
            }
        }
    }
}