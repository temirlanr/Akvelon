using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTask
{
    public class ImageDownloader
    {
        public static async Task Download(string url)
        {
            using (WebClient wc = new WebClient())
            //using(var eventHandler = new AutoResetEvent(false))
            {
                wc.DownloadFileCompleted += (s, e) =>
                {
                    Console.WriteLine("Download file completed.");
                    //eventhandler.set();
                };

                string fileName = RandomString(10) + ".jpeg";
                //wc.DownloadProgressChanged += (s, e) => Console.WriteLine($"Downloading {e.ProgressPercentage}%");
                await Task.Run(() => wc.DownloadFileAsync(new Uri(url), fileName));

                //eventHandler.WaitOne();
            }
        }

        private static Random random = new Random();

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
