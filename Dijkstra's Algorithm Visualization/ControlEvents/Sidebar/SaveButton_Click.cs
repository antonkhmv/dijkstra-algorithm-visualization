using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Graph g = new Graph();
            g.GetFromDrawing(edges, nodes, selectedNode);
            string path = fileName.Text;
            RefreshOptions();
            if (!g.SaveAsFile(path))
            {
                errorMessage.Text = "Error saving file.";
                fileName.SelectedIndex = 0;
            }
            else
            {
                fileName.SelectedItem = path;
                errorMessage.Text = string.Empty;
            }
        }  
    }
}