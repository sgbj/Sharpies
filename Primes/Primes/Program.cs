using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prints all primes less than a million
            Console.WriteLine(string.Join(", ", Sieve(1000000)));
        }

        static IEnumerable<int> Sieve(int n)
        {
            var list = new long[(n >> 6) + 1];
            for (var i = 3; i * i <= n; i += 2)
                if ((list[i >> 6] & (1 << ((i & 63) >> 1))) == 0)
                    for (var j = i * i; j <= n; j += i << 1)
                        list[j >> 6] |= 1 << ((j & 63) >> 1);
            yield return 2;
            for (var i = 3; i <= n; i += 2)
                if ((list[i >> 6] & (1 << ((i & 63) >> 1))) == 0)
                    yield return i;
        }
    }
}
