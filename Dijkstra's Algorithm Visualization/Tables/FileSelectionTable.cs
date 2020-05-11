using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Dijkstra_Algorithm_Visualization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        // A Collection of all avaliable file options for saving and loading the graph.
        public ObservableCollection<string> files = new ObservableCollection<string>();
        public ObservableCollection<string> Files
        {
            get => files;
            set {
                files = value;
                OnPropertyChanged("Files");
            }
        }
    }
}