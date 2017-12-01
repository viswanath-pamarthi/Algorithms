using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/shortest-word-distance-iii/description/
/// This is a follow up of Shortest Word Distance. The only difference is now word1 could be the same as word2.
///
///Given a list of words and two words word1 and word2, return the shortest distance between these two words in the list.
///
///word1 and word2 may be the same and they represent two individual words in the list.
///
///For example,
///Assume that words = ["practice", "makes", "perfect", "coding", "makes"].
///
///Given word1 = “makes”, word2 = “coding”, return 1.
///Given word1 = "makes", word2 = "makes", return 3.
///
///Note:
///You may assume word1 and word2 are both in the list.
/// </summary>
namespace LeetCode
{
    class ShortWordDistance3
    {
        /// <summary>
        /// TIme Complexity O(n) ?
        /// </summary>
        /// <param name="words"></param>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int ShortestWordDistance(string[] words, string word1, string word2)
        {
            Dictionary<string, IList<int>> wordsHashMap = new Dictionary<string, IList<int>>();

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


            IList<int> wordOneIndexes = wordsHashMap[word1];//Fetch the indexes of word1 from the Dictionary/HashMap
            IList<int> wordTwoIndexes = wordsHashMap[word2];//Fetch the indexes of word2 from the Dictionary/HashMap
            int minDistance = int.MaxValue;
            int indexFirstList = 0, indexSecondList = 0;

            //When both words are same then peform the comparision on one list with a window size of 2
            if (word1 == word2)
            {
                indexSecondList = 1;//using it on the same first list and using a window of size 2 and move the window till end. As atleast two words will be present in the list, we are sure of the second index being 1

                //only second index is enough, as it is the  first index that hits the end
                while (indexSecondList < wordOneIndexes.Count)
                {
                    minDistance = Math.Min(minDistance, wordOneIndexes[indexSecondList] - wordOneIndexes[indexFirstList]);
                    indexFirstList++;
                    indexSecondList++;
                }
            }
            else
            {
                while (indexFirstList < wordOneIndexes.Count && indexSecondList < wordTwoIndexes.Count)
                {
                    if (wordOneIndexes[indexFirstList] < wordTwoIndexes[indexSecondList])
                    {
                        minDistance = Math.Min(minDistance, wordTwoIndexes[indexSecondList] - wordOneIndexes[indexFirstList]);
                        indexFirstList++;//kindof merge routine comparision in mergesort, increment the smaller number list index
                    }
                    else
                    {
                        minDistance = Math.Min(minDistance, wordOneIndexes[indexFirstList] - wordTwoIndexes[indexSecondList]);
                        indexSecondList++;
                    }

                }
            }
            return minDistance;
        }
    }
}
