using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/reverse-integer/description/
/// 
/// Reverse digits of an integer.
///
///Example1: x = 123, return 321
///Example2: x = -123, return -321
///
///click to show spoilers.
///
///Have you thought about this?
///Here are some good questions to ask before coding. Bonus points for you if you have already thought through this!
///
///If the integer's last digit is 0, what should the output be? ie, cases such as 10, 100.
///
///Did you notice that the reversed integer might overflow? Assume the input is a 32-bit integer, then the reverse of 1000000003 overflows.How should you handle such cases?
///
///For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
///
///Note:
///The input is assumed to be a 32-bit signed integer.Your function should return 0 when the reversed integer overflows.
/// </summary>
namespace LeetCode
{
    class ReverseInteger
    {
        /// <summary>
        /// Reefrred from discussions, like the idea of using the long int to handle the overflow condition
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int Reverse(int number)
        {
            int result = 0;

            while(number>0)
            {
                result = result * 10 + number % 10;
                
                //overflow
                if (result / 10 != 0)
                    return 0;

                number /= 10;
            }

            //if (result > int.MaxValue || result < int.MinValue)
              //  return 0;

            return (int)result;
        }
    }
}
