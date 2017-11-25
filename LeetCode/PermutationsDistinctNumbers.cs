using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/permutations/description/
/// Given a collection of distinct numbers, return all possible permutations.
///
///For example,
///[1, 2, 3] have the following permutations:
///[
///  [1,2,3],
///  [1,3,2],
///  [2,1,3],
///  [2,3,1],
///  [3,1,2],
///  [3,2,1]
///]
/// </summary>
namespace LeetCode
{
    class PermutationsDistinctNumbers
    {
        /// <summary>
        /// Time Complexity ?
        /// 
        /// Programming Terms: Combinations and Permutations
        /// https://www.youtube.com/watch?v=QI9EczPQzPQ
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            //https://www.youtube.com/watch?v=78t_yHuGg-0&t=2s
            //video in back tracking on permutations of strings - Helpful
            IList<int> choosenPermutations = new List<int>();
            IList<IList<int>> finalPermutations = new List<IList<int>>();

            calculatePermutations(nums, choosenPermutations, finalPermutations);
            return (finalPermutations);

        }

        /// <summary>
        /// Method to do the backtracking 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="choosenPermutations"></param>
        /// <param name="finalPermutations"></param>
        public void calculatePermutations(int[] nums, IList<int> choosenPermutations, IList<IList<int>> finalPermutations)
        {
            //when all numbers are choosen for permutation, add the permutaion to finalPermutations list
            if (nums.Length == 0)
            {
                //list.add seems to be adding a reference to the original object?
                //https://stackoverflow.com/questions/13275768/list-add-seems-to-be-adding-a-reference-to-the-original-object
                finalPermutations.Add(new List<int>(choosenPermutations)); //if new has to be done, else the reference to same choosenPermutaions is being added and all the list items in the finalPermutations are same and all the modifications to the choosenPermutations list are being shown for all the list items in finalPermutations           
            }
            

            //Loop through number
            for (int i = 0; i < nums.Length; i++)
            {
                //choose
                choosenPermutations.Add(nums[i]);

                List<int> tempList = new List<int>(nums);
                tempList.Remove(nums[i]);//remove the choosen letter for the remaining positions as it is already choosen for this position
                
                //explore
                calculatePermutations(tempList.ToArray(), choosenPermutations, finalPermutations);

                //unchoose
                choosenPermutations.Remove(nums[i]);//step of back tracking unchoosing and trying another possibility in next step
            }
        }
    }
}
