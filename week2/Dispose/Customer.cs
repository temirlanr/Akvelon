using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispose
{
    public class Customer : IDisposable
    {
        private StringReader _reader;

        public Customer(string s)
        {
            _reader = new StringReader(s);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
