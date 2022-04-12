using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace ManagingThread2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread thread1 = new Thread(() => FindFileUrl(1, 1));
            thread1.Start();
            thread1.Join();
        }

        public static void FindFileUrl(int albumId, int id)
        {
            Thread.AllocateNamedDataSlot("ThumbnailUrl");
            Thread.AllocateNamedDataSlot("FileName");

            using (StreamReader r = new StreamReader(@"C:\Users\rsano\Akvelon\week3\ManagingThread2\photos.json"))
            {
                string json = r.ReadToEnd();
                List<Photo> photos = JsonConvert.DeserializeObject<List<Photo>>(json);
                foreach(var item in photos)
                {
                    if(item.albumId == albumId && item.id == id)
                    {
                        Thread.SetData(Thread.GetNamedDataSlot("ThumbnailUrl"), item.thumbnailUrl);
                        string fileName = item.albumId.ToString() + "_" + item.id.ToString() + ".jpeg";
                        Thread.SetData(Thread.GetNamedDataSlot("FileName"), fileName);
                        DownloadFile();
                    }
                }
            }
        }

        private static void DownloadFile()
        {
            string fileUrl = (string)Thread.GetData(Thread.GetNamedDataSlot("ThumbnailUrl"));
            string fileName = (string)Thread.GetData(Thread.GetNamedDataSlot("FileName"));

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(fileUrl, @"C:\Users\rsano\Akvelon\week3\ManagingThread2\" + fileName);
            }
        }
    }

    public class Photo
    {
        public int albumId;
        public int id;
        public string title;
        public string url;
        public string thumbnailUrl;
    }
}