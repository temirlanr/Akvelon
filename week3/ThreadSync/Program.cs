using System.Threading;

namespace ThreadSync
{
    public class Program
    {
        private static Mutex mutex = null;

        public static void Main(string[] args)
        {
            const string appName = "ThreadSync";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                Console.WriteLine(appName + " is already running! Exiting the application.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Continuing with the application");

            Solution solution = new Solution();

            solution.Start();

            Console.ReadKey();
        }
    }
}