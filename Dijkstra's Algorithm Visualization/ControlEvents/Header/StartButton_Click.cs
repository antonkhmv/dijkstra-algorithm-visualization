﻿using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        public Sequence sequence;

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedNode != -1)
            {
                sequence = new Sequence(this);
                sequence.BuildN2();
                frameSlider.Value = 0;
                OnPropertyChanged("Iterator");
                OnPropertyChanged("MaxIndex");
            }
        }
    }
}