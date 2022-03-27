using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
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

        public void Add(Fraction fraction)
        {
            if (denominator == fraction.denominator)
            {
                numerator += fraction.numerator;
            }

            numerator = numerator * fraction.denominator + fraction.numerator * denominator;
            denominator *= fraction.denominator;
        }

        public void Subtract(Fraction fraction)
        {
            if (denominator == fraction.denominator)
            {
                numerator -= fraction.numerator;
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
            numerator *= fraction.denominator;
            denominator *= fraction.numerator;
        }

        public double ToDouble()
        {
            return numerator / denominator;
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
