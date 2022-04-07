using System;

namespace Linq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Store> stores = new()
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
                new ConsumerDiscount(consumers[1], stores[1], 6),
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
                new Purchase(consumerDiscounts[2], goodPrices[0], stores[0]),
            };

            // For each country (product manufactor) and each store, determine
            // the consumer with the highest year of birth who bought one or
            // more goods produced in this country in this store (first, the
            // name of the country, then the name of the store, then the year
            // of birth of the consumer, his code, and also the total cost
            // goods from this country purchased in this store). If there is
            // no information about sold goods for some "country-shop" pair,
            // then data about this pair is not displayed. If for some pair
            // "country-store" there are several consumers with the highest
            // year of birth, then data about all such consumers should be
            // displayed. Information about each triple "country-shop-consumer"
            // should be displayed on a new line and sorted by country names in
            // alphabetical order, for identical country names - by store names
            // (also in alphabetical order), and for identical stores - by
            // increasing consumer codes. 
            var res = purchases.Join(consumers,
                p => p.ConsumerCode,
                c => c.ConsumerCode,
                (purchase, consumer) => new
                {
                    consumer.ConsumerCode,
                    consumer.YearOfBirth,
                    purchase.ArticleNumber,
                    purchase.StoreName,
                    purchase.TotalCost
                }).Join(goods,
                pc => pc.ArticleNumber,
                g => g.ArticleNumber,
                (pc, good) => new
                {
                    good.ArticleNumber,
                    good.CountryOfOrigin,
                    pc.ConsumerCode,
                    pc.YearOfBirth,
                    pc.StoreName,
                    pc.TotalCost
                }).OrderBy(pcg => pcg.CountryOfOrigin)
                .ThenBy(pcg => pcg.StoreName)
                .GroupBy(pcg => new
                {
                    pcg.CountryOfOrigin,
                    pcg.StoreName
                }).Select(data => data.ToList().MaxBy(item => item.YearOfBirth))
                .ToList().Select(item => new
                {
                    item.CountryOfOrigin,
                    item.StoreName,
                    item.YearOfBirth,
                    item.ConsumerCode,
                    item.TotalCost
                });

            foreach(var item in res)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}