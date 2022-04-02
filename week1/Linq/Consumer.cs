using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Consumer
    {
        public int ConsumerCode { get; private set; }
        public int YearOfBirth { get; private set; }
        public string Address { get; private set; }

        public Consumer(int code, int year, string address)
        {
            ConsumerCode = code;
            YearOfBirth = year;
            Address = address;
        }
    }
}
