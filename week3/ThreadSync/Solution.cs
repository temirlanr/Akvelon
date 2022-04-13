using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSync
{
    public class Solution
    {
        private ManualResetEvent m_lock = new ManualResetEvent(false);
        private AutoResetEvent m_unlock = new AutoResetEvent(false);

        public bool Start()
        {
            Thread thread1 = new Thread(() => Starter1()) { Name = "Thread 1" };
            Thread thread2 = new Thread(() => Starter2()) { Name = "Thread 2" };
            thread1.Start();
            thread2.Start();

            return true;
        }

        private void Starter1()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} started");

            Thread thread3 = new Thread(() => WaitForManualReset()) { Name = "Thread 3" };
            Thread thread4 = new Thread(() => WaitForManualReset()) { Name = "Thread 4" };
            thread3.Start();
            thread4.Start();

            Thread.Sleep(500);
            Console.WriteLine($"{Thread.CurrentThread.Name} set signal");
            m_lock.Set();
            Console.WriteLine($"{Thread.CurrentThread.Name} reset signal");
            m_lock.Reset();
        }

        private void Starter2()
        {
            Thread thread5 = new Thread(() => WaitForAutoReset()) { Name = "Thread 5" };
            Thread thread6 = new Thread(() => WaitForAutoReset()) { Name = "Thread 6" };
            thread5.Start();
            thread6.Start();

            Thread.Sleep(500);
            Console.WriteLine($"{Thread.CurrentThread.Name} set signal");
            m_unlock.Set();
            Console.WriteLine($"{Thread.CurrentThread.Name} set signal");
            m_unlock.Set();
        }

        private void WaitForManualReset()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is waiting for a manual signal from Thread 1");
            m_lock.WaitOne(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name} received a manual signal, continue working");
        }

        private void WaitForAutoReset()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is waiting for an auto signal from Thread 2");
            m_unlock.WaitOne(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name} received an auto signal, continue working");
        }
    }
}
