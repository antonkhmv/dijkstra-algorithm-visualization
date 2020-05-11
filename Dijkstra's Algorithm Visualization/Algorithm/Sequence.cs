using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace Dijkstra_Algorithm_Visualization
{

    public partial class Sequence
    {
        private readonly EdgeCollection edges;
        private readonly MainWindow window;
        private readonly List<Node> nodes;

        private int iterator = 0;
        public int Iterator {
            get => iterator;
            private set {
                iterator = value;
                // Update all the ui if the algorithm is moved
                window.OnPropertyChanged("Iterator");
                window.OnPropertyChanged("FrameSlider");
                window.OnPropertyChanged("NodesDistanceTable");
            }
        }

        private int maxIndex = 0;

        public int MaxIndex { get => maxIndex; }
        
        public bool IsFirst { get => Iterator == 0; }
        public bool IsLast { get => CurrentStep == steps.Count; }

        public void SetFrame(int index)
        {
            int diff = index - Iterator;

            if (diff > 0)
            {
                for (int i = 0; i < diff; ++i)
                {
                    MoveNext();
                }
            }
            else
            {            
                // if diff == 0, then loop will not run.
                for (int i = 0; i < -diff; ++i)
                {
                    MoveBack();
                }
            }

            Iterator = index;
        }

        /// <summary>
        /// Generates the sequence of steps for the algorithm
        /// </summary>
        public Sequence(MainWindow window)
        {
            nodes = window.nodes;
            edges = window.edges;
            this.window = window;
            used = new bool[nodes.Count];
            dist = new double[nodes.Count];
            dist = new double[nodes.Count];

            for (int i = 0; i < nodes.Count; ++i)
            {                                     
                used[i] = false;
                dist[i] = double.PositiveInfinity;

                double value = i == window.selectedNode ? 0.0 : double.PositiveInfinity;

                nodes[i].DistanceText.Style = (Style)window.FindResource("DistanceText");
                window.graphCanvas.Children.Add(nodes[i].DistanceText);
                nodes[i].UpdateDistanceText(DoubleToString(value));
                nodes[i].Distance = value;
            }
        }

        /// <summary>
        /// Converts double to string and if the value is infinty, returns the symbol for inf.
        /// </summary>
        /// <returns></returns>
        public static string DoubleToString(double value)
        {
            if (double.IsPositiveInfinity(value))
                return "\u221E";
            return value.ToString();
        }
    }
}
         