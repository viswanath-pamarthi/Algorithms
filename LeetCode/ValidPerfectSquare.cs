using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/valid-perfect-square/description/
/// Given a positive integer num, write a function which returns True if num is a perfect square else False.
///
///Note: Do not use any built-in library function such as sqrt.
///
///Example 1:
///
///Input: 16
///Returns: True
///Example 2:
///
///Input: 14
///Returns: False
/// </summary>
namespace LeetCode
{
    class ValidPerfectSquare
    {
        /// <summary>
        /// Method to validate if number is a perfect square
        /// </summary>
        /// <param name="num">number to be validated</param>
        /// <returns></returns>
        public bool IsPerfectSquare(int num)
        {
            int oddNumber = 1;
            int stepForNextOddNumber = 2;

            //Used the concept of 1+3+5+7+... perfect square is addition of odd numbers, each consecutive odd number is an increment of 2
            //4= 1 + 3
            //9=1+3+5
            //decrement the
            while (num > 0)
            {
                num -= oddNumber;
                oddNumber += stepForNextOddNumber;
            }

            //I num is 0 then it is a perfect square
            if (num == 0)
                return true;

            return false;
        }
    }
}
