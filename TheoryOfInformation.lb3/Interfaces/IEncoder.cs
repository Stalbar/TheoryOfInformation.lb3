using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Controls;

namespace TheoryOfInformation.lb3.Interfaces
{
    internal interface IEncoder
    {
        public void Encrypt(BigInteger p, BigInteger q, BigInteger Ko, string pathToSrcFile, string pathToResFile, TextBox srcFile, TextBox resFile);

        public void Decrypt(BigInteger r, BigInteger Kc, string pathToSrcFile, string PathToResFile, TextBox srcFile, TextBox resFile);
    }
}
