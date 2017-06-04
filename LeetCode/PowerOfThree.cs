using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// https://leetcode.com/problems/power-of-three/#/description
/// Given an integer, write a function to determine if it is a power of three.
///
///Follow up:
///Could you do it without using any loop / recursion?
/// </summary>
namespace LeetCode
{
    class PowerOfThree
    {
        /// <summary>
        /// Refereed the solution of this problem.
        /// https://leetcode.com/problems/power-of-three/#/solutions
        /// </summary>
        /// <param name="n">THe number to be checked if it is a power of 3</param>
        /// <returns>true or false</returns>
        public bool IsPowerOfThree(int n)
        {
            if (n > 1)
                while (n % 3 == 0)
                {
                    n = n / 3;
                }
                               
            return n == 1;
        }
    }
}
