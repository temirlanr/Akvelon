using System;

namespace Linq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Store> stores = new List<Store>
            {
                new Store("TechnoDom"),
                new Store("H&M"),
                new Store("Marwin")
            };

            List<Consumer> consumers = new List<Consumer>
            {
                new Consumer(1, 1998, "Astana"),
                new Consumer(2, 1986, "Moscow"),
                new Consumer(3, 2000, "Semey")
            };

            List<Good> goods = new List<Good>
            {
                new Good("AA234-7838", "PCs", "China"),
                new Good("KD923-4821", "Clothes", "France"),
                new Good("IA919-7211", "Toys", "USA")
            };

            List<ConsumerDiscount> consumerDiscounts = new List<ConsumerDiscount>
            {
                new ConsumerDiscount(consumers[0], stores[0], 10),
                new ConsumerDiscount(consumers[1], stores[1], 4),
                new ConsumerDiscount(consumers[2], stores[2], 20)
            };

            List<GoodPrice> goodPrices = new List<GoodPrice>
            {
                new GoodPrice(goods[0], stores[0], 600000),
                new GoodPrice(goods[1], stores[1], 10000),
                new GoodPrice(goods[2], stores[2], 5000)
            };

            List<Purchase> purchases = new List<Purchase>
            {
                new Purchase(consumerDiscounts[0], goodPrices[0], stores[0]),
                new Purchase(consumerDiscounts[1], goodPrices[1], stores[1]),
                new Purchase(consumerDiscounts[2], goodPrices[2], stores[2]),
            };

            // I DONT UNDERStAND :()
        }
    }
}