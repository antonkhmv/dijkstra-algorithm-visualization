using Drawing;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        StrategyButtons strategySelectedButton = StrategyButtons.DrawButton;

        public enum StrategyButtons
        {
            StartButton,
            DrawButton,
            DeleteButton,
            ChangeEdgeWeightButton,
        }

        /// <summary>
        /// A dictionary with strategies.
        /// </summary>
        private static readonly Dictionary<StrategyButtons, Strategy> strategies
            = new Dictionary<StrategyButtons, Strategy>()
        {
                { StrategyButtons.StartButton, new StartStrategy() },
                { StrategyButtons.DrawButton, new DrawingStrategy() },
                { StrategyButtons.DeleteButton, new DeleteStrategy() },
                { StrategyButtons.ChangeEdgeWeightButton, new ChangeEdgeWeightStartegy() }
        };

        private void StrategySwitchButton_Click(object sender, RoutedEventArgs e)
        {
            // Try to parse the name of the button to an enum with all the button types.
            if (sender as Button == null || !Enum.TryParse((sender as Button).Name, out StrategyButtons button))
            {
                return;
            }

            // If a different button is selected.
            if (strategySelectedButton != button)
            {
                switch (button)
                {
                    case StrategyButtons.StartButton:

                        // If no nodes are selected and the start button is pressed
                        if (SelectedNode == -1)
                        {
                            // Dispaly error message
                            SelectedNodeErrorMessage.Text = "Начальная вершина не выбрана.";
                            return;
                        }
                        // else
                        SelectedNodeErrorMessage.Text = string.Empty;

                        // Enable Start panels & disable the sidebar
                        PlayerPanel.IsEnabled = true;
                        SelectNodePanel.IsEnabled = false;
                        Sidebar.Visibility = Visibility.Collapsed;
                        removeAllButton.Visibility = Visibility.Collapsed;
                        Code.Visibility = Visibility.Visible;

                        // Build the algorithm.
                        sequence = new Sequence(this);
                        sequence.BuildN2();
                        frameSlider.Value = 0;

                        // Set the code and the description to the starting
                        // position and reset the player.
                        SelectCodeBlock(CodeBlock.Start);
                        ChangeDescription(CodeBlock.Start);
                        ResetPlayer();

                        // If there are negative edges, show a warning.
                        if (CheckForNegativeEdges())
                        {
                            negativeEdgesWarning.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            negativeEdgesWarning.Visibility = Visibility.Collapsed;
                        }

                        // Set player to auto forward.
                        Plyer_SwitchButton(AutoForward, e);
                        break;

                    case StrategyButtons.ChangeEdgeWeightButton:
                        changeEdgeWeightPanel.Visibility = Visibility.Visible;
                        removeAllButton.Visibility = Visibility.Collapsed;
                        break;
                }

                
                // If the button is changed from the change weight button.
                if (strategySelectedButton == StrategyButtons.ChangeEdgeWeightButton)
                {
                    if (selectedEdge != null)
                    {
                        // Unselect the selected edge.
                        Shapes.SetArrowType(selectedEdge.Arrow, ArrowType.Standard);
                        selectedEdge = null;
                    }
                    changeEdgeWeightPanel.Visibility = Visibility.Collapsed;

                    if (button != StrategyButtons.StartButton)
                    {
                        removeAllButton.Visibility = Visibility.Visible;
                    }
                }

                // If the button is changed from the start button.
                if (strategySelectedButton == StrategyButtons.StartButton)
                {
                    // Disable start button panels
                    PlayerPanel.IsEnabled = false;
                    SelectNodePanel.IsEnabled = true;
                    Sidebar.Visibility = Visibility.Visible;
                    Code.Visibility = Visibility.Collapsed;
                    if (button != StrategyButtons.ChangeEdgeWeightButton)
                    {
                        removeAllButton.Visibility = Visibility.Visible;
                    }

                    // Stop the player and clear the nodes and edges.
                    StopPlayer();
                    ClearAllNodesAndEdges();
                    Shapes.SetCircleType(nodes[SelectedNode], CircleType.Selected);
                }


                // Change the strategy and buttons' styles.
                currentStrategy = strategies[button];
                strategyButtons[button].Style = this.FindResource("SwitchButtonSelected") as Style;
                strategyButtons[strategySelectedButton].Style = this.FindResource("SwitchButton") as Style;

            }
            strategySelectedButton = button;
        }
    }
}