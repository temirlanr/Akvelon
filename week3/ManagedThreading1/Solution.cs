using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedThreading1
{
    public class Solution
    {
        private Dictionary<string, string> changers = new Dictionary<string, string>
        {
            ["Hardbass"] = "Elbow dance",
            ["Latino"] = "Hips dance",
            ["Rock"] = "Head dance"
        };

        readonly ManualResetEvent waitHandle = new ManualResetEvent(false);
        string dance;
        string state;

        public bool Start()
        {
            Thread music = new Thread(() => ChangeMusic(changers));
            music.Start();
            Thread[] dancers = new Thread[10]
            {
                new Thread(() => Dance()),
                new Thread(() => Dance()),
                new Thread(() => Dance()),
                new Thread(() => Dance()),
                new Thread(() => Dance()),
                new Thread(() => Dance()),
                new Thread(() => Dance()),
                new Thread(() => Dance()),
                new Thread(() => Dance()),
                new Thread(() => Dance()),
            };
            dancers[0].Start();
            dancers[1].Start();
            dancers[2].Start();
            dancers[3].Start();
            dancers[4].Start();
            dancers[5].Start();
            dancers[6].Start();
            dancers[7].Start();
            dancers[8].Start();
            dancers[9].Start();

            return true;
        }

        private void ChangeMusic(Dictionary<string, string> changers)
        {
            for (int i = 0; i < 30; i++)
            {
                var rand = new Random();
                var randChanger = changers.ElementAt(rand.Next(0, changers.Count));

                dance = randChanger.Value;
                Console.WriteLine(randChanger.Key);
                waitHandle.Set();
                waitHandle.Reset();

                if (i == 30 - 1)
                {
                    state = "Ended";
                    Thread.EndThreadAffinity();
                }
                else
                {
                    state = "Processing";
                    Thread.Sleep(500);
                }
            }
        }

        private void Dance()
        {
            while (true)
            {
                if(state == "Ended")
                {
                    break;
                }

                waitHandle.WaitOne();
                Console.WriteLine(dance);
            }
        }
    }
}
