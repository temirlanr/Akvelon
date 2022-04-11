using System.Threading;

namespace ManagedThreading1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread[] music = new Thread[3]
            {
                new Thread(Playlist) { Name = "Hardbass" },
                new Thread(Playlist) { Name = "Latino" },
                new Thread(Playlist) { Name = "Rock" }
            };

            for(int i = 0; i<30; i++)
            {
                var random = new Random();
                var item = random.Next();
            }

            Thread[] dancers = new Thread[10];

            for (int i = 0; i < dancers.Length; i++)
            {
                Thread dancer = new Thread(Dance) { Name = (i + 1).ToString() };
                dancer.Start();
            }
        }

        static void Dance()
        {
            if (Thread.CurrentThread.Name == "Hardbass")
            {
                Console.WriteLine("Elbow dance");
            }

            if(Thread.CurrentThread.Name == "Latino")
            {
                Console.WriteLine("Hips dance");
            }

            if(Thread.CurrentThread.Name == "Rock")
            {
                Console.WriteLine("Head dance");
            }
        }

        static void Playlist()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} song");
            Thread.Sleep(10000);
        }
    }
}