using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheoryOfInformation.lb3.Interfaces;

namespace TheoryOfInformation.lb3.Classes
{
    internal class FileIO: IReader, IWriter
    {
        public void WriteToFile(string fileName, byte[] information)
        {
            File.WriteAllBytes(fileName, information);
        }

        public byte[] ReadFromFile(string fileName)
        { 
            return File.ReadAllBytes(fileName);
        }
    }
}
