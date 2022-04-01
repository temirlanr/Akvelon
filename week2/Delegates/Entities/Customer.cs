using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Entities
{
    public class Customer
    {
        public string? FullName { get; set; }
        public CustomerType Type { get; set; }
        public string? Address { get; set; }
    }

    public enum CustomerType
    {
        NewClient,
        PermanentWithLargeOrders,
        PermanentWithSmallOrders
    }
}
