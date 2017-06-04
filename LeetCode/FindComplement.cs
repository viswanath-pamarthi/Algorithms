using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Given a positive integer, output its complement number. The complement strategy is to flip the bits of its binary representation.
///
///Note:
///The given integer is guaranteed to fit within the range of a 32-bit signed integer.
///You could assume no leading zero bit in the integer’s binary representation.
///Example 1:
///Input: 5
///Output: 2
///Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.
///Example 2:
///Input: 1
///Output: 0
///Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.
/// </summary>
namespace LeetCode
{
    class FindComplement
    {
        /// <summary>
        /// Referred the solutions
        /// https://leetcode.com/problems/number-complement/#/solutions
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int FindTheComplement(int num)
        {
            /* int complement = 0;
             for(int i=0;i<32;i++) //didn't pass all the cases
             {
                 int temp=1<<i;

                 if(temp>num)
                    break;

                 if((temp&num)==0)
                 {
                    complement += 1<<i   ;
                 }
             }*/

            //Referred solutions, c++
            int mask = ~0;

            while ((num & mask) != 0)
            {
                mask = mask << 1;
            }

            return ((~num) & (~mask));
        }
    }
}
