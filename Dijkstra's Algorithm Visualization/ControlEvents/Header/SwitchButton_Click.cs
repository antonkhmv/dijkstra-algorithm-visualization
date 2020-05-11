using Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// A dictionary with strategies.
        /// </summary>
        private static readonly Dictionary<string, Strategy> strategies = new Dictionary<string, Strategy>() {
                { "startButton", new StartStrategy() },
                { "drawButton", new DrawingStrategy() },
                { "deleteButton", new DeleteStrategy() },
                { "selectButton", new SelectStrategy() },
                { "changeEdgeWeightButton", new ChangeEdgeWeightStartegy() }
            };

        Button selectedButton;

        private void SwitchButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var name = (string) button.Name;

            // If no nodes are selected and the start button is pressed
            if (name == "startButton" && SelectedNode == -1)
            {
                // Dispaly error message
                SelectedNodeErrorMessage.Text = "Начальная вершина не выбрана.";
                return;
            }
            
            currentStrategy = strategies[name];

            button.Style = this.FindResource("SwitchButtonSelected") as Style;
            if (selectedButton != null && selectedButton != button)
            {
                selectedButton.Style = this.FindResource("SwitchButton") as Style;  

                // The player panel is only avalible when the start button is pressed.
                if (button == startButton)
                {
                    SelectedNodeErrorMessage.Text = string.Empty;

                    PlayerPanel.IsEnabled = true;
                    SelectNodePanel.IsEnabled = false;
                    Sidebar.Visibility = Visibility.Collapsed;    
                    Code.Visibility = Visibility.Visible;
                    
                    SelectCodeBlock(CodeBlock.Start);
                    ChangeDescription(CodeBlock.Start);
                    StartButton_Click(sender, e);
                    Plyer_SwitchButton(AutoForward, e);
                }
                else
                {
                    PlayerPanel.IsEnabled = false;
                    SelectNodePanel.IsEnabled = true;
                    Sidebar.Visibility = Visibility.Visible;
                    Code.Visibility = Visibility.Collapsed;
                }

                // Show / Hide Change Weight panel.
                if (button == changeEdgeWeightButton)
                {
                    changeEdgeWeightPanel.Visibility = Visibility.Visible;
                }
                else
                {
                    if (selectedEdge != null)
                    {
                        // Unselect the selected edge.
                        ArrowStyle.Normal.SetStlye(selectedEdge.Arrow);
                        selectedEdge = null;
                    }
                    changeEdgeWeightPanel.Visibility = Visibility.Collapsed;
                }

                // If the button is changed from the start button.
                if (selectedButton == startButton)
                {
                    frameSlider.Value = 0;
                    StopPlayer();
                    ClearAllNodesAndEdges();
                    Shapes.SetCircleStyle(nodes[SelectedNode], Shapes.CircleSelectedStyle);
                }
            }
            selectedButton = button;
        }
    }
}