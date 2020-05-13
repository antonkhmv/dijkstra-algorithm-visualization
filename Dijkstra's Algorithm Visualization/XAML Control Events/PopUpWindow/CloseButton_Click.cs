using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            OverlayWindow.Visibility = Visibility.Collapsed;

            if (selectedPopUpType == PopUpType.DrawingExplanation)
            {
                DrawingExplanationPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                AlgorithmExplanationPanel.Visibility = Visibility.Collapsed;
            }
        }
    }
}