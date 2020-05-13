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
        public static Size MeasureString(string text, TextBlock textBlock)
        {
            var formattedText = new FormattedText(
                text,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(textBlock.FontFamily, textBlock.FontStyle,
                textBlock.FontWeight, textBlock.FontStretch), textBlock.FontSize,
                Brushes.Black);

            return new Size(formattedText.Width, formattedText.Height);
        }
    }
}