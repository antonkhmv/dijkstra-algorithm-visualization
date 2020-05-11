using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class Graph
    {
        static readonly DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Graph));

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
                    var graph = (Graph) serializer.ReadObject(sw);
                    this.AdjacentEdges = graph.AdjacentEdges;
                    this.Nodes = graph.Nodes;
                    this.SelectedNode = graph.SelectedNode;
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
