using System.Collections;
using System.Collections.Generic;

namespace Dijkstra_Algorithm_Visualization
{
    public class EdgeEnumerator : IEnumerator<Edge>
    {
        private readonly List<Edge> edges;

        private int counter = 0;

        public Edge Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose() {}

        public bool MoveNext()
        {
            if (counter >= edges.Count)
            {
                return false;
            }
            Current = edges[counter];
            counter++;
            return true;
        }

        public EdgeEnumerator(List<Edge> edges)
        {
            this.edges = edges;
        }

        public void Reset()
        {
            counter = 0;
        }
    }
}
