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
        /// Note: There are good hints on website to make you understand the concept
        /// https://leetcode.com/problems/count-primes/#/hints
        ///  Sieve of Eratosthenes concept
        ///  
        /// Count the number of Prime numbers less than n
        /// referred the solutions section:
        /// https://leetcode.com/problems/count-primes/#/solutions
        /// 
        /// https://leetcode.com/problems/count-primes/#/hints
        /// Let's write down all of 12's factors:
        ////
        ////2 × 6 = 12
        ////3 × 4 = 12
        ////4 × 3 = 12
        ////6 × 2 = 12
        ////As you can see, calculations of 4 × 3 and 6 × 2 are not necessary.Therefore, we only need to consider factors up to √n because, if n is divisible by some number p, then n = p × q and since p ≤ q, we could derive that p ≤ √n.
        ////
        ////Our total runtime has now improved to O(n1.5), which is slightly better.Is there a faster approach?
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Count of Prime numbers</returns>
        public int CountPrimeNumbers(int n)
        {
            List<bool> isPrime = Enumerable.Repeat(true, n).ToList();

            int i = 0;
            int j = 0;

            if (n > 0)
                isPrime[0] = false;

            if (n > 1)
                isPrime[1] = false;

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

            return isPrime.Select(a =>a).Where(k=>k==true).Count();
        }
    }
}
