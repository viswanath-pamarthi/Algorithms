using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/combinations/description/
/// Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.
///
///For example,
///If n = 4 and k = 2, a solution is:
///
///[
//   [1,2],
///  [1,3],
///  [1,4],
///  [2,3],
///  [2,4],
///  [3,4],
///]
///
/// Note: In combinations, 1,2 is same as 2,1. The order doesn't matter. In permutations the order matters
/// </summary>
namespace LeetCode
{
    class CombinationsDistinctNumbers
    {
        /// <summary>
        /// backtracking
        /// Time Complexity ?
        /// 
        /// 
        /// Combinations of a String - Computer Science Challenge Part 1/3
        /// https://www.youtube.com/watch?v=6WNEje7MZDg
        /// 
        /// Programming Terms: Combinations and Permutations
        /// https://www.youtube.com/watch?v=QI9EczPQzPQ
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<int> combination = new List<int>();//to store the current active combination
            IList<IList<int>> combinations = new List<IList<int>>();//To store all the combinations

            //Generate the n number series
            //int[] inputNumbers=Enumerable.Range(1,n).ToArray();

            //Calculate the combinations
            CalculateCombinations(n, 1, k, combination, combinations);

            return combinations;
        }

        /// <summary>
        /// Method to do backtracking
        /// </summary>
        /// <param name="totalNumbers"></param>
        /// <param name="startingNumber"></param>
        /// <param name="avialableSlotsInCombination">number of slots available in a combination</param>
        /// <param name="combination"></param>
        /// <param name="combinations"></param>
        public void CalculateCombinations(int totalNumbers, int startingNumber, int avialableSlotsInCombination, IList<int> combination, IList<IList<int>> combinations)
        {
            //Base condition, when 0 slots available in a particular cobmination of original k digit combination
            if (avialableSlotsInCombination == 0)
            {
                combinations.Add(new List<int>(combination));
            }

            for (int i = startingNumber; i <= totalNumbers; i++)
            {
                //Add the number i, say 1 to the current active combination, say k=3 to start of the particular combination, then passing that start is from 2 and available slots are 2 (k-1=3-1)
                combination.Add(i);

                //Find the combinations for the other available slots
                CalculateCombinations(totalNumbers, i + 1, avialableSlotsInCombination - 1, combination, combinations);

                //Remove the number from combination to try the other avilable numbers
                combination.Remove(i);
            }

        }
    }
}
