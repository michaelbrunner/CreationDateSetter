using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationDateSetter.Main
{
    public class DirectoryParser
    {
        public string[] ParseDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return Directory.GetFiles(path);
            }
            else
            {
                throw new DirectoryNotFoundException($"Directory {path} does not exist.");
            }
        }
    }
}
