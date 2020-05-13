using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        private void SaveAsNewFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (newFileName.Text.Length == 0)
            {
                return;
            }
            string name = newFileName.Text + ".json";

            if (File.Exists(name))
            {
                IOErrorMessage.Text = "Файл уже существует.";
                IOErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            RefreshOptions();

            try
            {
                File.Create('.' + loadPath + name).Close();
                Files.Add(name);
                RefreshOptions();
                IOErrorMessage.Text = string.Empty;
                IOErrorMessage.Visibility = Visibility.Collapsed;
                listBoxFiles.SelectedIndex = listBoxFiles.Items.IndexOf(name);
            }
            catch (Exception)
            {
                IOErrorMessage.Text = "Ошибка создания файла.";
                IOErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            newFileName.Text = string.Empty;
            SaveButton_Click(sender, e);
        }
    }
}