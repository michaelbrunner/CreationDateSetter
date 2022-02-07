using CreationDateSetter.Main.Exceptions;
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
        public static DateTimeOffset ParseDateInFilename(string filename) 
        {
            //Pattern for date in format "yyyy-mm-dd"
            string datePattern = "\\d{4}-\\d{2}-\\d{2}";

            MatchCollection matches = Regex.Matches(filename, datePattern);
            if (matches.Count == 1)
            {
                //TODO handle different formats
                return DateTimeOffset.Parse(matches.First().Value);
            }
            else if (matches.Count > 1)
            {
                throw new NoDateFoundException($"{filename} contains more than one date");
            }
            else
            {
                throw new NoDateFoundException($"Found no date in file {filename}.");
            }
        }
    }
}
