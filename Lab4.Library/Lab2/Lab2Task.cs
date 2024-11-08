using Lab2.Source;
using Lab2.Source.Methods;
using Lab4.Library.Interfaces;

namespace Lab4.Library.Lab2
{
    internal class Lab2Task : ILabTask
    {
        public void ExecuteTask(string inputPath, string outputPath)
        {
            (ushort count, ushort[] heights) = Program.GetValues(inputPath);
            long result = EnergyCalculation.CalculateMinEnergyValue(count, heights);
            File.WriteAllText(outputPath, result.ToString());
        }
    }
}
