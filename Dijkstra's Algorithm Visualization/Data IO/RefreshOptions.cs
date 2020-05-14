using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Path for the directory to load files from.
        /// </summary>
        string loadPath = @"\Examples\";

        /// <summary>
        /// Refreshes the file choice options.
        /// </summary>
        public void RefreshOptions()
        {
            if (listBoxFiles == null)
                return;

            int selectedFile = listBoxFiles.SelectedIndex;
            string selectedPath = listBoxFiles.SelectedItem as string;
            
            Files.Clear();
            string path = Directory.GetCurrentDirectory() + loadPath;

            if (listBoxFiles != null)
                listBoxFiles.SelectedIndex = selectedFile;

            string[] dir;

            try { 
                // look for files ending in .json
                dir = Directory.GetFiles(path, "*.json");
            }
            catch // files not found / directory missing.
            {
                dir = new string[0];
            }

            foreach (var file in dir)
            {
                Files.Add(GetFileNameFromPath(file));
            }

            // if no files found.
            if (Files.Count == 0)
            {
                // Show message "no files found"
                noFilesMessage.Visibility = Visibility.Visible;
            }
            else
            {
                noFilesMessage.Visibility = Visibility.Collapsed;
            }

            // If no files selectd, select the first one.
            if (selectedFile == -1) {  
                listBoxFiles.SelectedIndex = 0;
                return;
            }

            // File deleted or moved error.
            if (!(0 <= selectedFile && selectedFile < listBoxFiles.Items.Count) ||
                    listBoxFiles.Items[selectedFile] as string != selectedPath)
            {
                IOErrorMessage.Text = "Файл удален или перемешен.";
                IOErrorMessage.Visibility = Visibility.Visible;

                if (listBoxFiles.Items.Count > 0)
                    listBoxFiles.SelectedIndex = 0;
                return;
            }
            
            listBoxFiles.SelectedIndex = selectedFile;
            IOErrorMessage.Visibility = Visibility.Collapsed;
        }
    }
}