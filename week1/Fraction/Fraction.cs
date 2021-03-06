using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionNamespace
{
    public class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction(int numerator, int denominator)
        {
            if(denominator == 0)
            {
                throw new ArgumentException("Denominator can't be 0");
            }

            int gcd = GCD(numerator, denominator);

            this.numerator = numerator / gcd;
            this.denominator = denominator / gcd;
        }

        public static implicit operator double(Fraction f) => (double)f.numerator / f.denominator;

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public void Add(Fraction fraction)
        {
            if (denominator == fraction.denominator)
            {
                numerator += fraction.numerator;
                return;
            }

            numerator = numerator * fraction.denominator + fraction.numerator * denominator;
            denominator *= fraction.denominator;
        }

        public void Subtract(Fraction fraction)
        {
            if (denominator == fraction.denominator)
            {
                numerator -= fraction.numerator;
                return;
            }

            numerator = numerator * fraction.denominator - fraction.numerator * denominator;
            denominator *= fraction.denominator;
        }

        public void Multiply(Fraction fraction)
        {
            numerator *= fraction.numerator;
            denominator *= fraction.denominator;
        }

        public void Divide(Fraction fraction)
        {
            if(fraction.numerator == 0)
            {
                throw new DivideByZeroException("Cannot divide by 0");
            }

            numerator *= fraction.denominator;
            denominator *= fraction.numerator;
        }

        public double ToDouble()
        {
            return (double)numerator / denominator;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        private static int LCM(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }

        public override bool Equals(object? obj)
        {
            return obj is Fraction fraction &&
                   numerator == fraction.numerator &&
                   denominator == fraction.denominator;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }

        public void Print()
        {
            Console.WriteLine($"{numerator}/{denominator}");
        }
    }
}
