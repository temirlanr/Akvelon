using System;
using ThreadSync;
using Xunit;

namespace ThreadSyncTest
{
    public class UnitTest1
    {
        [Fact]
        public void Start_CheckIfItWorks()
        {
            Solution solution = new Solution();

            var res = solution.Start();

            Assert.True(res);
        }
    }
}