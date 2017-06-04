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
        /// <summary>
        /// My solution for the problem, O(n^2)
        /// </summary>
        /// <param name="nums">Input array of numbers</param>
        /// <param name="target">The target number, where the sum of two numbers equals this target</param>
        /// <returns>The indexes of the numbers in the array, who's sum is equal to target</returns>
        public int[] TwoSum1(int[] nums, int target)
        {
            //results array to store the index of the two numbers
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

        /// <summary>
        /// Another solution using Dictionary, referred "Accepted Java O(n) Solution" leet code
        /// </summary>
        /// <param name="nums">Input array of numbers</param>
        /// <param name="target">The target number, where the sum of two numbers equals this target</param>
        /// <returns>The indexes of the numbers in the array, who's sum is equal to target</returns>
        public int[] TwoSumHashMap(int[] nums, int target)
        {
            //results array to store the index of the two numbers
            int[] result = new int[2] { 0, 0 };
            int index;

            Dictionary<int,int> hashMap = new Dictionary<int, int>();
            
            //loop through the list of numbers
            for(int i=0;i<nums.Length;i++)
            {
                //find the other number by substrating current from target
                if(hashMap.TryGetValue(target-nums[i],out index))//or use trygetvalue method to check if the Dictonary contains the element and at the same time get the value(out variable). Prevents the null exception error if the number is not present in dictonary(if accessed using index)
                {
                    result[0] = index;
                    result[1] = i;
                    return result;
                    //Console.WriteLine("{0} is index one and {1} is index two", index, i);
                }
                else
                {
                    //Add the current number and its index to dictonary
                    hashMap.Add(nums[i], i);
                }
            }

            return result;
        }
    }
}
