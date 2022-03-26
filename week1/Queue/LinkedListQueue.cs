using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private LinkedList<T> ts = new LinkedList<T>();

        public T? Dequeue()
        {
            if (ts.Count == 0)
            {
                return default;
            }

            var firstItem = ts.FirstOrDefault();
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
