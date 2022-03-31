using QueueNamespace;
using Xunit;

namespace QueueTest
{
    public class QueueTest
    {
        [Theory]
        [InlineData(10)]
        [InlineData(0)]
        [InlineData(-6)]
        public void ArrayQueueDequeue_Integers_EqualsIntegers(int value)
        {
            IQueue<int> q = new ArrayQueue<int>();

            q.Enqueue(value);
            var res = q.Dequeue();

            Assert.Equal(value, res);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(0)]
        [InlineData(-6)]
        public void LLQueueDequeue_Integers_EqualsIntegers(int value)
        {
            IQueue<int> q = new LinkedListQueue<int>();

            q.Enqueue(value);
            var res = q.Dequeue();

            Assert.Equal(value, res);
        }

        [Fact]
        public void ArrayQueuePeek_DoesntRemoveObject()
        {
            var q = new ArrayQueue<int>();

            q.Enqueue(24);
            q.Enqueue(25);
            q.Enqueue(40);
            var peek = q.Peek();
            var deq = q.Dequeue();

            Assert.Equal(deq, peek);
        }

        [Fact]
        public void LLQueuePeek_DoesntRemoveObject()
        {
            var q = new LinkedListQueue<int>();

            q.Enqueue(24);
            q.Enqueue(25);
            q.Enqueue(40);
            var peek = q.Peek();
            var deq = q.Dequeue();

            Assert.Equal(deq, peek);
        }

        [Fact]
        public void ArrayQueueDequeue_EmptyQueue_EqualDefault()
        {
            var q = new ArrayQueue<string>();

            var res = q.Dequeue();

            Assert.Equal(default, res);
        }

        [Fact]
        public void LLQueueDequeue_EmptyQueue_EqualDefault()
        {
            var q = new LinkedListQueue<string>();

            var res = q.Dequeue();

            Assert.Equal(default, res);
        }
    }
}