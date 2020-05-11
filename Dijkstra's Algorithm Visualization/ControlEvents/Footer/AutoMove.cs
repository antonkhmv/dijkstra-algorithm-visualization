using Drawing;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Move the sequence automatically (forward)
        /// </summary>
        /// <param name="cancellaionToken"></param>
        /// <returns></returns>
        async public Task AutoMoveForward(CancellationToken cancellaionToken)
        {
            while (sequence != null && !sequence.IsLast)
            {
                await Task.Delay((int)DelayTime);
                // If the task is cancelled.
                if (cancellaionToken.IsCancellationRequested)
                {
                    // Stop Executing the task.
                    break;
                }
                sequence.MoveNext();
                // If the task is cancelled.
                if (cancellaionToken.IsCancellationRequested || sequence.IsLast)
                {
                    // Stop Executing the task.
                    break;
                }
            }
            StopPlayer();
        }

        /// <summary>
        /// Move the sequence automatically (backward)
        /// </summary>
        /// <param name="cancellaionToken"></param>
        /// <returns></returns>
        async public Task AutoMoveBackward(CancellationToken cancellaionToken)
        {
            while (sequence != null && !sequence.IsFirst)
            {
                await Task.Delay((int)DelayTime);
                // If the task is cancelled.
                if (cancellaionToken.IsCancellationRequested)
                {
                    // Stop Executing the task.
                    break;
                }
                sequence.MoveBack();
                // If the task is cancelled.
                if (cancellaionToken.IsCancellationRequested || sequence.IsFirst)
                {
                    // Stop Executing the task.
                    break;
                }
            }
            StopPlayer();
        }

        /// <summary>
        /// Stop moving the sequence automatically.
        /// </summary>
        public void StopPlayer()
        {
            // Request task cancellation.
            try
            {
                playerCTS.Cancel();
                if (currentTask != null)
                {
                    currentTask.Wait(playerCTS.Token);
                }
            }
            catch (OperationCanceledException)
            {
                // If a button is selected, disable the selection.
                if (selectedPlayerButton != null)
                {
                    selectedPlayerButton.Style = this.FindResource("HoverButton") as Style;
                    selectedPlayerButton = null;
                }

                if (currentTask == null)
                    return;
                // Task cancelled.
                playerCTS = new CancellationTokenSource();
            }
        }
    }
}
