using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class Graph
    {
        static BinaryFormatter binaryFormatter = new BinaryFormatter();
        /// <summary>
        /// Loads the graph from a file.
        /// </summary>
        /// <param name="path">The path to a file with the graph.</param>
        /// <returns>True if the loaded successfully and false otherwise.</returns>
        public bool LoadFromFile(string path)
        {
            try
            {
                using (var sw = new FileStream(path, FileMode.Open))
                {
                    var graph = (Graph) binaryFormatter.Deserialize(sw);
                    this.edges = graph.edges;
                    this.vertices = graph.vertices;
                    this.selectedNode = graph.selectedNode;
                    this.isDistanceEucledian = graph.isDistanceEucledian;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
