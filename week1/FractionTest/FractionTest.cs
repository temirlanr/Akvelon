using Xunit;
using FractionNamespace;
using System;

namespace FractionTest
{
    public class FractionTest
    {
        [Fact]
        public void Add_SameDenominators_EqualSameDenominator()
        {
            var fraction1 = new Fraction(1, 5);
            var fraction2 = new Fraction(2, 5);

            fraction1.Add(fraction2);

            Assert.Equal("3/5", fraction1.ToString());
        }

        [Fact]
        public void Divide_NominatorZero_ThrowsDivideByZeroException()
        {
            var fraction1 = new Fraction(1, 5);
            var fraction2 = new Fraction(0, 8);

            Action act = () => fraction1.Divide(fraction2);

            Assert.Throws<DivideByZeroException>(act);
        }
    }
}