using Drawing;
using System;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        public string Iterator { get => sequence == null ? "0 / 0" : $"{sequence.Iterator} / {sequence.MaxIndex}"; }

        public double FrameSlider
        {
            get => sequence != null && sequence.MaxIndex != 0 ? 10.0 * sequence.Iterator / sequence.MaxIndex : 0;
            set { if (sequence != null) sequence.SetFrame((int)Math.Round(value * sequence.MaxIndex / 10.0)); }
        }

        public string SelectedNode
        {
            get => selectedNode != -1 ? selectedNode.ToString() : string.Empty;
            set {
                if (string.IsNullOrEmpty(value))
                {
                    selectedNode = -1;
                }
                if (int.TryParse(value, out int index))
                {
                    if (0 <= index && index < nodes.Count)
                    {
                        selectedNode = index;
                        Shapes.SetCircleStyle(nodes[index], Shapes.CircleSelectedStyle);
                    }
                }
            }
        }

        private void Forward_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sequence != null && !sequence.IsLast)
                sequence.MoveNext();
            OnPropertyChanged("FrameSlider");
        }
    }
}