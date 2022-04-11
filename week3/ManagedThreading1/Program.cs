using System.Threading;

namespace ManagedThreading1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for(int i = 0; i < 30; i++)
            {
                var rand = new Random();
                var index = rand.Next(0, 3);
                ChangeMusic(index);
            }

            Thread[] dancers = new Thread[10];

            for (int i = 0; i < dancers.Length; i++)
            {
                Thread dancer = new Thread(Dance) { Name = (i + 1).ToString() };
                dancer.Start();
            }
        }

        delegate void Change();

        static void ChangeMusic(int index)
        {
            Dictionary<int, Change> changers = new Dictionary<int, Change>
            {
                [0] = () => Thread.CurrentThread.Name = "Hardbass",
                [1] = () => Thread.CurrentThread.Name = "Latino",
                [2] = () => Thread.CurrentThread.Name = "Rock"
            };
            
            changers[index]();
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
    }
}