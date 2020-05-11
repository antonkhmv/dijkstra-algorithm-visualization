using System.IO;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {  
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            string path = '.' + loadPath + listBoxFiles.SelectedItem as string;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            RefreshOptions();

            // Supress error beacause removing is intentional.
            if (IOErrorMessage.IsVisible)
            {
                IOErrorMessage.Visibility = Visibility.Collapsed;
            }
        }
    }
}