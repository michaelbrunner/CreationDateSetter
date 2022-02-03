using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreationDateSetter.Main
{
    public class FileParser
    {
        public List<(string filename, DateTimeOffset creationDate)> parseDateInFilename(string[] filenames)
        {
            //Pattern for date in format "yyyy-mm-dd"
            string datePattern = "\\d{4}-\\d{2}-\\d{2}";

            var parsedFileNames = new List<(string Filename, DateTimeOffset CreationDate)>();  

            foreach (string file in filenames)
            {
                MatchCollection matches = Regex.Matches(file, datePattern);
                if (matches.Count == 1)
                {
                    //TODO handle different formats
                    var parsedDate = DateTimeOffset.Parse(matches.First().Value);
                    parsedFileNames.Add((file, parsedDate));
                } 
                else if (matches.Count > 1)
                {
                    Console.WriteLine($"{file} contains more than one date");
                    //parsedFileNames.Add(Tuple.Create<string, DateTimeOffset>(file, null));  
                }
                else
                {
                    Console.WriteLine($"Found no date in file {file}.");
                }
            }

            return parsedFileNames;
        }
    }
}
