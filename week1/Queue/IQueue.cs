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
}
