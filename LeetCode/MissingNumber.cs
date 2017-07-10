using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/missing-number/#/description
/// Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.
///
///For example,
///Given nums = [0, 1, 3] return 2.
///
///Note:
///Your algorithm should run in linear runtime complexity.Could you implement it using only constant extra space complexity?
///
///Credits:
///
/// </summary>
namespace LeetCode
{
    class MissingNumber
    {
        /// <summary>
        /// Used the concept of sum of first 'n' natural numbers 1+2+3..... n = (n* n+1)/2;
        /// In the problem the numbers start from 0
        /// sum of first n natural numbers minus  calculate the sum of all the numbers given
        /// 
        /// ************************** A Solution using bit manipulation !******************
        /// https://discuss.leetcode.com/topic/2921/easiest-way-to-solve-by-using-bit-manipulation/2
        /// Logic: XOR will return 1 only on two different bits. So if two numbers are the same, XOR will return 0. Finally only one number left.
        ///A ^ A = 0 and A ^ B ^ A = B.
        ///
        /// class Solution
        ///{
        ///    public:
        ///int singleNumber(int A[], int n)
        ///    {
        ///        int result = A[0];
        ///        for (int i = 1; i lessthan  n; i++)
        ///        {
        ///            result ^= i;
        ///            result = result ^ A[i];  Get the xor of all elements 
        ///        }
        ///        return result;
        ///    }
        /// };
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingNumberSolution(int[] nums)
        {
            int sum = 0;
            int maxNumber = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > maxNumber)
                {
                    maxNumber = nums[i];
                }

                sum += nums[i];
            }

            int actualSum = 0;
            actualSum = ((nums.Length) * (nums.Length + 1)) / 2;


            return actualSum - sum;
        }
    }
}
