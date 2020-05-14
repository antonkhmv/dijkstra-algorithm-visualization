using Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{

    public partial class MainWindow : Window
    {
        static Strategy previousStrategy;

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // If no nodes are selected and the start button is pressed
            if (SelectedNode == -1)
            {
                SelectedNodeErrorMessage.Visibility = Visibility.Visible;
                // Dispaly error message
                SelectedNodeErrorMessage.Text = "Начальная вершина не выбрана.";
                return;
            }
            // else

            previousStrategy = currentStrategy;
            currentStrategy = new StartStrategy();

            SelectedNodeErrorMessage.Text = string.Empty;
            SelectedNodeErrorMessage.Visibility = Visibility.Collapsed;

            // Enable Start panels & disable the sidebar
            Code.Visibility = Visibility.Visible;
            SidebarPanel.Visibility = Visibility.Collapsed;
            ChangeWeight_Unchecked();

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
        }
    }
}