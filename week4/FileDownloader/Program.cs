using System;

namespace FileDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Downloader.Download("http://dejanstojanovic.net/media/215073/optimize-jpg.zip", @"c:\temp\", 2);

            Console.WriteLine($"Location: {result.FilePath}");
            Console.WriteLine($"Size: {result.Size}bytes");
            Console.WriteLine($"Time taken: {result.TimeTaken.Milliseconds}ms");
            Console.WriteLine($"Parallel: {result.ParallelDownloads}");

            Console.ReadKey();
        }
    }
}