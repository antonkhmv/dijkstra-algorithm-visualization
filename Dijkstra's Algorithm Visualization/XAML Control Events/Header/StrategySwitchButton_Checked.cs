using Drawing;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        public enum StrategyButtons
        {
            DrawButton,
            DeleteButton,
            ChangeEdgeWeightButton,
        }

        private void StrategySwitchButton_Checked(object sender, RoutedEventArgs e)
        {
            // Try to parse the name of the button to an enum with all the button types.
            if (sender as ToggleButton == null || !Enum.TryParse((sender as ToggleButton).Name, out StrategyButtons button))
            {
                return;
            }

            switch (button)
            {
                case StrategyButtons.ChangeEdgeWeightButton:
                    currentStrategy = new ChangeEdgeWeightStartegy();
                    break;
                case StrategyButtons.DeleteButton:
                    currentStrategy = new DeleteStrategy();
                    break;
                case StrategyButtons.DrawButton:
                    currentStrategy = new DrawingStrategy();
                    break;
            }

            // Remove selection from edges.
            if (button != StrategyButtons.ChangeEdgeWeightButton)
            {
                ChangeWeight_Unchecked();
            }

        }

        private void ChangeWeight_Unchecked()
        {
            if (selectedEdge != null)
            {
                // Unselect the selected edge.
                Shapes.SetArrowType(selectedEdge.Arrow, ArrowType.Standard);
                selectedEdge = null;
            }
        }
    }
}