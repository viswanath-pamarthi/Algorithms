using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/shortest-word-distance-ii/description/
/// This is a follow up of Shortest Word Distance. The only difference is now you are given the list of words and your method will be called repeatedly many times with different parameters. How would you optimize it?
///
///Design a class which receives a list of words in the constructor, and implements a method that takes two words word1 and word2 and return the shortest distance between these two words in the list.
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
    class ShortestWordDistance2
    {
        Dictionary<string, IList<int>> wordsHashMap;//for quick retrieval of the appropriate word indexes

        /// <summary>
        /// TIme complexity is O(n) ?
        /// </summary>
        /// <param name="words"></param>
        public ShortestWordDistance2(string[] words)
        {
            this.wordsHashMap = new Dictionary<string, IList<int>>();

            //Make a hash map of the words snd corresponding indexes, so that when the shortest method is called many times then the time for response is less. As this work is being done in the constructor
            for (int i = 0; i < words.Length; i++)
            {
                //https://stackoverflow.com/questions/2829873/how-can-i-detect-if-this-dictionary-key-exists-in-c
                if (wordsHashMap.ContainsKey(words[i]))
                {
                    wordsHashMap[words[i]].Add(i + 1);
                }
                else
                {
                    wordsHashMap.Add(words[i], new List<int>());
                    wordsHashMap[words[i]].Add(i + 1);
                }
            }
        }

        public int Shortest(string word1, string word2)
        {
            IList<int> wordOneIndexes = wordsHashMap[word1];
            IList<int> wordTwoIndexes = wordsHashMap[word2];
            int minDistance = int.MaxValue;

            //kindof merge routine comparision in mergesort, increment the smaller number list index
            for (int i = 0, j = 0; i < wordOneIndexes.Count && j < wordTwoIndexes.Count;)
            {
                if (wordOneIndexes[i] < wordTwoIndexes[j])
                {
                    minDistance = Math.Min(minDistance, wordTwoIndexes[j] - wordOneIndexes[i]);
                    i++;//kindof merge routine comparision in mergesort, increment the smaller number list index
                }
                else
                {
                    minDistance = Math.Min(minDistance, wordOneIndexes[i] - wordTwoIndexes[j]);
                    j++;
                }

            }

            return minDistance;
        }
    }
}
