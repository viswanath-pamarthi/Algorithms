using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/#/description
/// Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
///
///The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.Please note that your returned answers(both index1 and index2) are not zero-based.
///
///You may assume that each input would have exactly one solution and you may not use the same element twice.
///
///Input: numbers={ 2, 7, 11, 15}, target=9
///Output: index1=1, index2=2
/// </summary>
namespace LeetCode
{
    class TwoSumII
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            int[] result = new int[2] { 0, 0 };
            int lowerIndex, higherIndex;
            lowerIndex = 0;
            higherIndex = numbers.Length - 1;

            //Start with two pointers starting and ending. loop till the sum is not equal to target and also the lower index or leass than higher index
            while ((numbers[lowerIndex] + numbers[higherIndex] != target) &&(lowerIndex<higherIndex))
            {
                //if the sum is less than target then target then increment the lower index to increase the sum
                if (numbers[lowerIndex] + numbers[higherIndex] < target)
                {
                    lowerIndex++;
                }
                else//if the sum is greater than target then decrease the higher index to decrease the sum
                {
                    higherIndex--;
                }
              
            }

            if(lowerIndex>=higherIndex)
            {
                result[0] = 0;
                result[1] = 0;

                return result;
            }
            else
            {
                result[0] = lowerIndex + 1 ;
                result[1] = higherIndex + 1;
            }

            return result;
        }
    }
}
