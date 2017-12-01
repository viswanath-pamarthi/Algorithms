using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/maximum-subarray/description/
/// Find the contiguous subarray within an array (containing at least one number) which has the largest sum.
///
///For example, given the array[-2, 1, -3, 4, -1, 2, 1, -5, 4],
///the contiguous subarray[4, -1, 2, 1] has the largest sum = 6.
///
///  click to show more practice.
///
///  More practice:
///If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
/// </summary>
namespace LeetCode
{
    class MaxSubArraySum
    {
        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            //Edge cases - input array should be greater than 0, if size is one return the value of index 0        
            if (nums.Length == 0)
            {
                return 0;
            }


            //referred the discussion section for a better idea  
            //1.Using dynamic programming and key is that if the sum is negative then ignore that and start from the next
            //2.other way of doing is that start at index 0 and find the sums of 0,1 and find 0,2 by using 0,1 sum and so on till 0,length-1. next start with index 1 and find sums of 1,2 then 1,2+ 3 index and so on
            //However, second approach takes O(n^2), the first one takes O(n)                

            int maxSum = nums[0];//assign the 0 index to be the max sum and 
            int[] sumTillaIndex = new int[nums.Length];
            sumTillaIndex[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                //check if the sum is negative till previous index, if so, ignore that and take the current index
                sumTillaIndex[i] = sumTillaIndex[i - 1] >= 0 ? sumTillaIndex[i - 1] + nums[i] : nums[i];
                maxSum = Math.Max(sumTillaIndex[i], maxSum);
            }


            //what if all the numbers are negative ? - It works as you will be updating the max sum at every index and then checking if the sum is max. so the max of -5,-4,-3,-1,-2,-7 will be -1

            return maxSum;
        }
    }
}
