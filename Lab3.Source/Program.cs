using Lab3.Source.Methods;

namespace Lab3.Source
{
    public class Program
    {
        public static (Tuple<byte, byte>, Tuple<byte, byte>) GetValues(string path)
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
            string[] cells;
            Tuple<byte, byte> startCell, endCell;

            if (File.Exists(path))
                cells = File.ReadAllText(path)
                    .Replace(",", " ")
                    .Replace(";", " ")
                    .Replace("\n", " ")
                    .Replace("\r", " ")
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            else throw new FileNotFoundException();

            if (cells.Length == 2)
            {
                startCell = char.TryParse(cells[0][0].ToString(), out char keyStart) && byte.TryParse(cells[0][1].ToString(), out byte numberStart) 
                    ? Tuple.Create(chessTable[keyStart], --numberStart) 
                    : throw new FormatException("You should specify the coordinates in the format \"A5\"");
                endCell = char.TryParse(cells[1][0].ToString(), out char keyEnd) && byte.TryParse(cells[1][1].ToString(), out byte numberEnd) 
                    ? Tuple.Create(chessTable[keyEnd], --numberEnd)
                    : throw new FormatException("You should specify the coordinates in the format \"A5\"");
            }
            else
            {
                throw new InvalidDataException("input.txt must contain 2 coordinates");
            }

            if (startCell.Item1 < 0 || startCell.Item1 > 8 
                || endCell.Item1 < 0 || endCell.Item1 > 8 
                || startCell.Item2 < 0 || startCell.Item2 > 8 
                || endCell.Item2 < 0 || endCell.Item2 > 8)
                throw new ArgumentOutOfRangeException("Incorrect coordinates! The range of the chess grid is 9x9");

            return (startCell, endCell);
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