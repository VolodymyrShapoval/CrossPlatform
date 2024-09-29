using Lab1.Source.Methods;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Runtime.CompilerServices;

namespace Lab1.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        [InlineData(2, 7)]
        public void TestCalculateNumOfTailsCombinations_TailsMoreThanTosses_ReturnArgumentException(ushort tossesNum, ushort tailsNum)
        {
            Assert.Throws<ArgumentException>(() => HeadsAndTails.CalculateNumOfTailsCombinations(tossesNum, tailsNum));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 0, 4)]
        [InlineData(2, 1, 3)]
        [InlineData(2, 2, 1)]
        [InlineData(3, 0, 8)]
        [InlineData(3, 1, 7)]
        [InlineData(3, 2, 4)]
        public void TestCalculateNumOfTailsCombinations_ValidInput_ReturnResult(ushort tossesNum, ushort tailsNum, long expectedResult)
        {
            Assert.Equal(expectedResult, HeadsAndTails.CalculateNumOfTailsCombinations(tossesNum, tailsNum));
        }

        [Fact]
        public void TestGetValues_ValidPath_ReturnValuesFromTheFile()
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
            File.WriteAllText(inputPath, "2 0");

            (ushort res1, ushort res2) = Source.Program.GetValues(inputPath);

            Assert.Equal(2, res1);
            Assert.Equal(0, res2);
        }

        [Fact]
        public void TestGetValues_InvalidPath_ReturnFileNotFoundException()
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\invalidTestInput.txt");
            
            Assert.Throws<FileNotFoundException>(() => Source.Program.GetValues(inputPath));
        }

        [Theory]
        [InlineData("a b")]
        [InlineData("3, $")]
        [InlineData(". 2")]
        public void TestGetValues_InvalidTypeOfValue_ReturnFormatException(string testText)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
            File.WriteAllText(inputPath, testText);

            Assert.Throws<FormatException>(() => Source.Program.GetValues(inputPath));
        }

        [Theory]
        [InlineData("")]
        [InlineData("2 0 1")]
        [InlineData("1")]
        public void TestGetValues_InvalidNumberOfValues_ReturnInvalidDataException(string testText)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
            File.WriteAllText(inputPath, testText);

            Assert.Throws<InvalidDataException>(() => Source.Program.GetValues(inputPath));
        }
    }
}