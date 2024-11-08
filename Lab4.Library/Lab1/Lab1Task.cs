using Lab1.Source;
using Lab1.Source.Methods;
using Lab4.Library.Interfaces;

namespace Lab4.Library.Lab1
{
    internal class Lab1Task : ILabTask
    {
        public void ExecuteTask(string inputPath, string outputPath)
        {
            (short n, short m) = Program.GetValues(inputPath);
            long result = HeadsAndTails.CalculateNumOfTailsCombinations(n, m);

            File.WriteAllText(outputPath, result.ToString());
        }
    }
}
