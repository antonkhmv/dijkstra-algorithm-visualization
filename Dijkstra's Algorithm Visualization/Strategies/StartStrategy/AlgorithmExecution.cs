using Drawing;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        public Sequence sequence;

        /// <summary>
        /// Frame progression slider.
        /// </summary>
        public double FrameSlider
        {
            get => sequence != null && sequence.MaxIndex != 0 ? 10.0 * sequence.Iterator / sequence.MaxIndex : 0;
            set
            {
                if (sequence != null)
                    sequence.SetFrameRequest((int)Math.Round(value * sequence.MaxIndex / 10.0));
                OnPropertyChanged("FrameSlider");
            }
        }


        /// <summary>
        /// Constants for calculating the delay of the player (in ms)
        /// </summary>
        const double delayAtTen = 20;
        const double delayAtZero = 500;
        const double initialSpeed = 4.0;

        // How many seconds should the player wait for the execution.
        public double DelayTime
        {
            get
            {
                double value = (delayAtZero + (delayAtTen - delayAtZero) * speed / 10.0);
                double coeff = 1;
                if (sequence.CurrentStep >= 0 && sequence.CurrentStep < sequence.steps.Count)
                    coeff = (sequence.CurrentCheckedIndex
                        == sequence.steps[sequence.CurrentStep].checkedNodes.Count ? 1 : 0.7);
                return value * coeff;
            }
        }

        // Initial speed
        private double speed = initialSpeed;

        // Execution speed which is set by a slider
        public double Speed
        {
            get => speed;
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }

        private string description = "";

        /// <summary>
        /// Description for every step of the algorithm.
        /// </summary>
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
    }
}