using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
///
///You may assume that each input would have exactly one solution, and you may not use the same element twice.
///
///Example:
///Given nums = [2, 7, 11, 15], target = 9,
///
///Because nums[0] + nums[1] = 2 + 7 = 9,
///return [0, 1].
/// </summary>
namespace LeetCode
{
    class TwoSum
    {
        public int[] TwoSum1(int[] nums, int target)
        {
            int[] result = new int[2] { 0, 0 };

            //Check every possibility in array, as the array is not sorted 
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if ((nums[i] + nums[j]) == target)
                    {
                        result[0] = i;
                        result[1] = j;
                    }
                }

            }

            return result;
        }
    }
}
