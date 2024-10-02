using Lab2.Source;
using Lab2.Source.Methods;

namespace Lab2.Tests
{
    public class EnergyCalculationTests
    {
        [Fact]
        public void TestGetValues_ValidPath_ReturnValuesFromTheFile()
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
            File.WriteAllText(inputPath, "4\n" +
                                         "2 7 3 6");

            (ushort count, ushort[] heights) = Program.GetValues(inputPath);

            Assert.Equal(4, count);
            Assert.Equal([2, 7, 3, 6], heights);
        }

        [Fact]
        public void TestGetValues_InvalidPath_ThrowsFileNotFoundException()
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\invalidTestInput.txt");

            Assert.Throws<FileNotFoundException>(() => Source.Program.GetValues(inputPath));
        }

        [Theory]
        [InlineData("a b c\n" +
            "3 2 5 7 2")]
        [InlineData("x\n" +
            "0 1 3 6 1")]
        public void TestGetValues_InvalidFormatOfNumberOfPlatforms_ThrowFormatException(string text)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
            File.WriteAllText(inputPath, text);

            Assert.Throws<FormatException>(() => Program.GetValues(inputPath));
        }

        [Theory]
        [InlineData("0 5 1 6 8\n" +
            "3 6 3 7")]
        [InlineData("1 2\n" +
            "6 1 5 2")]
        public void TestGetValues_InvalidFormatOfNumberOfPlatforms_ThrowsFormatException(string text)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
            File.WriteAllText(inputPath, text);

            Assert.Throws<FormatException>(() => Program.GetValues(inputPath));
        }

        [Theory]
        [InlineData("3\n" +
            "1 a 0")]
        [InlineData("4\n" +
            "0 O 0 O")]
        public void TestGetValues_InvalidFormatOfPlatformHeightValues_ThrowsFormatException(string text)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
            File.WriteAllText(inputPath, text);

            Assert.Throws<FormatException>(() => Program.GetValues(inputPath));
        }

        [Theory]
        [InlineData("3\n")]
        [InlineData("\n")]
        public void TestGetValues_InvalidNumberOfLines_ThrowsInvalidDataException(string text)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
            File.WriteAllText(inputPath, text);

            Assert.Throws<InvalidDataException>(() => Program.GetValues(inputPath));
        }

        [Theory]
        [InlineData("0\n" +
            "0")]
        [InlineData("30001\n" +
            "2 3 4 6")]
        public void TestGetValues_InvalidNumberOfPlatforms_ThrowsArgumentOutOfRangeException(string text)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
            File.WriteAllText(inputPath, text);

            Assert.Throws<ArgumentOutOfRangeException>(() => Program.GetValues(inputPath));
        }

        [Theory]
        [InlineData("3\n" +
            "3 6 3 7")]
        [InlineData("5\n" +
            "5 1 2")]
        public void TestGetValues_InvalidNumberOfPlatformHeightValues_ThrowsArgumentException(string text)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
            File.WriteAllText(inputPath, text);

            Assert.Throws<ArgumentException>(() => Program.GetValues(inputPath));
        }

        [Theory]
        [InlineData("3\n" +
            "4 0 6")]
        [InlineData("4\n" +
            "1 62342 6 3")]
        public void TestGetValues_InvalidValueOfPlatformHeight_ThrowsArgumentOutOfRangeException(string text)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
            File.WriteAllText(inputPath, text);

            Assert.Throws<ArgumentOutOfRangeException>(() => Program.GetValues(inputPath));
        }

        [Theory]
        [InlineData(3, new ushort[] { 1, 5, 2 }, 3)]
        [InlineData(3, new ushort[] { 1, 5, 10 }, 9)]
        public void TestCalculateMinEnergyValue_RightAnswer_GetEqualResults(ushort platformsNum, ushort[] heights, long expectedResult)
        {
            Assert.Equal(expectedResult, EnergyCalculation.CalculateMinEnergyValue(platformsNum, heights));
        }

    }
}