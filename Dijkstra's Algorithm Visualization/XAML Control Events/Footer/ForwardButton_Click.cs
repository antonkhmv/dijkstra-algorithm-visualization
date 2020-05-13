using Drawing;
using System;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void Forward_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sequence != null && !sequence.IsLast)
                sequence.MoveNextRequest();
        }
    }
}