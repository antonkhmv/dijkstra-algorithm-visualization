using Drawing;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        public string LoadPath
        {
            get => loadPath;
            set
            {
                loadPath = value;
                RefreshOptions();
                if (IOErrorMessage != null)
                {
                    IOErrorMessage.Text = string.Empty;
                    IOErrorMessage.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void SidebarSwitch_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            var name = (string)button.Name;

            // Show examples panel
            if (name == "examplesButton")
            {
                LoadPath = @"\Examples\";
            }
            // Show save and load panel
            else
            {
                LoadPath = @"\Saves\";
            }

        }
    }
}