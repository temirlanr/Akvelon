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

        private static double CalculationFormula(Order order, Calculate func)
        {
            return func(order);
        }

        public double CalculateTotal(Order order)
        {
            switch (Type)
            {
                case CustomerType.NewClient:
                    return CalculationFormula(order, (order) => order.Amount * 1);
                case CustomerType.PermanentWithSmallOrders:
                    return CalculationFormula(order, (order) => order.Amount * 0.95);
                case CustomerType.PermanentWithLargeOrders:
                    return CalculationFormula(order, (order) =>
                    {
                        if (order.Amount > 100000)
                        {
                            return order.Amount * 0.85;
                        }
                        else
                        {
                            return order.Amount * 0.90;
                        }
                    });
                default:
                    return -1;
            }
        }
    }

    public enum CustomerType
    {
        NewClient,
        PermanentWithSmallOrders,
        PermanentWithLargeOrders
    }
}
