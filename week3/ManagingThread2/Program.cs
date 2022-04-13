using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace ManagingThread2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            solution.Start();
        }
    }
}