using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iremsaral
{
    class Kartlar
    {
        public string renk;
        public int numara;

        public void BilgiYaz()
        {
            Console.WriteLine("{0}-{1} ", renk, numara);
        }
    }
}
