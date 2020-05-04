using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// A dictionary with strategies.
        /// </summary>
        private static Dictionary<string, Strategy> strategies = new Dictionary<string, Strategy>() {
                { "Delete", new DeleteStrategy() },
                { "Select", new SelectStrategy() },
                { "Draw Graph", new DrawingStrategy() },
                { "Start", new StartStrategy() },
                { "Change Edge Weight", new StartStrategy() }
            };

        Button selectedButton;

        private void SwitchButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var text = (string)button.Content;

            currentStrategy = strategies[text];

            button.Style = this.FindResource("SwitchButtonSelected") as Style;
            if (selectedButton != null && selectedButton != button)
            {
                selectedButton.Style = this.FindResource("SwitchButton") as Style; 
            }
            selectedButton = button;

            if ((string)selectedButton.Content == "Start")
            {
                frameSlider.SetValue(VisibilityProperty, Visibility.Visible);
                IteratorText.SetValue(VisibilityProperty, Visibility.Visible);
                StartButton_Click(sender, e);
            }
            else
            {
                frameSlider.SetValue(VisibilityProperty, Visibility.Hidden);
                IteratorText.SetValue(VisibilityProperty, Visibility.Hidden);
            }
        }
    }
}