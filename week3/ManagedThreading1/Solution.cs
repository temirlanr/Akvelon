using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedThreading1
{
    public class Solution
    {
        private Dictionary<int, string> changers = new Dictionary<int, string>
        {
            [0] = "Hardbass",
            [1] = "Latino",
            [2] = "Rock"
        };

        private AutoResetEvent m_unlock = new AutoResetEvent(false);

        public bool Start()
        {
            Thread music = new Thread(() => ChangeMusic(changers));
            music.Start();
            Thread dancer = new Thread(() => Dance(music));
            dancer.Start();

            return true;
        }

        private void ChangeMusic(Dictionary<int, string> changers)
        {
            for (int i = 0; i < 30; i++)
            {
                var rand = new Random();
                var index = rand.Next(0, 3);

                Thread.CurrentThread.Name = changers[index];
                Console.WriteLine(Thread.CurrentThread.Name);
                m_unlock.Set();

                if (i == 30 - 1)
                {
                    Thread.EndThreadAffinity();
                }
                else
                {
                    Thread.Sleep(500);
                }
            }
        }

        private void Dance(Thread music)
        {
            while (music.IsAlive)
            {
                m_unlock.WaitOne();

                if (music.Name == "Hardbass")
                {
                    Console.WriteLine("Elbow dance");
                }

                if (music.Name == "Latino")
                {
                    Console.WriteLine("Hips dance");
                }

                if (music.Name == "Rock")
                {
                    Console.WriteLine("Head dance");
                }
            }
        }
    }
}
