using Drawing;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// What button (autoforwrd / autobackward) is selected.
        /// </summary>
        static Button selectedPlayerButton = null;

        /// <summary>
        /// Cancellation Token Source for stopping the task.
        /// </summary>
        static CancellationTokenSource playerCTS = new CancellationTokenSource();

        /// <summary>
        /// Task object for syncronical execution.
        /// </summary>
        static Task currentTask = null;

        private void Plyer_SwitchButton(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;

            // If the same button is pressed, don't do anything.
            if (button == selectedPlayerButton)
                return;

            if (currentTask != null && !(currentTask.IsCompleted || currentTask.IsCanceled))
                StopPlayer();

            if (button.Name == "Stop")
            {
                selectedPlayerButton = null;
                return;
            }

            selectedPlayerButton = button;
            selectedPlayerButton.Style = this.FindResource("HoverButtonToggled") as Style;

            var token = playerCTS.Token;
            switch (button.Name)
            {
                case "AutoForward":
                    currentTask = AutoMoveForward(token);
                    break;
                case "AutoBackward":
                    currentTask = AutoMoveBackward(token);
                    break;
            }
        }
    }
}