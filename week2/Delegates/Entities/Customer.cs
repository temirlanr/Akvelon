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
    }

    public enum CustomerType
    {
        NewClient,
        PermanentWithSmallOrders,
        PermanentWithLargeOrders
    }
}
