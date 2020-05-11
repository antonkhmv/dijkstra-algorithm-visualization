using System.Windows.Media;

namespace Drawing
{
    /// <summary>
    /// Used to construct arrows from WPF Path objects.
    /// </summary>
    public partial class ArrowStyle
    {
        public double Thickness { get; set; }
        public double HeadAngle { get; set; }
        public double HeadLength { get; set; }
        public Brush Fill { get; set; }

        public static ArrowStyle Normal = new ArrowStyle()
        {
            HeadLength = 10.0,
            HeadAngle = System.Math.PI / 12.0,
            Thickness = 1.7,
            Fill = Brushes.Black
        };
        
        public static ArrowStyle Selected = new ArrowStyle()
        {
            HeadLength = 10.0,
            HeadAngle = System.Math.PI / 12.0,
            Thickness = 1.7,
            Fill = new SolidColorBrush(Color.FromArgb(0xff, 0x32, 0x97, 0xFD))
        };

        public static ArrowStyle Relaxed = new ArrowStyle()
        {
            HeadLength = 10.0,
            HeadAngle = System.Math.PI / 12.0,
            Thickness = 1.7,
            Fill = Brushes.OrangeRed
        };

        public static ArrowStyle Waiting = new ArrowStyle()
        {
            HeadLength = 10.0,
            HeadAngle = System.Math.PI / 12.0,
            Thickness = 1.7,
            Fill = Brushes.LightGray
        };
    }
}