using System;
using System.Collections.Generic;
using System.Media;
using System.Threading.Tasks;
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
        public int Iterator
        {
            get => iterator;
            private set
            {
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

        /// <summary>
        /// Current task for setting the frame
        /// </summary>
        public Task setFrameTask;

        /// <summary>
        /// Requests to set the current frame of the algorithm to "index" 
        /// (Since the player is implemented asyncronosly, the MoveNext() methods should not be called in parallel).
        /// </summary>
        /// <param name="index"></param>
        public void SetFrameRequest(int index)
        {
            if (setFrameTask == null || setFrameTask.IsCompleted)
            {
                setFrameTask = SetFrame(index);
            }
        }

        /// <summary>
        /// Requests moving the algorithm forward
        /// </summary>
        public void MoveNextRequest()
        {
            if (!IsLast)
                SetFrameRequest(Iterator + 1);
        }

        /// <summary>
        /// Requests moving the algorithm back
        /// </summary>
        public void MoveBackRequest()
        {
            if (!IsFirst)
                SetFrameRequest(Iterator - 1);
        }

        /// <summary>
        /// This method should not be run directly as it will cause 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private async Task SetFrame(int index)
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

                window.graphCanvas.Children.Add(nodes[i].DistanceText);
                nodes[i].Distance = value;
                nodes[i].DistanceText.Background = Brushes.White;

                nodes[i].UpdateDistanceText();
                nodes[i].UpdateDistanceText();
            }
        }

    }
}
