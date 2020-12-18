using System;
using System.Linq;

namespace DevCampProblemSolution
{
    /// <summary>
    /// This is the class holding the commands for the layers.
    /// </summary>
    public class Layer : ILayer
    {

        /// <summary>
        /// This method fills in the first layer (matrix) with bricks.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns>The first layer (matrix).</returns>
        public int[,] FillInTheFirstLayer(int m, int n)
        {
            int[,] matrix = new int[m, n];
            Console.WriteLine(OutputMessages.InsertFirstLayer);
            for (int row = 0; row < m; row++)
            {
                int[] rows = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rows[col];
                }
            }

            return matrix;
        }
        /// <summary>
        /// This method creates the second layer (matrix) by the first layer.
        /// </summary>
        /// <param name="firstLayer"></param>
        /// <returns>The second layer (matrix).</returns>
        public int[,] SecondLayerMaker(int[,] firstLayer)
        {
            for (int row = 0; row < firstLayer.GetLength(0); row++)
            {
                for (int col = 0; col < firstLayer.GetLength(1); col++)
                {
                    if (col % 2 == 0 && col > 0)
                    {
                        firstLayer[row, col] = firstLayer[row, col - 1];
                    }
                    if (row % 2 == 0)
                    {
                        if (col == 0)
                        {
                            firstLayer[row, col] = firstLayer[row, firstLayer.GetLength(1) - 1];
                            firstLayer[row + 1, col] = firstLayer[row, firstLayer.GetLength(1) - 1];
                            continue;
                        }
                        if (col == firstLayer.GetLength(1) - 1)
                        {
                            firstLayer[row, col] = firstLayer[row + 1, firstLayer.GetLength(1) - 1];
                           
                        }
                    }
                }
            }
            return firstLayer;
        }

        /// <summary>
        /// This method prints the second layer (matrix).
        /// </summary>
        /// <param name="secondLayer"></param>
        public void PrintLayer(int[,] secondLayer)
        {
            Console.WriteLine(OutputMessages.SecondLayerHasToBe);
            //for (int row = 0; row < secondLayer.GetLength(0); row++)
            //{
            //    for (int col = 0; col < secondLayer.GetLength(1); col++)
            //    {
            //        Console.Write($"{secondLayer[row, col]} ");
            //    }
            //    Console.WriteLine();
            //}
            for (int row = 0; row < secondLayer.GetLength(0); row++)
            {
                for (int col = 0; col < secondLayer.GetLength(1); col++)
                {
                    if (row % 2 == 0 && col == 0)
                    {
                        Console.Write($"|{secondLayer[row, col]}|");
                    }
                    else if (row % 2 != 0 && col == 0)
                    {
                        Console.Write($"|{secondLayer[row, col]}|");
                    }
                    else if (row % 2 == 0 && col == secondLayer.GetLength(1)-1)
                    {
                        Console.Write($" |{secondLayer[row, col]}|");
                    }
                    else if (row % 2 != 0 && col == secondLayer.GetLength(1)-1)
                    {
                        Console.Write($" |{secondLayer[row, col]}| ");
                    }
                    else if(col%2!=0)
                    {
                        Console.Write($" |{secondLayer[row, col]} ");
                    }
                    else if (col % 2 == 0 && col > 0)
                    {
                        Console.Write($"{secondLayer[row, col]}|");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
