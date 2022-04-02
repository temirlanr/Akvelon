using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Linq
{
    public class Good
    {
        public string ArticleNumber { get; private set; }
        public string Category { get; private set; }
        public string CountryOfOrigin { get; private set; }

        private readonly Regex checkNumber = new(@"^[A-Z]{2}\d{3}-\d{4}$");

        public Good(string number, string category, string country)
        {
            if (!checkNumber.IsMatch(number))
            {
                throw new ArgumentException("Format of number: [AAddd-dddd], where the positions marked with the symbol 'A' contain any capital Latin letter, and the positions marked with the symbol 'd' contain some number.");
            }

            ArticleNumber = number;
            Category = category;
            CountryOfOrigin = country;
        }
    }
}
