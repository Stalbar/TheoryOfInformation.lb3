using System;
using System.Numerics;
using System.Windows;
using TheoryOfInformation.lb3.Classes;

namespace TheoryOfInformation.lb3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetOpenKey_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BigInteger p = BigInteger.Parse(EncPInput.Text), q = BigInteger.Parse(EncQInput.Text), Kc = BigInteger.Parse(EncKcInput.Text);
                BigInteger eulerFunc = BigInteger.Multiply(BigInteger.Subtract(p, 1), BigInteger.Subtract(q, 1));
                if (!MathAlgorithms.IsPrime(p) || !MathAlgorithms.IsPrime(q))
                {
                    MessageBox.Show("p или q не являются простыми числами");
                    EncKoInput.Text = "";
                    return;
                }
                if (BigInteger.Multiply(p, q) < 255)
                {
                    MessageBox.Show("r < 255");
                    return;
                }
                if (MathAlgorithms.GCD(eulerFunc, Kc) != 1)
                {
                    MessageBox.Show("Функция Эйлера и закртый ключ не взаимно простые");
                    EncKoInput.Text = "";
                    return;
                }
                if (Kc <= 1 || Kc >= eulerFunc)
                {
                    MessageBox.Show("Некорректное значение Kc");
                    EncKoInput.Text = "";
                    return;
                }
                RValue.Text = BigInteger.Multiply(p, q).ToString();
                EulerFunc.Text = eulerFunc.ToString();
                BigInteger Ko;
                MathAlgorithms.EuclidEx(eulerFunc, Kc, out Ko);
                EncKoInput.Text = Ko.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect format");
            }
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Classes.Encoder RSA = new Classes.Encoder();
                RSA.Encrypt(BigInteger.Parse(EncPInput.Text), BigInteger.Parse(EncQInput.Text), BigInteger.Parse(EncKoInput.Text),
                    EncFileNameInput.Text, EncResFileNameInput.Text, EncSrcFile, EncResFile);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильный ввод");
            }
        }

        private void DecryptFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Classes.Encoder RSA = new Classes.Encoder();
                RSA.Decrypt(BigInteger.Parse(DecRInput.Text), BigInteger.Parse(DecKcInput.Text), DecFileName.Text, DecResFileName.Text, DecSrcFile, DecResFile);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильный ввод");
            }
        }
    }
}
