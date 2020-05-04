using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Drawing
{
    public partial class ArrowStyle
    {
        /// <summary>
        /// Creates a Path object of an arrow.
        /// </summary>
        public Path NewArrow() => new Path
        {
            Fill = Fill,
        };

        /// <summary>
        /// Changes the current style of an arrow.
        /// </summary>
        public void SetStlye(Path arrow)
        {
            arrow.Fill = Fill;
        }
    }
}
