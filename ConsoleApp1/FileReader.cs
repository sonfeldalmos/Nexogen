using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FileReader: IFileReader
    {
        public string[] ReadLines(string filePath)
        {
            return System.IO.File.ReadAllLines(filePath);
        }
    }
}
