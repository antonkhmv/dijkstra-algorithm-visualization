using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Find the file  or directory name from a full path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetFileNameFromPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            // Normalize the path.
            path = path.Replace('/', '\\');

            // Get the last '\' in the path.
            var lastIndex = path.LastIndexOf('\\')+1;

            // if the path only contains the file name.
            if (lastIndex <= 0)
                return path;

            return path.Substring(lastIndex);
        }
    }
}
