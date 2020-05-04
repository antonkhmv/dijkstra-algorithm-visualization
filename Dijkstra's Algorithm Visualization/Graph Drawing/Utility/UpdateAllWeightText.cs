using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        public void UpdateAllWeightText()
        {
            foreach (var edge in edges)
            {
                edge.UpdateText();
            }
        }
    }
}