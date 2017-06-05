using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Given a collection of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.
///
///Each number in C may only be used once in the combination.
///
///Note:
///All numbers (including target) will be positive integers.
///The solution set must not contain duplicate combinations.
///For example, given candidate set[10, 1, 2, 7, 6, 1, 5] and target 8,
///A solution set is: 
///[
///  [1, 7],
///  [1, 2, 5],
///  [2, 6],
///  [1, 1, 6]
///]
/// </summary>
namespace LeetCode
{
    class CombinationSum2
    {
        /// <summary>
        /// https://leetcode.com/problems/combination-sum/#/solutions
        /// referred solution from above link
        /// This problem solving involves Back Tracking, 
        /// https://www.hackerearth.com/practice/basic-programming/recursion/recursion-and-backtracking/tutorial/
        /// Recursion
        //http://web.mit.edu/6.005/www/fa16/classes/14-recursion/
        /// C# - https://www.codeproject.com/Questions/325178/Difference-between-ilist-and-list-in-asp-net
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<List<int>> combinationSum2(int[] nums, int target)
        {
            //List of all solutions
            IList<List<int>> list = new List<List<int>>();
            //int[] uniqueNums = nums.Distinct().ToArray();
            Array.Sort(nums);

            //Start doing backtracking
            backtrack(list, new List<int>(), nums, target, 0);

            //Return the list of solutions
            return list;
        }

        /// <summary>
        /// Backtracking method
        /// </summary>
        /// <param name="solutions">Main list of solutions, passed by reference like arrays in c</param>
        /// <param name="tempList">Temporary list of current solution</param>
        /// <param name="nums">input of numbers</param>
        /// <param name="rem">target minus sum of the current solution available in the temp list</param>
        /// <param name="start"></param>
        private void backtrack(IList<List<int>> solutions, List<int> tempList, int[] nums, int rem, int start)
        {
            //Base condition, difference of the current number and the remaining part of the sum is negative
            if (rem < 0)
                return;
            else if (rem == 0)//If the remaing sum is 0, that is we got a solution for the target
                solutions.Add(new List<int>(tempList));//Add the new solution to list
            else
            {
                //Loop through the list of the numbers in the list.
                for (int i = start; i < nums.Length; i++)
                {
                    if (i > 0 && (nums[i] == nums[i - 1]) && i > start)//preventing duplicate
                        continue;

                    if (rem >= nums[i])// if the remaing part of the target is less than the current number in the array then there is no reason to check the rest of numbers
                                       //in the array(as input array is sorted initially)
                    {
                        
                        tempList.Add(nums[i]);// add the number to temp solution list
                        backtrack(solutions, tempList, nums, rem - nums[i], i);//call back tracking on the array, with index starting at i again as the number can repeat as per problem description
                                                                               //if we want the numbers to be unique in the solution list then pass i+1(so the cuurent number won't be considered for the solution again)

                        tempList.RemoveAt(tempList.Count - 1);// remove the current number from the solution, the actual solution is already added to the main list of solutions when the base condition((rem == 0) is met during the recursive calls
                    }

                }
            }
        }
    }
}
