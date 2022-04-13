using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedThreading1
{
    public class Solution
    {
        public bool Start()
        {
            Thread music = new Thread(() => ChangeMusic());
            Thread dancer = new Thread(() => Dance(music));
            music.Start();
            dancer.Start();

            return true;
        }

        private static void ChangeMusic()
        {
            for (int i = 0; i < 30; i++)
            {
                var rand = new Random();
                var index = rand.Next(0, 3);

                Dictionary<int, string> changers = new Dictionary<int, string>
                {
                    [0] = "Hardbass",
                    [1] = "Latino",
                    [2] = "Rock"
                };

                Thread.CurrentThread.Name = changers[index];
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(10000);
            }
        }

        private static void Dance(Thread music)
        {
            for (int i = 0; i < 30; i++)
            {
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

                Thread.Sleep(3000);
            }
        }
    }
}
