using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Purchase
    {
        public int ConsumerCode { get; private set; }
        public string ArticleNumber { get; private set; }
        public string StoreName { get; private set; }
        public int TotalCost { get; private set; }

        public Purchase(ConsumerDiscount consumer, GoodPrice good, Store store)
        {
            ConsumerCode = consumer.ConsumerCode;
            ArticleNumber = good.ArticleNumber;
            StoreName = store.Name;
            TotalCost = good.Price * consumer.Discount / 100;
        }
    }
}
