using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class DrawingStrategy : Strategy
    {
        public override void Window_KeyDown(MainWindow window, object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                if (window.selectedNode != -1)
                {
                    window.RemoveNode(window.selectedNode);
                }
            }
        }
    }
}
