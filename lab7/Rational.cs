using System;
using System.Text;

namespace lab7
{
    public class Rational : IComparable<Rational>
    {
        public ulong Numerator { get; set; }

        public ulong Denominator { get; set; }

        public Rational(ulong numerator, ulong denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Rational(ulong numerator)
        {
            Numerator = numerator;
        }

        private static ulong GCD(ulong a, ulong b)
        {
            while (a != b)
                if (a > b) a -= b;
                else b -= a;
            return a;
        }

        private static ulong LCM(ulong a, ulong b)
        {
            return a * b / GCD(a, b);
        }

        public int CompareTo(Rational other)
        {
            if (this > other) return 1;
            else if (this == other) return 0;
            else return -1;
        }

        public static explicit operator double(Rational r)
        {
            return (double)r.Numerator / r.Denominator;
        }

        public static implicit operator ulong(Rational r) => r.Numerator;

        public static explicit operator float(Rational r)
        {
            return (float)r.Numerator / r.Denominator;
        }

        public static explicit operator short(Rational r)
        {
            return (short)(r.Numerator / r.Denominator);
        }

        public static explicit operator int(Rational r)
        {
            return (int)(r.Numerator / r.Denominator);
        }

        public static explicit operator long(Rational r)
        {
            return (long)(r.Numerator / r.Denominator);
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            ulong lcm = LCM(r1.Denominator, r2.Denominator);
            long r1Num = (long)(lcm / r1.Denominator * r1.Numerator);
            long r2Num = (long)(lcm / r2.Denominator * r2.Numerator);

            return new Rational((ulong)(r1Num + r2Num), lcm);
        }
        public static Rational operator -(Rational r1, Rational r2)
        {
            ulong lcm = LCM(r1.Denominator, r2.Denominator);
            long r1Num = (long)(lcm / r1.Denominator * r1.Numerator);
            long r2Num = (long)(lcm / r2.Denominator * r2.Numerator);

            return new Rational((ulong)(r1Num - r2Num), lcm);
        }

        public static Rational operator *(Rational r1, Rational r2)
        {
            return new Rational(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
        }

        public static Rational operator /(Rational r1, Rational r2)
        {
            return new Rational(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);
        }

        public static bool operator >(Rational r1, Rational r2)
        {
            ulong lcm = LCM(r1.Denominator, r2.Denominator);
            long r1Num = (long)(lcm / r1.Denominator * r1.Numerator);
            long r2Num = (long)(lcm / r2.Denominator * r2.Numerator);

            return r1Num > r2Num;
        }

        public static bool operator <(Rational r1, Rational r2)
        {
            ulong lcm = LCM(r1.Denominator, r2.Denominator);
            long r1Num = (long)(lcm / r1.Denominator * r1.Numerator);
            long r2Num = (long)(lcm / r2.Denominator * r2.Numerator);

            return r1Num < r2Num;
        }

        public static bool operator ==(Rational r1, Rational r2)
        {
            ulong lcm = LCM(r1.Denominator, r2.Denominator);
            long r1Num = (long)(lcm / r1.Denominator * r1.Numerator);
            long r2Num = (long)(lcm / r2.Denominator * r2.Numerator);

            return r1Num == r2Num;
        }

        public static bool operator !=(Rational r1, Rational r2)
        {
            ulong lcm = LCM(r1.Denominator, r2.Denominator);
            long r1Num = (long)(lcm / r1.Denominator * r1.Numerator);
            long r2Num = (long)(lcm / r2.Denominator * r2.Numerator);

            return r1Num != r2Num;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static Rational ToRationalConverter(string str)
        {
            int i, j;
            ulong rNum, rDen;

            StringBuilder strNum = new StringBuilder();
            StringBuilder strDen = new StringBuilder();

            for (i = 0; i < str.Length; i++)
            {
                if (str[i] > '0' && str[i] < '9') strNum.Append(str[i]);
                else if (str[i] == '/') break;
            }

            for (j = i + 1; j < str.Length; j++)
            {
                if (str[j] > '0' && str[j] < '9') strDen.Append(str[j]);
            }

            rNum = Convert.ToUInt64(Convert.ToString(strNum));
            rDen = Convert.ToUInt64(Convert.ToString(strDen));
            return new Rational(rNum, rDen);
        }
    }
}
