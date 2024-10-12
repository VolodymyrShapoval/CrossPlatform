using Lab3.Source.Methods;
using System.Text.RegularExpressions;

namespace Lab3.Source
{
    public class Program
    {
        public static (Tuple<byte, byte>, Tuple<byte, byte>) GetValues(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File not found at path: {path}");

            string[] cells = Regex.Replace(File.ReadAllText(path), @"[^A-Z0-9]", " ")
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (cells.Length != 2)
                throw new ArgumentException("The input must contain exactly 2 coordinates.");

            Tuple<byte, byte> startCell = ParseCoordinate(cells[0], "start");
            Tuple<byte, byte> endCell = ParseCoordinate(cells[1], "end");

            ValidateCoordinate(startCell, "start");
            ValidateCoordinate(endCell, "end");

            return (startCell, endCell);
        }
        public static Tuple<byte, byte> ParseCoordinate(string cell, string position)
        {
            Dictionary<char, byte> chessTable = new Dictionary<char, byte>{
                { 'A', 0},
                { 'B', 1 },
                { 'C', 2 },
                { 'D', 3 },
                { 'E', 4 },
                { 'F', 5 },
                { 'G', 6 },
                { 'H', 7 },
                { 'I', 8 }
            };

            // Check the format of symbols of entered coordinate
            if (cell.Length != 2 || !char.IsLetter(cell[0]) || !char.IsDigit(cell[1]))
            {
                throw new FormatException($"Invalid format for {position} coordinate. Expected format is \"A5\".");
            }

            // Convert a letter into a symbol and a digit into a number
            if (!char.TryParse(cell[0].ToString(), out char key) || !byte.TryParse(cell[1].ToString(), out byte number))
            {
                throw new FormatException($"Failed to parse {position} coordinate. Ensure the format is correct.");
            }

            // Check whether the key exists in the table
            if (!chessTable.ContainsKey(key))
            {
                throw new KeyNotFoundException($"Invalid letter {key} in the {position} coordinate. Must be from the chessboard range.");
            }

            // Return the coordinates from the table, reduce the number for indexing
            return Tuple.Create(chessTable[key], --number);
        }

        public static void ValidateCoordinate(Tuple<byte, byte> cell, string position)
        {
            if (cell.Item1 < 0 || cell.Item1 > 8 || cell.Item2 < 0 || cell.Item2 > 8)
            {
                throw new ArgumentOutOfRangeException($"{position}Cell", $"The {position} coordinate is out of bounds. The valid range for the chess grid is 1-9.");
            }
        }

        public static void Main(string[] args)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\input.txt");
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\output.txt");

            try
            {
                (Tuple<byte, byte> startCell, 
                Tuple<byte, byte> endCell) = GetValues(inputPath);
                sbyte result = MythicalChess.SearchMinSteps(startCell, endCell);

                File.WriteAllText(outputPath, result.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}