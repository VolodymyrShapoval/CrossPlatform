

using Lab3.Source;
using Lab3.Source.Methods;
using System.Reflection;

namespace Lab3.Tests
{
    public class MythicalChessTests
    {
        private string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\testInput.txt");
        [Fact]
        public void TestGetValues_ValidPath_ReturnValuesFromTheFile()
        {
            File.WriteAllText(inputPath, "A2 B7");

            (Tuple<byte, byte> startCell,
                Tuple<byte, byte> endCell) = Program.GetValues(inputPath);

            Assert.Equal((Tuple.Create((byte)0, (byte)1), Tuple.Create((byte)1, (byte)6)), (startCell, endCell));
        }

        [Fact]
        public void TestGetValues_InvalidPath_ThrowsFileNotFoundException()
        {
            string invalidInputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\invalidTestInput.txt");

            Assert.Throws<FileNotFoundException>(() => Program.GetValues(invalidInputPath));
        }

        [Theory]
        [InlineData("A2 B1 C4 D7")]
        [InlineData("D8 D1 C2")]
        [InlineData("F7")]
        [InlineData("fc ha")]
        public void TestGetValues_InvalidNumberOfCoordinates_ThrowsArgumentException(string text)
        {
            File.WriteAllText(inputPath, text);

            Assert.Throws<ArgumentException>(() => Program.GetValues(inputPath));
        }

        [Theory]
        [InlineData("A2A")]
        [InlineData("2B3")]
        [InlineData("41")]
        [InlineData("BA")]
        [InlineData("8f")]
        public void TestParseCoordinate_InvalidCoordinateFormat_ThrowsFormatException(string text)
        {
            File.WriteAllText(inputPath, text);

            Assert.Throws<FormatException>(() => Program.ParseCoordinate(text, "cell"));
        }

        [Theory]
        [InlineData("X2")]
        [InlineData("P3")]
        [InlineData("L2")]
        public void TestParseCoordinate_InvalidKey_ThrowsKeyNotFoundException(string text)
        {
            File.WriteAllText(inputPath, text);

            Assert.Throws<KeyNotFoundException>(() => Program.ParseCoordinate(text, "cell"));
        }

        public static TheoryData<Tuple<byte, byte>> InvalidCoordinates =>
            new TheoryData<Tuple<byte, byte>>
            {
                Tuple.Create((byte)1, (byte)9),
                Tuple.Create((byte)24, (byte)13),
                Tuple.Create((byte)61, (byte)0)
            };

        [Theory]
        [MemberData(nameof(InvalidCoordinates))]
        public void TestValidateCoordinate_InvalidCoordinate_ThrowsArgumentOutOfRangeException(Tuple<byte, byte> cell)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Program.ValidateCoordinate(cell, "cell"));
        }

        public static TheoryData<Tuple<byte, byte>, Tuple<byte, byte>, sbyte> ValidCoordinates =>
            new TheoryData<Tuple<byte, byte>, Tuple<byte, byte>, sbyte>
            {
                { Tuple.Create((byte)3, (byte)6), Tuple.Create((byte)3, (byte)6), 0 },
                { Tuple.Create((byte)5, (byte)1), Tuple.Create((byte)4, (byte)5), -1 },
                { Tuple.Create((byte)2, (byte)1), Tuple.Create((byte)7, (byte)0), -1 },
                { Tuple.Create((byte)4, (byte)1), Tuple.Create((byte)7, (byte)3), 2 },
                { Tuple.Create((byte)7, (byte)5), Tuple.Create((byte)4, (byte)4), 2 },
                { Tuple.Create((byte)0, (byte)5), Tuple.Create((byte)5, (byte)5), 3 }
            };

        [Theory]
        [MemberData(nameof(ValidCoordinates))]
        public void TestSearchMinSteps_DifferentSituationCoordinates_EqualResults(Tuple<byte, byte> startCell, Tuple<byte, byte> endCell, sbyte expectedResult)
        {
            Assert.Equal(expectedResult, MythicalChess.SearchMinSteps(startCell, endCell));
        }
    }
}