using CreationDateSetter.Main.Exceptions;

namespace CreationDateSetter.Main
{
    public class CreationDateSetter
    {
        public static void Main(string[] args)
        {
            ProcessDirectory(args[0]);
        }

        private static void ProcessDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                var files = DirectoryParser.ParseDirectory(path);
                
                foreach (var (fileName, absolutePath) in files)
                {
                    try
                    {
                        var creationDate = FileParser.ParseDateInFilename(fileName);
                        FileModifier.ChangeCreationDate(absolutePath, creationDate);   
                    }
                    catch (NoDateFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Directory {path} does not exist!");
            }

        }
    }
}