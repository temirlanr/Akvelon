using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueNamespace
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private readonly LinkedList<T> ts = new();

        public T? Dequeue()
        {
            if (!ts.Any())
            {
                return default;
            }

            var firstItem = ts.First();
            ts.RemoveFirst();

            return firstItem;
        }

        public void Enqueue(T value)
        {
            ts.AddLast(value);
        }

        public T? Peek()
        {
            return ts.FirstOrDefault();
        }

        public void Print()
        {
            foreach (var item in ts)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
