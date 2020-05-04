using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var g = new Graph();
            string path = fileName.Text;
            RefreshOptions();
            if (!g.LoadFromFile(path))
            {
                errorMessage.Text = "Error loading file.";
                fileName.SelectedIndex = 0;
                return;
            }
            fileName.SelectedItem = path;
            RemoveAllNodes();
            errorMessage.Text = string.Empty;
            this.DrawFromGraph(g);
            SwitchButton_Click(startButton, new RoutedEventArgs());
        }
    }
}