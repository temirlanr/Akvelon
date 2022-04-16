using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagingThread2
{
    public class Solution
    {
        public bool Start(int threadNumber)
        {
            Thread[] threads = new Thread[threadNumber];
            List<Photo> photos = GetAllPhotos("photos.json");

            for(int i = 0; i < threadNumber; i++)
            {
                threads[i] = new Thread(() => Download(i, threadNumber, photos));
                threads[i].Start();
            }

            return true;
        }

        public List<Photo> GetAllPhotos(string jsonFile)
        {
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Photo>>(json);
            }
        }

        public static void Download(int id, int diff, List<Photo> photos)
        {
            for (int i = id; i < photos.Count; i += diff)
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(photos[i].thumbnailUrl, "../../../photos/" + RandomString(10) + ".jpeg");
                }
            }
        }

        private static Random random = new Random();

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
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
