using System.Windows;
using System.Windows.Input;

namespace Dijkstra_Algorithm_Visualization
{
    public abstract class Strategy
    {
        public virtual void Window_KeyDown(MainWindow window, object sender, KeyEventArgs e) { }
        public virtual void Border_MouseDown(MainWindow window, object sender, MouseButtonEventArgs e) { }
        public virtual void Border_MouseMove(MainWindow window, object sender, MouseEventArgs e) { }
        public virtual void Border_MouseUp(MainWindow window, object sender, MouseButtonEventArgs e) { }

        /// <summary> 
        /// Get the position of the mouse.
        /// </summary>
        protected Point GetMousePosition(MouseEventArgs e, object sender)
        {
            var p = e.GetPosition((UIElement) sender);
            return new Point(p.X, p.Y);
        }
    }
}