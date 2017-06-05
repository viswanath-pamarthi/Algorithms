using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Find all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.
///https://leetcode.com/problems/combination-sum-iii/#/solutions
///
///Example 1:
///
///Input: k = 3, n = 7
///
///Output:
///
///[[1,2,4]]
///
///Example 2:
///
///Input: k = 3, n = 9
///
///Output:
///
///[[1,2,6], [1,3,5], [2,3,4]]
/// </summary>
namespace LeetCode
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            //referred from solutions
            IList<IList<int>> list = new List<IList<int>>();
            //int[] uniqueNums = nums.Distinct().ToArray();
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Array.Sort(nums);

            //Start doing backtracking
            backtrack(list, new List<int>(), nums, n, 0, k);
            return list;
        }

        private void backtrack(IList<IList<int>> solutions, IList<int> tempList, int[] nums, int rem, int start, int countOfNums)
        {
            if (rem < 0)
                return;
            else if ((rem == 0) && (countOfNums == tempList.Count))//count checkig
                solutions.Add(new List<int>(tempList));
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    if (i > 0 && (nums[i] == nums[i - 1]) && i > start)
                        continue;

                    if (rem >= nums[i])
                    {
                        tempList.Add(nums[i]);
                        backtrack(solutions, tempList, nums, rem - nums[i], i + 1, countOfNums);
                        tempList.RemoveAt(tempList.Count - 1);
                    }

                }
            }
        }
    }
}
