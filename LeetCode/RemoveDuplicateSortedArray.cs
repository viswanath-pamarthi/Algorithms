using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/
/// Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.
///
///Do not allocate extra space for another array, you must do this in place with constant memory.
///
///For example,
///Given input array nums = [1, 1, 2],
///
///Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively.It doesn't matter what you leave beyond the new length.
///
///
/// </summary>
namespace LeetCode
{
    class RemoveDuplicateSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {
            int m = 1;//new length/index of the array
            int j = 0, i = j + 1;

            if (nums.Length <= 1)
                return nums.Length;

            while (i < nums.Length)
            {
                if (nums[i] != nums[j])
                {
                    nums[m] = nums[i];
                    m++;
                    j = i;
                }

                i++;
            }

            return m;
        }
    }
}
