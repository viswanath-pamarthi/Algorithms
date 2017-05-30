using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/array-partition-i/#/description
/// Given an array of 2n integers, your task is to group these integers into n pairs of integer, say (a1, b1), (a2, b2), ..., (an, bn) which makes sum of min(ai, bi) for all i from 1 to n as large as possible.
///Example 1:
///Input: [1,4,3,2]
///
///Output: 4 (maximunm possible sum by adding  min(each pair)
///Explanation: n is 2, and the maximum sum of pairs is 4.
///Note:
///n is a positive integer, which is in the range of[1, 10000].
///All the integers in the array will be in the range of[-10000, 10000].
/// </summary>
namespace LeetCode
{
    class ArrayPartition_I
    {
        /// <summary>
        /// sort the numbers in array and make the consecutive number in the array pair to make the maximm possible sum
        ///  Question ...maximunm possible sum by adding  min(each pair)
        /// https://discuss.leetcode.com/topic/87206/java-solution-sorting-and-rough-proof-of-algorithm
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ArrayPairSum(int[] nums)
        {
            int result=0;
            
            //Sort the numbers in array
            Array.Sort(nums);

            //As the consecutive numbers in array are paired, the alternative numbers in the array(smallest number in each pair) are added
            for (int i = 0; i < nums.Length; i += 2)
            {
                result += nums[i];
            }
            
            return result;
        }
    }
}
