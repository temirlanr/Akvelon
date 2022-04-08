using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Entities
{
    public class Customer
    {
        public string Name { get; private set; }
        public CustomerType Type { get; private set; }
        public string Address { get; private set; }

        public Customer(string fullName, CustomerType customerType, string customerAddress)
        {
            Name = fullName;
            Type = customerType;
            Address = customerAddress;
        }

        private delegate double Calculate(Order order);

        private Dictionary<CustomerType, Calculate> delegates = new Dictionary<CustomerType, Calculate>
        {
            [CustomerType.NewClient] = (order) => order.Amount * 1,
            [CustomerType.PermanentWithSmallOrders] = (order) => order.Amount * 0.95,
            [CustomerType.PermanentWithLargeOrders] = (order) =>
            {
                if (order.Amount > 100000)
                {
                    return order.Amount * 0.85;
                }
                else
                {
                    return order.Amount * 0.90;
                }
            }
        };
        public double CalculateTotal(Order order)
        {
            return delegates[Type](order);
        }
    }

    public enum CustomerType
    {
        NewClient,
        PermanentWithSmallOrders,
        PermanentWithLargeOrders
    }
}
