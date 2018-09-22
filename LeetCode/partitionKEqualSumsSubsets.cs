using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/partition-to-k-equal-sum-subsets/description/
/// Given an array of integers nums and a positive integer k, find whether it's possible to divide this array into k non-empty subsets whose sums are all equal.
///
///Example 1:
///Input: nums = [4, 3, 2, 3, 5, 2, 1], k = 4
///Output: True
///Explanation: It's possible to divide it into 4 subsets (5), (1, 4), (2,3), (2,3) with equal sums.
///Note:
/// 
/// </summary>
namespace LeetCode
{
    class partitionKEqualSumsSubsets
    {
        /// <summary>
        /// Time Complexity: ??
        /// Space Complexity: ??
        /// Dynamic Programming (isTaken array to prevent the callculated numbers of subsets) - backtracking is used 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            //Will use back tracking to find the subsets

            //First - what is the sum you will find the pairs for ?
            //since the whole array should be divided to k subsets, the sum of all the numbers should be K * (TargetSum). So, to solve this problem, the pre requisite is that the given numbers sum %k should be zero

            int sum = 0;
            int targetSum = 0;//This is the target sum the divided pairs should add up to

            foreach (var item in nums)
            {
                sum += item;
            }

            //sum of the numbers in given array should be exactly divisible by the k and also k should be greater than 0
            if (sum % k != 0 || k <= 0)
                return false;

            targetSum = sum / k;

            //To hold the list of subsets 
            IList<IList<int>> subsets = new List<IList<int>>();
            IList<int> subsetIndexes = new List<int>();//store a partcular subset
            int[] isTaken = new int[nums.Length];// To check if he number is already choosen for another set then it will be '1'

            //FindKSubsets(nums, 0, targetSum, targetSum, subsetIndexes, subsets, isTaken);
            return FindKSubsets(nums, 0, targetSum, 0, k, isTaken);

            // if(subsets.Count==k)
            //return true;

            //Console.WriteLine(subsets.Count);


            //return false;
        }

        public bool FindKSubsets(int[] nums, int startIndex, int targetSum, int currentSum, int numberOfPartsLeft, int[] isTaken)  //IList<int> subsetIndexes, IList<IList<int>> subsets, int[] isTaken)
        {
            //Base case if the numberOfPartsLeft is one then success, we already checked if the sum of the numbers in the given array is equal
            if (numberOfPartsLeft == 1)
                return true;

            //one part of the numberOfPartLeft (k) is done, find the next part from here
            if (currentSum == targetSum)
            {

                return FindKSubsets(nums, 0, targetSum, 0, numberOfPartsLeft - 1, isTaken);

                /*subsets.Add(new List<int>(subsetIndexes));

                   foreach(int index in subsetIndexes)
                   {
                       isTaken[index]=1;
                   }

                   return true;
               }
               else                            
               return false;*/
            }

            for (int i = startIndex; i < nums.Length; i++)
            {
                //bool isSetTaken=false;

                //subsetIndexes.Add(i);
                //isTaken[i]=1;

                //if(nums[i]<=remainingSum )
                if (isTaken[i] == 0 && currentSum + nums[i] <= targetSum)
                {
                    isTaken[i] = 1;//choose
                                   //isSetTaken=FindKSubsets(nums, i+1,targetSum, currentSum+nums[i], numberOfPartsLeft, isTaken);

                    if (FindKSubsets(nums, i + 1, targetSum, currentSum + nums[i], numberOfPartsLeft, isTaken))
                        return true;

                    isTaken[i] = 0;//unchoose
                }

                //subsetIndexes.Remove(i);   


                //if(isSetTaken &&  remainingSum<=targetSum )
                //    return isSetTaken;
            }

            return false;
        }
    }
}
