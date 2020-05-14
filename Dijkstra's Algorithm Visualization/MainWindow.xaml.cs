using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace Dijkstra_Algorithm_Visualization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            RefreshOptions();
            // CultureInfo.CurrentCulture = new CultureInfo("us-EN");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class BooleanToVisibilityConverter : IValueConverter
        {

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (targetType == typeof(Visibility))
                {
                    var visible = System.Convert.ToBoolean(value, culture);
                    if (InvertVisibility)
                        visible = !visible;
                    return visible ? Visibility.Visible : Visibility.Collapsed;
                }
                throw new InvalidOperationException("Converter can only convert to value of type Visibility.");
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new InvalidOperationException("Converter cannot convert back.");
            }

            public bool InvertVisibility { get; set; }

        }

    }
}