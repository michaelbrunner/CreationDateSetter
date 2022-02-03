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
        [InlineData("C:\\eplatform\\Repos\\learn\\CreationDateSetter\\tests\\CreationDateSetter.Tests\\CreationDateSetter.Tests\\testFolder")]
        [InlineData("testFolder")]
        public void ParseExistingDirectory(string path)
        {
            //Arrange
            Directory.SetCurrentDirectory(@"C:\eplatform\Repos\learn\CreationDateSetter\tests\CreationDateSetter.Tests\CreationDateSetter.Tests");
            output.WriteLine($"current directory: {Directory.GetCurrentDirectory()}");

            //Act
            DirectoryParser parser = new DirectoryParser();
            var result = parser.ParseDirectory(path);

            foreach (var entry in result)
            {
                output.WriteLine($"Filename: {entry}");
            }

        }
    }
}