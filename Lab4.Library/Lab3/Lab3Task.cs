using Lab3.Source;
using Lab3.Source.Methods;
using Lab4.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Library.Lab3
{
    internal class Lab3Task : ILabTask
    {
        public void ExecuteTask(string inputPath, string outputPath)
        {
            (Tuple<byte, byte> startCell,
                Tuple<byte, byte> endCell) = Program.GetValues(inputPath);
            sbyte result = MythicalChess.SearchMinSteps(startCell, endCell);

            File.WriteAllText(outputPath, result.ToString());
        }
    }
}
