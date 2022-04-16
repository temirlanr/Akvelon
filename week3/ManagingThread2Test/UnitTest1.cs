using ManagingThread2;
using System;
using Xunit;

namespace ManagingThread2Test
{
    public class UnitTest1
    {
        [Fact]
        public void Start_CheckIfItWorks()
        {
            Solution solution = new Solution();

            var res = solution.Start(32);

            Assert.True(res);
        }
    }
}