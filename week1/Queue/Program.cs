using System;

namespace Queue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IQueue<int> mq = new Queue<int>();

            Console.WriteLine(mq.Dequeue().ToString());
            mq.Enqueue(1);
            mq.Print();
            mq.Enqueue(2);
            mq.Print();
            mq.Enqueue(3);
            mq.Print();
            mq.Enqueue(4);
            mq.Print();
            Console.WriteLine(mq.Dequeue().ToString());
            mq.Print();
            Console.WriteLine(mq.Dequeue().ToString());
            mq.Print();
            Console.WriteLine(mq.Peek().ToString());
        }
    }
}