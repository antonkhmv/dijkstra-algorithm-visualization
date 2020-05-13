using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace Dijkstra_Algorithm_Visualization
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Changes the description for the code.
        /// </summary>
        /// <param name="descriptionParams">Params to change the description.</param>
        public void ChangeDescription(CodeBlock where, params double[] descriptionParams)
        {
            switch (where)
            {
                case CodeBlock.Start:

                    // Params are expected to have nothing.
                    Description = "{Начало алгоритма}";
                    break;
                case CodeBlock.FindMin:

                    // Params are expected to have the checked node and the min node's weight.
                    double checkedWeight = descriptionParams[0];
                    double minWeight = descriptionParams[1];

                    Description = $"Расстояние до вершины = {checkedWeight}; {{мин. расстояние = {minWeight}}}";
                    break;
                case CodeBlock.RelaxedEdges:

                    // Params are expected to have the distance to the previous min node and the weight of the edge, 
                    // and the distance to the node the edge is pointing to.
                    double dist = descriptionParams[0];
                    double edgeWeight = descriptionParams[1];
                    double nodeDist = descriptionParams[2];

                    // if the node is relaxed.
                    if (dist + edgeWeight < nodeDist)
                    {
                        Description = $"Ребро релаксировано: {dist} + {edgeWeight} < {nodeDist}. {{Новое расстояние: {dist + edgeWeight}}})";
                    }
                    else
                    {
                        Description = $"Ребро не реласировано: {dist} + {edgeWeight} >= {nodeDist}. {{Новое расстояние: {nodeDist}}}";
                    }
                    break;
                case CodeBlock.None:

                    // Params are expected to have the time complexity of the algorithm.
                    int complexity = (int)descriptionParams[0];
                    Description = $"Алгоритм окончен. Посещено вершин и ребер: O(|V|^2+|E|) = {complexity}";
                    break;
            }
        }
    }
}
