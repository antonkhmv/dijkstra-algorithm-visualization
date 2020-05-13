using System.IO;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var g = new Graph();

            // If nothing is selected, don't do anything.
            if (listBoxFiles.SelectedIndex == -1)
                return;

            var path = '.' + loadPath + listBoxFiles.SelectedItem as string;

            RefreshOptions();

            // If the file is deleted or moved
            if (IOErrorMessage.IsVisible)
            {
                return;
            }

            // If there's an error while loading a file, show an error message.
            if (!g.LoadFromFile(path))
            {
                IOErrorMessage.Text = "Ошибка загрузки файла.";
                IOErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            IOErrorMessage.Text = string.Empty;
            IOErrorMessage.Visibility = Visibility.Collapsed; 

            RemoveAllNodes();
            
            // If the graph is not valid.
            if (!this.DrawFromGraph(g))
            {
                IOErrorMessage.Text = "Ошибка при построении графа.";
                IOErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}

