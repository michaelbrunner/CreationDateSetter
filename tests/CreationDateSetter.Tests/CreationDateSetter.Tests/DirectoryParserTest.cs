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

        [Theory]
        [InlineData(false, 6)]
        [InlineData(true, 8)]
        public void DirectoryParser_ParseExistingDirectory_Success(bool withSubfolder, int expectedFiles)
        {
            //Arrange
            var path = "testFolder";

            //Act
            var result = DirectoryParser.ParseDirectory(path, withSubfolder);

            //Assert
            Assert.True(result.Count == expectedFiles);
            
            foreach (var entry in result)
            {
                output.WriteLine($"Filename: {entry.fileName} | AbsolutePath: {entry.absolutePath}");
            }

        }
    }
}