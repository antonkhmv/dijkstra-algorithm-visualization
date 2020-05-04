using System;
using System.IO;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void AddNewFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (newFileName.Text.Length == 0)
            {
                return;
            }
            string name = newFileName.Text + ".grp";

            if (File.Exists(name))
            {
                errorMessage.Text = "File already exists.";
                return;
            }

            RefreshOptions();
            try
            {
                File.Create(name);
                Files.Add(name);
                errorMessage.Text = string.Empty;
                fileName.SelectedIndex = Files.Count - 1;
            }
            catch (Exception)
            {
                errorMessage.Text = "Error creating new file.";
            }
        }
    }
}