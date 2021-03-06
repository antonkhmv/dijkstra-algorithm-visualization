﻿using Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void SetWeightButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEdge != null)
            {
                string text = SetWeightTextBox.Text;

                // Works for both separators: '.' and ','
                text = text.Replace(',', '.');

                if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double weight) 
                    || text == string.Empty)
                {
                    if (text == string.Empty)
                    {
                        selectedEdge.Weight = double.NaN;
                    }
                    // Set the edge's weight.
                    selectedEdge.Weight = weight;

                    var edge = selectedEdge.FirstEdge;
                    var opposite = selectedEdge.SecondEdge;

                    // Update the text
                    edge.UpdateTextVisiblity();

                    edge.UpdateText();
                    opposite.UpdateText();
                }

                
            }
        }
    }
}