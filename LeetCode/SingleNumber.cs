using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/single-number/#/description
/// Given an array of integers, every element appears twice except for one. Find that single one.
///
///Note:
///Your algorithm should have a linear runtime complexity.Could you implement it without using extra memory?
/// </summary>
namespace LeetCode
{
    class SingleNumber
    {
        public int MissingSingleNumber(int[] nums)
        {
            int result;
            result = nums[0];

            for (int i = 1; i < nums.Length; i++)
                result ^= nums[i];

            return result;
        }
    }
}
