using System;

namespace FileDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Downloader.Download("http://212.183.159.230/100MB.zip", "./", 16);

            Console.WriteLine($"Location: {result.FilePath}");
            Console.WriteLine($"Size: {result.Size}bytes");
            Console.WriteLine($"Time taken: {result.TimeTaken.Milliseconds}ms");
            Console.WriteLine($"Parallel: {result.ParallelDownloads}");

            Console.ReadKey();
        }
    }
}