using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/max-consecutive-ones/description/
    /// Given a binary array, find the maximum number of consecutive 1s in this array.
    ///
    ///Example 1:
    ///Input: [1,1,0,1,1,1]
    ///Output: 3
    ///Explanation: The first two digits or the last three digits are consecutive 1s.
    ///    The maximum number of consecutive 1s is 3.
    ///Note:
    ///
    ///The input array will only contain 0 and 1.
    ///The length of input array is a positive integer and will not exceed 10,000
    ///
    /// </summary>
    class MaxConsecutiveOnes
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxOneCount = 0;
            int tempOneCount = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1 && tempOneCount >= 0)
                {
                    tempOneCount++;

                    if (tempOneCount > maxOneCount)
                        maxOneCount = tempOneCount;
                }
                else
                {
                    if (tempOneCount > maxOneCount)
                        maxOneCount = tempOneCount;

                    tempOneCount = 0;
                }

            }

            return maxOneCount;
        }
    }
}
