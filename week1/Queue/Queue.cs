using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public interface IQueue<T>
    {
        void Enqueue(T value);
        T? Dequeue();
        T? Peek();
        void Print();
    }

    public class Queue<T> : IQueue<T>
    {
        private int size = 0;
        private T[] ts = new T[0];

        public T? Dequeue()
        {
            if(size == 0)
            {
                return default;
            }

            size = size - 1;
            var lastItem = ts[size];
            ts = ts.Where((e, i) => i != size).ToArray();

            return lastItem;
        }

        public void Enqueue(T value)
        {
            T[] temp = new T[size];

            if(size > 0)
            {
                temp = (T[])ts.Clone();
            }

            size = size + 1;
            ts = new T[size];

            for(int i = 0; i < size - 1; i++) { ts[i] = temp[i]; }

            ts[size - 1] = value;
        }

        public T? Peek()
        {
            if(size == 0)
            {
                return default;
            }

            return ts[0];
        }

        public void Print()
        {
            foreach(var item in ts)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
