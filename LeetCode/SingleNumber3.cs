using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/single-number-iii/#/description
/// Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once.
///
///For example:
///
///Given nums = [1, 2, 1, 3, 2, 5], return [3, 5].
///
///Note:
///The order of the result is not important.So in the above example, [5, 3] is also correct.
///Your algorithm should run in linear runtime complexity.Could you implement it using only constant space complexity?
/// </summary>
namespace LeetCode
{
    class SingleNumber3
    {
        /// <summary>
        /// referred solution:
        /// https://leetcode.com/problems/single-number-iii/#/solutions
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SingleNumber(int[] nums)
        {
            //referred solution:
            //https://leetcode.com/problems/single-number-iii/#/solutions
            int diffBit = 0;

            foreach (int number in nums)
                diffBit ^= number;//Finally we get the XOR of the two wanted numbers, others cancel as A^A=0

            //Find the least significant bit where the two numbers are varying, i.e where the least significant bit of the XOR result is set (as 1^0 =1 or 0^1=1)
            diffBit &= -diffBit;//-diffBit is the 2's complement you will get the result where only one bit is set(differing one). e.g 3^5 =6.. 6= 110 , -6=010 . 6^ -6 = 010 (i.e. 2, second least significant bit is set

            //now do the Xor operations for the number by dividing based on the differring bit
            int[] results = new int[2] { 0,0};
            for(int i=0;i<nums.Length;i++)
            {
                if((diffBit &nums[i]) !=0)//Bit set
                {
                    results[0] ^= nums[i];
                }
                else//Bit not set
                {
                    results[1] ^= nums[i];
                }
            }
            return results;
        }

    }
}
