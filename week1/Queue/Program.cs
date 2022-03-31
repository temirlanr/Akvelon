using System;

namespace QueueNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IQueue<string> aq = new ArrayQueue<string>();

            Console.WriteLine(aq.Dequeue());
            aq.Enqueue("first");
            aq.Print();
            aq.Enqueue("second");
            aq.Print();
            aq.Enqueue("third");
            aq.Print();
            aq.Enqueue("forth");
            aq.Print();
            Console.WriteLine(aq.Dequeue());
            aq.Print();
            Console.WriteLine(aq.Dequeue());
            aq.Print();
            Console.WriteLine(aq.Peek());

            IQueue<string> llq = new LinkedListQueue<string>();

            Console.WriteLine(llq.Dequeue());
            llq.Enqueue("first");
            llq.Print();
            llq.Enqueue("second");
            llq.Print();
            llq.Enqueue("third");
            llq.Print();
            llq.Enqueue("forth");
            llq.Print();
            Console.WriteLine(llq.Dequeue());
            llq.Print();
            Console.WriteLine(llq.Dequeue());
            llq.Print();
            Console.WriteLine(llq.Peek());
        }
    }
}