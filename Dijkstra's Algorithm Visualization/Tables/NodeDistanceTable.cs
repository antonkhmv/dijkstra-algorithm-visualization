using System.Collections.Generic;
using System.ComponentModel;
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
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable<DistanceTableElement> NodesDistanceTable
        {
            get {
                var ans = new List<DistanceTableElement>();
                for (int i = 0; i < nodes.Count; ++i)
                {
                    ans.Add(new DistanceTableElement(
                        i,
                        Sequence.DoubleToString(nodes[i].Distance)
                    ));
                }
                return ans;
            }
        }

        public class DistanceTableElement
        {
            public string Distance { get; set; }
            public int Id { get; set; }
            public DistanceTableElement(int id, string distance)
            {
                Distance = distance;
                Id = id;
            }
        }
    }
}