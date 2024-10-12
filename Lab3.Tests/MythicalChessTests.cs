

using Lab3.Source;

namespace Lab3.Tests
{
    public class MythicalChessTests
    {
        [Fact]
        public void TestGetValues_ValidPath_ReturnValuesFromTheFile()
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
            File.WriteAllText(inputPath, "A2 B7");

            (Tuple<byte, byte> startCell,
                Tuple<byte, byte> endCell) = Program.GetValues(inputPath);

            Assert.Equal((Tuple.Create((byte)0, (byte)1), Tuple.Create((byte)1, (byte)6)), (startCell, endCell));
        }

        [Fact]
        public void TestGetValues_InvalidPath_ThrowsFileNotFoundException()
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\invalidTestInput.txt");

            Assert.Throws<FileNotFoundException>(() => Program.GetValues(inputPath));
        }

        //[Theory]
        //[InlineData("6B C5")]
        //[InlineData("C1 80")]
        //[InlineData("A5 0A")]
        //[InlineData("A22 B1")]
        //public void TestGetValues_InvalidFormatOfNumberOfPlatforms_ThrowFormatException(string text)
        //{
        //    string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
        //    File.WriteAllText(inputPath, text);

        //    Assert.Throws<FormatException>(() => Program.GetValues(inputPath));
        //}
    }
}