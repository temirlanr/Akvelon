using System;

namespace AsyncTask
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await ImageDownloader.Download("https://file-examples.com/storage/fe2356939c62607a6a1903b/2017/10/file_example_JPG_500kB.jpg");
            await ImageDownloader.Download("https://file-examples.com/storage/fe2356939c62607a6a1903b/2017/10/file_example_JPG_500kB.jpg");

        }
    }
}