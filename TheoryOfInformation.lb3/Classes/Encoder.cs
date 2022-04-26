using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheoryOfInformation.lb3.Interfaces;
using System.Numerics;
using System.Windows.Controls;
using System.Windows;

namespace TheoryOfInformation.lb3.Classes
{
    internal class Encoder : IEncoder
    {
        public void Encrypt(BigInteger p, BigInteger q, BigInteger Ko, string pathToSrcFile, string pathToResFile, TextBox srcFile, TextBox resFile)
        {
            try
            {
                srcFile.Text = string.Empty;
                resFile.Text = string.Empty;
                FileIO fileWork = new FileIO();
                List<byte> res = new List<byte>();
                byte[] sourceInfo = fileWork.ReadFromFile(pathToSrcFile);
                for (long i = 0; i < sourceInfo.Length; i++)
                    srcFile.AppendText(sourceInfo[i].ToString() + "\n");
                BigInteger r = BigInteger.Multiply(p, q);
                for (int i = 0; i < sourceInfo.Length; i++)
                {
                    BigInteger EncryptRes = MathAlgorithms.FastExprModulo(sourceInfo[i], Ko, r);
                    resFile.AppendText(EncryptRes.ToString() + "\n");
                    byte[] tmp = EncryptRes.ToByteArray();
                    for (long j = 0; j < tmp.Length; j++)
                        res.Add(tmp[j]);
                    if (tmp.Length == 1)
                        res.Add(0);
                }
                fileWork.WriteToFile(pathToResFile, res.ToArray());
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is ArgumentNullException || ex is System.IO.FileNotFoundException)
                {
                    MessageBox.Show("Файл не найден");
                }
            }
        }

        public void Decrypt(BigInteger r, BigInteger Kc, string pathToSrcFile, string pathToResFile, TextBox srcFile, TextBox resFile)
        {
            try
            {
                srcFile.Text = string.Empty;
                resFile.Text = string.Empty;
                List<byte> res = new List<byte>();
                FileIO fileWork = new FileIO();
                var src = fileWork.ReadFromFile(pathToSrcFile);
                for (int i = 0; i < src.Length; i += 2)
                {
                    string binary = Convert.ToString(src[i + 1], 2).PadLeft(8, '0') + Convert.ToString(src[i], 2).PadLeft(8, '0');
                    int srcData = Convert.ToInt32(binary, 2);
                    srcFile.AppendText(srcData.ToString() + "\n");
                    BigInteger DecryptRes = MathAlgorithms.FastExprModulo(srcData, Kc, r);
                    resFile.AppendText(DecryptRes.ToString() + "\n");
                    res.Add((byte)DecryptRes);
                }
                fileWork.WriteToFile(pathToResFile, res.ToArray());
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is ArgumentNullException || ex is System.IO.FileNotFoundException)
                {
                    MessageBox.Show("Файл не найден");
                }
            }
        }
    }
}
