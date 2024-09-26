using Lab1.Source.Methods;

namespace Lab1.Source
{
    class Program
    {
        public static List<int> GetValues(string path)
        {
            string text = File.ReadAllText(path);
            return text.Split(new[] { ' ', ',', }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }

        public static void Main(string[] args)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\input.txt");
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\output.txt");

            List<int> values = GetValues(inputPath);
            int result = 0;


            File.WriteAllText(outputPath, result.ToString());

            Console.ReadKey();
        }
    }
}