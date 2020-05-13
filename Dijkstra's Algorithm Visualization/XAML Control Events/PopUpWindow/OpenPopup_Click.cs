using System;
using System.Windows;
using System.Windows.Controls;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        enum PopUpType
        {
            /// <summary>
            /// A popup explaining the algorithm.
            /// </summary>
            AlgorithmExplanation,

            /// <summary>
            /// A popup explaining how to build the graph.
            /// </summary>
            DrawingExplanation,

            None
        }

        private PopUpType selectedPopUpType;

        private void OpenPopup_Click(object sender, RoutedEventArgs e)
        {
            if (sender as Button == null || !Enum.TryParse((sender as Button).Name, out PopUpType type))
            {
                return;
            }

            OverlayWindow.Visibility = Visibility.Visible;

            if (type == PopUpType.DrawingExplanation)
            {
                DrawingExplanationPanel.Visibility = Visibility.Visible;
                selectedPopUpType = PopUpType.DrawingExplanation;
            }
            else
            {
                AlgorithmExplanationPanel.Visibility = Visibility.Visible;
                selectedPopUpType = PopUpType.AlgorithmExplanation;
            }

        }
    }
}
