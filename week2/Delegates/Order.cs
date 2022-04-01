using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public string Date { get; private set; }
        public int Amount { get; private set; }

        public Order(int orderNumber, string orderDate, int orderAmount)
        {
            Id = orderNumber;
            Date = orderDate;
            Amount = orderAmount;
        }
    }
}
