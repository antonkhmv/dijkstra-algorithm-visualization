using Drawing;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// A dictionary with strategies.
        /// </summary>
        private Dictionary<StrategyButtons, Button> strategyButtons;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Shapes.SetArrowType(previewArrow, ArrowType.Standard);
            strategySelectedButton = StrategyButtons.DrawButton;
            selectedSidebarButton = examplesButton;

            strategyButtons = new Dictionary<StrategyButtons, Button>()
            {
                    { StrategyButtons.StartButton,  StartButton },
                    { StrategyButtons.DrawButton, DrawButton },
                    { StrategyButtons.DeleteButton, DeleteButton },
                    { StrategyButtons.ChangeEdgeWeightButton, ChangeEdgeWeightButton }
            };
        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            mainGrid.Focus();
        }
    }
}
