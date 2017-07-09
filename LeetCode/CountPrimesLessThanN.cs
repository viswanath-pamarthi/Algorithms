using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/count-primes/#/description
/// Description:
///
///Count the number of prime numbers less than a non-negative number, n.
///
///Credits:
///Special thanks to @mithmatt for adding this problem and creating all test cases.
///
///
/// </summary>
namespace LeetCode
{
    class CountPrimesLessThanN
    {
        /// <summary>
        /// Count the number of Prime numbers less than n
        /// referred the solutions section:
        /// https://leetcode.com/problems/count-primes/#/solutions
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Count of Prime numbers</returns>
        public int CountPrimeNumbers(int n)
        {
            List<bool> isPrime = Enumerable.Repeat(true, n).ToList();

            int i = 0;
            int j = 0;
            isPrime[0] = isPrime[1] = false;

            for (i = 2; i < Math.Sqrt(n); ++i)
            {                
                if (isPrime[i])
                {
                    for (j = i*i; j < n; j=j+i)
                    {
                        isPrime[j] = false;
                    }
                }
                
            }

            return isPrime.Select(a => a == true).Count();
        }
    }
}
