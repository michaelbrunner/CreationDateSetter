using CreationDateSetter.Main.Exceptions;

namespace CreationDateSetter.Main
{
    public class CreationDateSetter
    {
        public static void Main(string[] args)
        {
            var withSubfolder = false;

            if (args.Length == 0)
            {
                Console.WriteLine("Please add a path as argument.");
                Console.WriteLine("Usage: CreationDateSetter <path> [-s]");
                return;
            }
            
            if (args.Length == 2)
            {
                switch (args[1])
                {
                    case "-s":
                        withSubfolder = true;
                        break;
                    default:
                        Console.WriteLine($"{args[1]} is not valid.");
                        Console.WriteLine("Usage: CreationDateSetter <path> [-s]");
                        return;
                }
            }

            var path = args[0];
            
            ProcessDirectory(path, withSubfolder);
        }

        private static void ProcessDirectory(string path, bool withSubfolder)
        {
            if (Directory.Exists(path))
            {
                var files = DirectoryParser.ParseDirectory(path, withSubfolder);
                
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