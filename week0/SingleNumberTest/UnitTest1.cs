using SingleNumber;
using System;
using Xunit;

namespace SingleNumberTest
{
    public class UnitTest1
    {
        [Fact]
        public void SingleNumber_ArrayOfLength1_EqualNumber()
        {
            Solution solution = new Solution();
            int[] arr = new int[1] { 1 };

            var res = solution.SingleNumber(arr);

            Assert.Equal(1, res);
        }

        [Fact]
        public void SingleNumber_ArrayOfLength11_EqualSingleNumber()
        {
            Solution solution = new Solution();
            int[] arr = new int[11] { 1, 2, 2, 1, 3, 3, 5, 5, 10, 10, 32 };

            var res = solution.SingleNumber(arr);

            Assert.Equal(32, res);
        }

        [Fact]
        public void SingleNumber_ArrayOfLength2_ThrowsArgumentException()
        {
            Solution solution = new Solution();
            int[] arr = new int[2] { 1, 2 };

            Action act = () => solution.SingleNumber(arr);

            Assert.Throws<ArgumentException>(act);
        }
    }
}