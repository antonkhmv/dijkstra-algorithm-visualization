using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Drawing
{
    public partial class Geometry
    {
        // <summary>
        /// Get the size of the text to measure the 
        /// </summary>
        /// <returns></returns>
        public static Size MeasureString(string text, Typeface typeface, double fontSize)
        {
            var formattedText = new FormattedText(
                text, CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                typeface, fontSize, Brushes.Black);
            return new Size(formattedText.Width, formattedText.Height);
        }
    }
}