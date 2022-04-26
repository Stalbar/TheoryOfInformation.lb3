using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TheoryOfInformation.lb3.Classes
{
    internal class MathAlgorithms
    {
        public static BigInteger FastExprModulo(BigInteger a, BigInteger b, BigInteger c)
        {
            BigInteger x = 1;
            while (b != 0)
            {
                while (b % 2 == 0)
                {
                    b = BigInteger.Divide(b, 2);
                    a = BigInteger.Multiply(a, a);
                    a = BigInteger.Remainder(a, c);
                }
                b = BigInteger.Subtract(b, 1);
                x = BigInteger.Multiply(x, a);
                x = BigInteger.Remainder(x, c);
            }
            return x;
        }

        public static bool IsPrime(BigInteger n)
        {
            int k = 100;
            if (n <= 100)
                k = (int)n - 1;
            for (int i = 2; i < k; i++)
            {
                BigInteger a = FastExprModulo(i, n - 1, n);
                if (a != 1)
                    return false;
            }
            return true;
        }

        public static void EuclidEx(BigInteger eulerFunc, BigInteger e, out BigInteger d1)
        {
            BigInteger d0 = eulerFunc, x0 = 1, y0 = 0;
            d1 = e;
            BigInteger x1 = 0;
            BigInteger y1 = 1;
            while (d1 > 1)
            {
                BigInteger q = d0 / d1;
                BigInteger d2 = d0 % d1;
                BigInteger x2 = x0 - q * x1;
                BigInteger y2 = y0 - q * y1;
                d0 = d1;
                d1 = d2;
                x0 = x1;
                x1 = x2;
                y0 = y1;
                y1 = y2;
            }
            d1 = (y1 < 0) ? BigInteger.Add(y1, eulerFunc) : y1;
        }

        public static BigInteger GCD(BigInteger val1, BigInteger val2)
        {
            while ((val1 != 0) && (val2 != 0))
            {
                if (val1 > val2)
                    val1 %= val2;
                else
                    val2 %= val1;
            }
            return BigInteger.Max(val1, val2);
        }
    }
}
