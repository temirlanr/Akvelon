using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class GoodPrice
    {
        public string ArticleNumber { get; private set; }
        public string StoreName { get; private set; }
        public int Price { get; private set; }

        public GoodPrice(Good good, Store store, int price)
        {
            ArticleNumber = good.ArticleNumber;
            StoreName = store.Name;
            Price = price;
        }
    }
}
