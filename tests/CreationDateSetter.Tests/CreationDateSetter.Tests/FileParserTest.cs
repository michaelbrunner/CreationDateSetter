using CreationDateSetter.Main;
using CreationDateSetter.Main.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CreationDateSetter.Tests
{
    public class FileParserTest
    {
        private readonly ITestOutputHelper output;

        public FileParserTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory, MemberData(nameof(FilenameDateCorrectData))]
        public void ParseDefaultDateFormat_Success(string filename, DateTimeOffset expectedDate)
        {
            var result = FileParser.ParseDateInFilename(filename);
            
            Assert.Equal(expectedDate, result);

            output.WriteLine($"Filename: {filename} - Parsed Date: {result}");
        }

        [Theory]
        [InlineData("test1_2022-02.txt")]
        [InlineData("2022-01-23test2_2022-02-20.txt")]
        [InlineData("test3.txt")]
        public void FileParser_ParseDateInFilenameWithInvalidFilenames_ThrowNoDateFoundException(string filename)
        {
            Assert.Throws<NoDateFoundException>(() => FileParser.ParseDateInFilename(filename));
        }

        [Theory]
        [InlineData("test1_2022-02-29.txt")]
        [InlineData("test2_2022-01-32.txt")]
        [InlineData("test3_2022-04-31.txt")]
        public void FileParser_ParseDateInFilenameWithInvalidDate_ThrowFormatException(string filename)
        {
            Assert.Throws<FormatException>(() => FileParser.ParseDateInFilename(filename));
        }


        public static IEnumerable<object[]> FilenameDateCorrectData =>
        new List<object[]>
        {
            new object[] { "testDatei_2022-01-25.pdf", new DateTimeOffset(new DateTime(2022, 1, 25))},
            new object[] { "test2_2020-09-10_postfix.jpeg", new DateTimeOffset(new DateTime(2020, 9, 10))},
            new object[] { "2022-02-09_hinten.pdf", new DateTimeOffset(new DateTime(2022, 02, 9))}
        };

    }
}
