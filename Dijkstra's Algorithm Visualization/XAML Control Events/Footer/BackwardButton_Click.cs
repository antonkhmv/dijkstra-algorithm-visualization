using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void Backward_Click(object sender, RoutedEventArgs e)
        {
            if (sequence!=null && !sequence.IsFirst)
                sequence.MoveBackRequest();
        }
    }
}