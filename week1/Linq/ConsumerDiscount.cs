using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class ConsumerDiscount
    {
        public int ConsumerCode { get; private set; }
        public string StoreName { get; private set; }
        public int Discount { get; private set; }

        public ConsumerDiscount(Consumer consumer, Store store, int discount)
        {
            if(discount >= 50 || discount <= 5)
            {
                throw new ArgumentException("Discount must be between 5 and 50");
            }

            ConsumerCode = consumer.ConsumerCode;
            StoreName = store.Name;
            Discount = discount;
        }
    }
}
