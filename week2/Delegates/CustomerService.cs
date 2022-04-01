using Delegates.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class CustomerService
    {
        private delegate double Calculate(Order order);

        private static double calculateTotal(Customer customer, Order order, Calculate func)
        {
            return func(order);
        }

        public double CalculateTotal(Customer customer, Order order)
        {
            switch (customer.Type)
            {
                case CustomerType.NewClient: 
                    return calculateTotal(customer, order, (order) => order.Amount*1);
                case CustomerType.PermanentWithSmallOrders: 
                    return calculateTotal(customer, order, (order) => order.Amount*0.95);
                case CustomerType.PermanentWithLargeOrders:
                    return calculateTotal(customer, order, (order) => 
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
}
