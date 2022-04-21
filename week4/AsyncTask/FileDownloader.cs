using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTask
{
    public class FileDownloader
    {
        public async Task Download(string url)
        {
            using(var client = new HttpClient())
            {
                await client.GetAsync(new Uri(url));
            }
        }
    }
}
