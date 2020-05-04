using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace Dijkstra_Algorithm_Visualization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        enum WindowWidth
        {
            Laptop = 800,
            Desktop = 1000
        }

        public static int Debug_Width { get => (int)WindowWidth.Desktop; set { } }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            RefreshOptions();
           
        }
           
    }

    [ValueConversion(typeof(int), typeof(int))]
    public class SumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value + 566;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}