using System;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace Dijkstra_Algorithm_Visualization
{

    public partial class Sequence
    {
        private EdgeCollection edges;
        private MainWindow window;
        private List<Node> nodes;

        public int Iterator { get; private set; } = 0;
        public int MaxIndex { get; private set; } = 1;

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

            // This is just faster than Enumerable.Repeat(nodes.Count, true).ToArray();
            for (int i = 0; i < nodes.Count; ++i)
            {
                used[i] = false;
                dist[i] = double.PositiveInfinity;
            }
        }
    }
}
