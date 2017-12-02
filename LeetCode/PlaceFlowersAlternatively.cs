using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/can-place-flowers/description/
/// Suppose you have a long flowerbed in which some of the plots are planted and some are not. However, flowers cannot be planted in adjacent plots - they would compete for water and both would die.
///
///Given a flowerbed(represented as an array containing 0 and 1, where 0 means empty and 1 means not empty), and a number n, return if n new flowers can be planted in it without violating the no-adjacent-flowers rule.
///
///Example 1:
///Input: flowerbed = [1, 0, 0, 0, 1], n = 1
///Output: True
///Example 2:
///Input: flowerbed = [1, 0, 0, 0, 1], n = 2
///Output: False
///Note:
///The input array won't violate no-adjacent-flowers rule.
///The input array size is in the range of[1, 20000].
///n is a non-negative integer which won't exceed the input array size.
/// </summary>
namespace LeetCode
{
    class PlaceFlowersAlternatively
    {
        /// <summary>
        /// Time complexity O(n), iterating through the n elements, even though doing i=i+2; even though n/2 then O is n
        /// </summary>
        /// <param name="flowerbed"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            //maintain on index if 1 is encoutered increment i to i+2
            //if 0 then check if the next number 1 ? then increment index by one else increment newFlowerCount an i to i+2

            int index = 0;
            int possibleNumberOfPlants = 0;

            //If possibleNumberOfPlants<n condition is removed then all possible plantation count is calculated, but for the question is to check if n plantations are possible or not.
            while (index < flowerbed.Length && possibleNumberOfPlants < n)
            {
                if (flowerbed[index] == 1)
                {
                    index += 2;
                }
                else if (flowerbed[index] == 0)
                {
                    //first condition is checked and if not true then second condition is not checked, that way we are avoiding the index out of range error
                    if (index + 1 < flowerbed.Length && flowerbed[index + 1] == 1)
                    {
                        index++;
                    }
                    else
                    {
                        index += 2;
                        possibleNumberOfPlants++;
                    }
                }
            }

            if (possibleNumberOfPlants == n)
                return true;
            else
                return false;
        }
    }
}
