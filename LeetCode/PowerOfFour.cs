using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// https://leetcode.com/problems/power-of-four/#/description
/// Given an integer (signed 32 bits), write a function to check whether it is a power of 4.
///
///Example:
///Given num = 16, return true. Given num = 5, return false.
/// </summary>
namespace LeetCode
{
    class PowerOfFour
    {
        /// <summary>
        /// Similar solution as of power of three
        /// </summary>
        /// <param name="num">number to be verified if it a power of 4</param>
        /// <returns>boolean</returns>
        public bool IsPowerOfFour(int num)
        {
            if (num > 1)
                while (num % 4 == 0)
                    num = num / 4;

            return num == 1;
        }
    }
}
