using CreationDateSetter.Main;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CreationDateSetter.Tests
{
    public class FileModifierTest
    {
        private readonly ITestOutputHelper output;

        public FileModifierTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void FileModifier_ChangeCreationDate_Success()
        {
            //Arrange
            var filename = "testfolder/KeinDatum.txt";
            var expectedDate = new DateTime(2022, 2, 4);

            //Act
            FileModifier.ChangeCreationDate(filename, new DateTimeOffset(expectedDate));

            //Assert
            var creationDate = Directory.GetCreationTime(filename);
            Assert.Equal<DateTime>(expectedDate, creationDate);
        }
    }
}
