using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationDateSetter.Main
{
    public class DirectoryParser
    {
        /// <summary>
        /// Return all files in a given directory.
        /// </summary>
        /// <param name="path">Absoulute or relative path</param>
        /// <param name="withSubfolder">flag to parse subfoldes or not</param>
        /// <returns>List of tuples containing the filename and the absolute path to this file</returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static List<(string fileName, string absolutePath)> ParseDirectory(string path, bool withSubfolder)
        {

            if (Directory.Exists(path))
            {
                //always work with full path
                var fullPath = Path.GetFullPath(path);  

                var result = new List<(string fileName, string absolutePath)>();
                var files = Directory.EnumerateFiles(fullPath, "*", (withSubfolder ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));

                foreach (string currentFile in files)
                {
                    var fileName = currentFile.Substring(fullPath.Length + 1);

                    result.Add((fileName, currentFile));
                }

                return result;
            }
            else
            {
                throw new DirectoryNotFoundException($"Directory {path} does not exist.");
            }
        }
    }
}
