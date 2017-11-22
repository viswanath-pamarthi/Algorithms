using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Implement pow(x, n).
///
///
///Example 1:
///
///Input: 2.00000, 10
///Output: 1024.00000
///Example 2:
///
///Input: 2.10000, 3
///Output: 9.26100
/// </summary>
namespace LeetCode
{
    class Power_x_n_
    {
        /// <summary>
        /// Method to caluculate the power of x
        /// Time complexity is O(log n) to base 2
        /// Recursive equation F(n)=1+T(n/2), recursively solve the eueation by using the base case when f(n)=k+T(n/2^k)
        /// usign base case k=log n to base 2
        /// </summary>
        /// <param name="x">input</param>
        /// <param name="n">power</param>
        /// <returns></returns>
        public double MyPow(double x, int n)
        {

            //Referred the solutions section for the idea of using divide and conquere method              
            if (n == 0)
                return 1;

            //Getting the product of half of n,  so can just double it
            double partialResult = MyPow(x, n / 2);

            if (n % 2 == 0)
                return n < 0 ? (partialResult * partialResult) : partialResult * partialResult;
            else
                return n < 0 ? (partialResult * partialResult * (1 / x)) : (partialResult * partialResult * x);//only for the n=1 and n=odd then the n=5 then n=1 and n=5 stages only uses this
        }
    }
}
