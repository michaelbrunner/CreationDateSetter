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
                string[] fileEntries = Directory.GetFiles(path);
                foreach (string fileName in fileEntries)
                {
                    Console.WriteLine(fileName);
                }
            }
            else
            {
                //handle exception case
            }



        }

    }
}