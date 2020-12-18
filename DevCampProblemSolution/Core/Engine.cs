using System;
using System.Linq;

using DevCampProblemSolution.Messages;
using DevCampProblemSolution.Core.Contracts;

namespace DevCampProblemSolution
{
    /// <summary>
    /// This class receives the input and calls all the commands.
    /// </summary>
    public class Engine : Layer, IEngine
    {
        public void Run()
        {
            Console.WriteLine(OutputMessages.InsertDimensions);

            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int m = dimensions[0]; // m => rows
            int n = dimensions[1]; //n => columns
           
            try
            {
                if (n > 100 || m > 100)
                {
                   throw new ArgumentException(ExceptionMessages.InvalidArea);
                }
                if (m % 2 != 0 || n % 2 != 0)
                {
                    throw new ArgumentException(ExceptionMessages.NoSolutionExists);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(-1);
            }

            int[,] firstLayer = FillInTheFirstLayer(m,n);

            int[,] secondLayer = SecondLayerMaker(firstLayer);

            PrintLayer(secondLayer);
        }
    }
}
