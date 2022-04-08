using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Solution
    {
        public string CountryOfOrigin { get; set; }
        public string StoreName { get; set; }
        public int YearOfBirth { get; set; }
        public int ConsumerCode { get; set; }
        public int TotalCost { get; set; }

        public static List<Solution> LinqSolution(List<Purchase> purchases, List<Consumer> consumers, List<Good> goods)
        {
            return purchases.Join(consumers,
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
                }).GroupBy(pcg => new
                {
                    pcg.CountryOfOrigin,
                    pcg.StoreName
                }).Select(data => data.ToList()
                .FindAll(item => item.YearOfBirth == data.MaxBy(value => value.YearOfBirth).YearOfBirth))
                .ToList()
                .SelectMany(item => item)
                .OrderBy(pcg => pcg.CountryOfOrigin)
                .ThenBy(pcg => pcg.StoreName)
                .Select(item => new Solution
                {
                    CountryOfOrigin = item.CountryOfOrigin,
                    StoreName = item.StoreName,
                    YearOfBirth = item.YearOfBirth,
                    ConsumerCode = item.ConsumerCode,
                    TotalCost = item.TotalCost
                }).ToList();
        }

        public override bool Equals(object? obj)
        {
            return obj is Solution solution &&
                   CountryOfOrigin == solution.CountryOfOrigin &&
                   StoreName == solution.StoreName &&
                   YearOfBirth == solution.YearOfBirth &&
                   ConsumerCode == solution.ConsumerCode &&
                   TotalCost == solution.TotalCost;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CountryOfOrigin, StoreName, YearOfBirth, ConsumerCode, TotalCost);
        }

        public override string? ToString()
        {
            var type = typeof(Solution);
            var properties = type.GetProperties();

            return $"{properties[0].Name}: {CountryOfOrigin}, \n" +
                   $"{properties[1].Name}: {StoreName}, \n" +
                   $"{properties[2].Name}: {YearOfBirth}, \n" +
                   $"{properties[3].Name}: {ConsumerCode}, \n" +
                   $"{properties[4].Name}: {TotalCost}, \n";
        }
    }
}
