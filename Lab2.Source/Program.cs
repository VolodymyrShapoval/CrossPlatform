using Lab2.Source.Methods;

namespace Lab2.Source
{
    public class Program
    {
        public static (ushort, ushort[]) GetValues(string path)
        {
            string[] lines;

            if (File.Exists(path))
                lines = File.ReadAllLines(path).Where(x => x != string.Empty).Take(2).ToArray();
            else throw new FileNotFoundException();

            ushort count = 0;
            ushort[] heights = Array.Empty<ushort>();

            if (lines.Length == 2)
            {
                count = ushort.TryParse(lines[0], out ushort result) 
                    ? result 
                    : throw new FormatException("The first line has to contain only 1 value of integer type - number of platforms!");
                heights = lines[1].Split(new[] { ' ', ',', }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => ushort.TryParse(x, out ushort result) ? result : throw new FormatException("Each value must be an integer and non-negative!"))
                    .ToArray();
            }
            else
            {
                throw new InvalidDataException("input.txt has to contain only 2 lines:\n" +
                    "1. Number of platforms\n" +
                    "2. High values for each platform");
            }

            if(count < 1 || count > 30000)
                throw new ArgumentOutOfRangeException("Number of platforms must be in range 1 <= numberOfPlatforms <= 30000");
            if(heights.Length < count || heights.Length > count)
                throw new ArgumentException($"Number of height values must to equal to the number of platforms({count})");
            if(heights.Any(x => x > 30000 || x < 1))
                throw new ArgumentOutOfRangeException($"Height values must be in range 0 <= height <= 30000");
            
            return (count, heights);
        }
        public static void Main(string[] args)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\input.txt");
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\output.txt");

            try
            {
                (ushort count, ushort[] heights) = GetValues(inputPath);
                long result = EnergyCalculation.CalculateMinEnergyValue(count, heights);

                Console.WriteLine(result);
                File.WriteAllText(outputPath, result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}