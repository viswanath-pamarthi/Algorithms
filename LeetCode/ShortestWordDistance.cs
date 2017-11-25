using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/shortest-word-distance/description/
/// Given a list of words and two words word1 and word2, return the shortest distance between these two words in the list.
///
///For example,
///Assume that words = ["practice", "makes", "perfect", "coding", "makes"].
///
///Given word1 = “coding”, word2 = “practice”, return 3.
///Given word1 = "makes", word2 = "coding", return 1.
///
///Note:
///You may assume that word1 does not equal to word2, and word1 and word2 are both in the list.
/// </summary>
namespace LeetCode
{
    class ShortestWordDistance
    {
        /// <summary>
        /// Time complexity is O(n)
        /// 
        /// https://www.dotnetperls.com/math-abs
        /// </summary>
        /// <param name="words"></param>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns>shortest distance between the words</returns>
        public int ShortestDistance(string[] words, string word1, string word2)
        {

            int index1 = -1;
            int index2 = -1;
            int minDistance = int.MaxValue;

            for (int i = 0; i < words.Length; i++)
            {
                //matches first word
                if (word1 == words[i])
                    index1 = i + 1;

                //matches second word
                if (word2 == words[i])
                    index2 = i + 1;

                //update min distance
                if ((index1 > 0 && index2 > 0) && Math.Abs(index1 - index2) < minDistance)
                    minDistance = Math.Abs(index1 - index2);
            }



            return minDistance;

        }
    }
}
