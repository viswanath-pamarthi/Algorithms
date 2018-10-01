using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/move-zeroes/description/
/// Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
///
///Example:
///
///Input: [0,1,0,3,12]
///Output: [1,3,12,0,0]
///Note:
///
///You must do this in-place without making a copy of the array.
///Minimize the total number of operations.
/// </summary>
namespace LeetCode
{
    class MoveZeroes
    {
        public void MoveZeroes1(int[] nums)
        {

            //find zero's and their count
            int lastIndexOfArray = nums.Length - 1;

            //Shift all elements left when a zero is encountered from right and record the count of zero's
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] == 0)
                {
                    //do shift of elements to left from the actual length based in non-zero elements
                    shift(nums, lastIndexOfArray, i);
                    lastIndexOfArray--;
                }
            }

        }

        public void shift(int[] nums, int lastIndexOfArray, int currentZeroIndex)
        {
           
            for (int i = currentZeroIndex; i + 1 <= lastIndexOfArray; i++)
            {
                nums[i] = nums[i + 1];
            }

            nums[lastIndexOfArray] = 0;

            return;
        }
    }
}
