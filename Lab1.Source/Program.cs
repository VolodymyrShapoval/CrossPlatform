using Lab1.Source.Methods;

namespace Lab1.Source
{
    public class Program
    {
        public static (ushort, ushort) GetValues(string path)
        {
            string text = File.ReadAllText(path);
            ushort[] vals = text.Split(new[] { ' ', ',', }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => ushort.TryParse(x, out ushort value) ? value : throw new FormatException("Each value must be an integer and non-negative!"))
                .ToArray();

            if(vals.Length == 2) 
                return (vals.First(), vals.Last());
            else throw new InvalidDataException("The input file must contain only 2 values of integer type!");
        }

        public static void Main(string[] args)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\input.txt");
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\output.txt");

            try
            {
                (ushort n, ushort m) = GetValues(inputPath);
                long result = HeadsAndTails.CalculateNumOfTailsCombinations(n, m);

                File.WriteAllText(outputPath, result.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}