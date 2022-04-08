using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfInformation.lb3.Interfaces
{
    internal interface IWriter
    {
        void WriteToFile(string fileName, byte[] information);
    }
}
