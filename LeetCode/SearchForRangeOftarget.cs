using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/search-for-a-range/description/
/// Given an array of integers sorted in ascending order, find the starting and ending position of a given target value.
///
///Your algorithm's runtime complexity must be in the order of O(log n).
///
///If the target is not found in the array, return [-1, -1].
///
///For example,
///Given[5, 7, 7, 8, 8, 10] and target value 8,
///return [3, 4].
/// </summary>
namespace LeetCode
{
    class SearchForRangeOfTarget
    {
        /// <summary>
        /// Time complexity of O(log n), since used binary search
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int lowerIndex = 0;
            int higherIndex = nums.Length - 1;
            int[] result = new int[2] { -1, -1 };//store the resulting indexs of target

            //perform binary search
            while (lowerIndex <= higherIndex)
            {
                int mid = (lowerIndex + higherIndex) / 2;
                
                //target is found
                if (nums[mid] == target)
                {
                    //set the first index of occurence- check if there are target elements before the mid

                    int startIndex = mid;

                    while (startIndex > 0)
                    {
                        if (nums[startIndex - 1] == target)
                            startIndex--;
                        else
                            break;

                    }

                    //set the start Index
                    result[0] = startIndex;

                    //set the last index of occurence- check if there are target elements after the mid
                    int endIndex = mid;

                    //till <Length-1 as we are validating +1 element in side
                    while (endIndex < nums.Length - 1)
                    {
                        if (nums[endIndex + 1] == target)
                            endIndex++;
                        else
                            break;

                    }

                    //set the end Index
                    result[1] = endIndex;

                    return result;
                }
                else if (target > nums[mid])
                    lowerIndex = mid + 1;//check in the next part of list
                else
                    higherIndex = mid - 1;//check in the first part of list
            }

            return result;
        }
    }
}
