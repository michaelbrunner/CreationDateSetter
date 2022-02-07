using CreationDateSetter.Main;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace CreationDateSetter.Tests
{
    public class DirectoryParserTest
    {
        private readonly ITestOutputHelper output;

        public DirectoryParserTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ParseExistingDirectory()
        {
            //Arrange
            var path = "testFolder";

            //Act
            var result = DirectoryParser.ParseDirectory(path);

            //Assert
            Assert.True(result.Count == 6);
            
            foreach (var entry in result)
            {
                output.WriteLine($"Filename: {entry.fileName} | AbsolutePath: {entry.absolutePath}");
            }

        }
    }
}