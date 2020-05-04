using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class Graph
    {
        /// <summary>
        /// Saves the graph to a file.
        /// </summary>
        /// <param name="path">The path to the save file.</param>
        /// <returns>True if the saved successfully and false otherwise.</returns>
        public bool SaveAsFile(string path)
        {
            try
            {
                using (var sw = new FileStream(path, FileMode.Open))
                {
                    binaryFormatter.Serialize(sw, this);
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
