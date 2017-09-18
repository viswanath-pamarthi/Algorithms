using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// https://leetcode.com/problems/palindrome-temp/description/
/// Determine whether an integer is a palindrome. Do this without extra space.
///
///click to show spoilers.
///
///Some hints:
///Could negative integers be palindromes? (ie, -1)
///
///If you are thinking of converting the integer to string, note the restriction of using extra space.
///
///You could also try reversing an integer.However, if you have solved the problem "Reverse Integer", you know that the reversed integer might overflow.How would you handle such case?
///
///
///There is a more generic way of solving this problem.
/// </summary>
namespace LeetCode
{
    class Palindrometemp
    {
        /// <summary>
        /// method to check if number is palindrome
        /// </summary>
        /// <param name="number">input</param>
        /// <returns></returns>
        public bool IsPalindrome(int number)
        {
            int result = 0;
            int temp = number;

            while(temp>0)
            {
                result = result * 10 + temp % 10;

               // if(result/10 != 0) overflow??
                 //   return false;
                temp = temp / 10;
            }

            if (number == result)
                return true;

            return false;
        }
    }
}
