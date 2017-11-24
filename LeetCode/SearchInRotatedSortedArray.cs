using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/search-in-rotated-sorted-array/description/
/// Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
///
///(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
///
///You are given a target value to search.If found in the array return its index, otherwise return -1.
///
///You may assume no duplicate exists in the array.
/// </summary>
namespace LeetCode
{
    class SearchInRotatedSortedArray
    {
        /// <summary>
        /// Time complexity of O(log n to base 2) (for finding the smallest element in the array)
        /// 
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {

            if (nums.Length == 0)
                return -1;

            if (target == nums[0])
            {
                return 0;
            }

            //O(n) time complexity for this solutions
            /*for(int i=0;i<nums.Length;i++)
            {
                if(nums[i]==target)
                    return i;
            }*/

            //Referred the discussions section for the O(log n) solution

            //Find the lowest element in the list, that will divide the list in to exact parts of rotation
            //using the binary search approach to find hte minimum element

            int lowerIndex = 0;
            int higherIndex = nums.Length - 1;

            //lowerIndex == higherIndex is where you find the lowest element
            while (lowerIndex < higherIndex)
            {
                int mid = (lowerIndex + higherIndex) / 2;

                if (nums[mid] > nums[higherIndex])
                    lowerIndex = mid + 1;
                else
                    higherIndex = mid;
            }

            //save the point of rotation or the lowest element in the list
            int smallestElementIndex = lowerIndex;


            //search in the second part of the list, i.e. the smallest set
            if (target <= nums[nums.Length - 1])
            {
                lowerIndex = smallestElementIndex;
                higherIndex = nums.Length - 1;
            }
            else//search in the first part of the list
            {
                lowerIndex = 0;
                higherIndex = smallestElementIndex - 1;
            }

            //Find the target based on the binary search approach
            while (lowerIndex <= higherIndex)
            {
                int mid = (lowerIndex + higherIndex) / 2;

                if (nums[mid] == target)
                    return mid;
                else if (target < nums[mid])
                    higherIndex = mid - 1;
                else if (target > nums[mid])
                    lowerIndex = mid + 1;
            }
            

            return -1;
        }
    }
}
