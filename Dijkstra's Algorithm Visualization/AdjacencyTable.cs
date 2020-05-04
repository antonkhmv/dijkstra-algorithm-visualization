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

        public IEnumerable<TableElement> Adjacent
        {
            get {
                var ans = new List<TableElement>();
                for (int i = 0; i < edges.adjacent.Count; ++i)
                {
                    ans.Add(new TableElement(
                        i,
                        string.Join(" ", edges.adjacent[i]
                            .Where(x => x.Direction != DirectionType.Backward)
                            .Select(x => x.Second))
                    ));
                }
                return ans;
            }
        }

        public class TableElement
        {
            public string AdjacentNodes { get; set; }
            public int Id { get; set; }
            public TableElement(int id, string adjacentNodes)
            {
                AdjacentNodes = adjacentNodes;
                Id = id;
            }
        }
    }
}