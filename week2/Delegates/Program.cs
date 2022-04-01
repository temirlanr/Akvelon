using Delegates.Entities;
using System;

namespace Delegates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Customer newCustomer = new Customer("Jim Carrey", CustomerType.NewClient, "Brown str. 67, Imaginary City");
            Customer smallCustomer = new Customer("Gary Osborne", CustomerType.PermanentWithSmallOrders, "Green str. 18, Imaginary City");
            Customer largeCustomer = new Customer("Chris Pratt", CustomerType.PermanentWithLargeOrders, "Potter str. 19, Imaginary City");

            Order order1 = new Order(1, "January 18, 2022", 10000);
            Order order2 = new Order(2, "February 2, 2022", 123000);
            Order order3 = new Order(3, "March 1, 2022", 5000);

            Console.WriteLine($"New Customer, {newCustomer.Name}, Address: {newCustomer.Address}");
            Console.WriteLine(newCustomer.CalculateTotal(order1));
            Console.WriteLine(newCustomer.CalculateTotal(order2));
            Console.WriteLine(newCustomer.CalculateTotal(order3));

            Console.WriteLine($"Permanent Customer with Small Orders, {smallCustomer.Name}, Address: {smallCustomer.Address}");
            Console.WriteLine(smallCustomer.CalculateTotal(order1));
            Console.WriteLine(smallCustomer.CalculateTotal(order2));
            Console.WriteLine(smallCustomer.CalculateTotal(order3));

            Console.WriteLine($"Permanent Customer with Large Orders, {largeCustomer.Name}, Address: {largeCustomer.Address}");
            Console.WriteLine(largeCustomer.CalculateTotal(order1));
            Console.WriteLine(largeCustomer.CalculateTotal(order2));
            Console.WriteLine(largeCustomer.CalculateTotal(order3));
        }
    }
}