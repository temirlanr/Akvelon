using Delegates.Entities;
using Xunit;

namespace DelegatesTest
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateTotal_NewCustomer_EqualNoDiscount()
        {
            Customer newCustomer = new Customer("Jim Carrey", CustomerType.NewClient, "Brown str. 67, Imaginary City");
            Order order1 = new Order(1, "January 18, 2022", 10000);

            var res = newCustomer.CalculateTotal(order1);

            Assert.Equal(10000, res);
        }

        [Fact]
        public void CalculateTotal_LargeCustomer_Equal15PercentDiscount()
        {
            Customer largeCustomer = new Customer("Chris Pratt", CustomerType.PermanentWithLargeOrders, "Potter str. 19, Imaginary City");
            Order order2 = new Order(2, "February 2, 2022", 200000);

            var res = largeCustomer.CalculateTotal(order2);

            Assert.Equal(170000, res);
        }
    }
}