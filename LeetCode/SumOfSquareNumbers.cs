using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// https://leetcode.com/problems/sum-of-square-numbers/discuss/
/// Given a non-negative integer c, your task is to decide whether there're two integers a and b such that a2 + b2 = c.
///
///Example 1:
///Input: 5
///Output: True
///Explanation: 1 * 1 + 2 * 2 = 5
///Example 2:
///Input: 3
///Output: False
/// </summary>
namespace LeetCode
{
    class SumOfSquareNumbers
    {
        /// <summary>
        /// Time complexity is O(sqrt(n))
        /// </summary>
        /// <param name="c"></param>
        /// <returns>bool</returns>
        public bool JudgeSquareSum(int c)
        {
            //referred the solutions section for the idea to solve
            //a^2+b^2=c;b=sqrt(c-a^2); a^2 should be less than c value or equal to zero ; c-a^2=0 then c=a^2 -> a<sqrt(c) at the same time when c-a^2 is zero then b=0 as a decreases in c-a^2 the b value increases from 0
            //interchange a and b in the previous example
            if (c < 0)
                return false;

            int a = 0;
            int b = (int)Math.Sqrt(c);

            //<= beacause if they cross then again we would be checking the duplicate cases or already checked cases
            while (a <= b)
            {
                int tempC = a * a + b * b;

                if (tempC < c)
                {
                    //b is already at it's max value Math.sqrt(c), so have to increase the a value;
                    a++;
                }
                else if (tempC > c)
                {
                    b--;
                }
                else
                    return true;
            }

            return false;
        }
    }
}
