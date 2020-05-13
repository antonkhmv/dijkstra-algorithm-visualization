using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        public enum CodeBlock
        {
            // For the last step of the algorithm.
            None,
            Start,
            FindMin,
            RelaxedEdges
        }

        // Set to CodeStart when pressed start
        static TextBlock currentCodeBlock;

        /// <summary>
        /// Changes the selected code block to the given block.
        /// </summary>
        /// <param name="where">The code block to be selected.</param>
       public void SelectCodeBlock(CodeBlock where)
        {
            var blocks = new Dictionary<CodeBlock, TextBlock>()
            {
                { CodeBlock.None, null },
                { CodeBlock.Start, codeStart },
                { CodeBlock.FindMin, codeFindMin },
                { CodeBlock.RelaxedEdges, codeRelaxEdges }
            };

            // Change the code blocks' style
            var selectedBlock = blocks[where];

            if (currentCodeBlock != null)
            {
                currentCodeBlock.Style = (Style)this.FindResource("CodeTextBlock");
            }

            if (selectedBlock != null)
            {
                selectedBlock.Style = (Style)this.FindResource("CodeTextBlockSelected");
            }

            currentCodeBlock = selectedBlock;
        }

    }
}
