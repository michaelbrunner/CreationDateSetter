using CreationDateSetter.Main;
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

        [Fact]
        public void ParseDefaultDateFormat()
        {
            var filenames = new string[]
            {
                "testDatei_2022-01-25.pdf",
                "test2_2020-09-10_postfix.jpeg",
                "2022-02-09_hinten.pdf"
            };

            var parser = new FileParser();
            var result = parser.parseDateInFilename(filenames);

            foreach (var parsedFiled in result)
            {
                output.WriteLine($"Filename: {parsedFiled.filename} - Parsed Date: {parsedFiled.creationDate}");
            }
        }
    }
}
