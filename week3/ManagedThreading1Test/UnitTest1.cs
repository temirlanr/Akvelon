using ManagedThreading1;
using Xunit;

namespace ManagedThreading1Test
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