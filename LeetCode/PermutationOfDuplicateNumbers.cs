using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/permutations-ii/description/
/// Given a collection of numbers that might contain duplicates, return all possible unique permutations.
///
///For example,
///[1, 1, 2] have the following unique permutations:
///[
///  [1,1,2],
///  [1,2,1],
///  [2,1,1]
///]
/// </summary>
namespace LeetCode
{
    class PermutationOfDuplicateNumbers
    {
        /// <summary>
        /// recursion and  Back tracking are used
        /// Time Complexity ?
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> permutations = new List<IList<int>>();
            IList<int> permutation = new List<int>();

            //Sort to take care of preventing the duplicate numbers from taking the same slot again
            Array.Sort(nums);

            CalculatePermutations(nums, permutation, permutations, nums.Length);

            return permutations;
        }

        //Using Backtracking
        public void CalculatePermutations(int[] inputNumbers, IList<int> permutation, IList<IList<int>> permutations, int availableSlotsInPermutation)
        {
            //Base condition
            if (availableSlotsInPermutation == 0)
                permutations.Add(new List<int>(permutation));

            //Loop through the numbers available
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                //Condition to prevent the duplicate number to be considered for the same slot. As considering the duplicate number will generate duplicate combinations
                if (i > 0 && (inputNumbers[i] == inputNumbers[i - 1]))
                {
                    continue;
                }

                List<int> tempList = new List<int>(inputNumbers);
                tempList.RemoveAt(i);//To pass the input without current number fixed for a position

                permutation.Add(inputNumbers[i]);

                //Do a call to fill the rest of the slots(i.e. n-1)
                CalculatePermutations(tempList.ToArray(), permutation, permutations, availableSlotsInPermutation - 1);

                permutation.RemoveAt(permutation.Count - 1);//remove the current number to try another number, key step on bsck tracking
            }
        }
    }
}
