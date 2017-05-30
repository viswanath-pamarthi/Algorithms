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
        public int[] TwoSum(int[] numbers, int target)
        {
            int[] result = new int[2] { 0, 0 };
            int i, j;
            i = 0;
            j = numbers.Length - 1;

            while ((numbers[i] + numbers[j] != target) &&(i<j))
            {
                if (numbers[i] + numbers[j] < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
              
            }

            if(i>=j)
            {
                result[0] = 0;
                result[1] = 0;

                return result;
            }
            else
            {
                result[0] = i + 1 ;
                result[1] = j + 1;
            }
            return result;
        }
    }
}
