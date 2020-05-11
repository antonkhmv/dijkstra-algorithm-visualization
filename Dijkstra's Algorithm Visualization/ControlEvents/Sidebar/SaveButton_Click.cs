using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Graph g = new Graph();
            g.GetFromDrawing(edges, nodes, SelectedNode);

            var file = listBoxFiles.SelectedIndex;

            RefreshOptions();

            // If file is deleted or moved
            if (IOErrorMessage.IsVisible)
            {
                return;
            }

            listBoxFiles.SelectedIndex = file;

            string path = string.Empty;

            if (file >= 0)
            {
                // If there's an error while saving a file, show an error message.
                path = '.' + loadPath + Files[file];
            }

            if (!g.SaveAsFile(path))
            {
                IOErrorMessage.Text = "Ошибка при сохранении файла.";
                IOErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            IOErrorMessage.Text = string.Empty;
            IOErrorMessage.Visibility = Visibility.Collapsed;
        }
    }
}