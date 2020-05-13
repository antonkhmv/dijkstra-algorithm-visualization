using Drawing;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        Button selectedSidebarButton;

        private void SidebarSwitch_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var name = (string)button.Name;
                   
            // Show examples panel
            if (name == "examplesButton")
            {
                SaveAndLoadPanel.Visibility = Visibility.Collapsed;
                ExamplesPanel.Visibility = Visibility.Visible;
                loadPath = @"\Examples\";
            }
            // Show save and load panel
            else
            {
                SaveAndLoadPanel.Visibility = Visibility.Visible;
                ExamplesPanel.Visibility = Visibility.Collapsed;
                loadPath = @"\Saves\";
            }

            button.Style = this.FindResource("SwitchButtonSelected") as Style;
            
            // Refresh the avaliable files 
            if (selectedSidebarButton != null && selectedSidebarButton != button)
            {
                selectedSidebarButton.Style = this.FindResource("SwitchButton") as Style;
                RefreshOptions();
                IOErrorMessage.Text = string.Empty;
                IOErrorMessage.Visibility = Visibility.Collapsed;
            }
            selectedSidebarButton = button;
        }
    }
}