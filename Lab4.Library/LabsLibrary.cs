using Lab4.Library.Interfaces;
using Lab4.Library.Lab1;
using Lab4.Library.Lab2;
using Lab4.Library.Lab3;

namespace Lab4.Library
{
    public static class LabsLibrary
    {
        public static void ExecuteLab(int labNumber, string inputPath, string outputPath)
        {
            ILabTask task = GetLab(labNumber);
            task.ExecuteTask(inputPath, outputPath);
        }
        private static ILabTask GetLab(int labNumber)
        {
            return labNumber switch
            {
                1 => new Lab1Task(),
                2 => new Lab2Task(),
                3 => new Lab3Task(),
                _ => throw new Exception("There is no such laboratry work!")
            };
        }
    }
}
