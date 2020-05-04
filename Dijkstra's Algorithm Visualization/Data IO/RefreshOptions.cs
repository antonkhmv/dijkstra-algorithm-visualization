using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // A Collection of all avaliable file options for saving and loading the graph.
        public ObservableCollection<string> Files { get; set; } = new ObservableCollection<string>();

        /// <summary>
        /// Refreshes the file choice options.
        /// </summary>
        public void RefreshOptions()
        {
            Files.Clear();
            string path = Directory.GetCurrentDirectory();
            var dir = Directory.GetFiles(path, "*.grp");
            foreach (var file in dir)
            {
                Files.Add(file.Substring(file.LastIndexOf("\\") + 1));
            }
            if (Files.Count == 0)
            {
                File.Create("output.grp");
                Files.Add("output.grp");
            }
        }
    }
}