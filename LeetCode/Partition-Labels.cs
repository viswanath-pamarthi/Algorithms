using System;
using System.Collections.Generic;
/// <summary>
/// https://leetcode.com/problems/partition-labels/
/// You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
///
///Note that the partition is done so that after concatenating all the parts in order, the resultant string should be s.
///
///Return a list of integers representing the size of these parts.
///
/// 
///
///Example 1:
///
///Input: s = "ababcbacadefegdehijhklij"
///Output:[9,7,8]
///Explanation:
///The partition is "ababcbaca", "defegde", "hijhklij".
///This is a partition so that each letter appears in at most one part.
///A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
///Example 2:
///
///Input: s = "eccbbbbdec"
///Output:[10]
/// 
///
///Constraints:
///
///1 <= s.length <= 500
///s consists of lowercase English letters.
/// </summary>
namespace LeetCode
{
    public class Partition_Labels
    {
        /// <summary>
        /// O(N) time complexity,  where N is the length of string.
        /// Space Complexity: O(1) to keep data structure last of not more than 26 characters.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<int> PartitionLabels(string s)
        {
            int lastSubEndIndex = -1;
            int prevEndindex = -1;
            var result = new List<int>();

            //Find the last occurance of each character and store in a dictionary
            Dictionary<char, int> lastIndexes = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (lastIndexes.ContainsKey(s[i]))
                {
                    lastIndexes[s[i]] = i;
                }
                else
                {
                    lastIndexes.Add(s[i], i);
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                int lastIndex = lastIndexes[s[i]];
                
                if (lastIndex > lastSubEndIndex)
                {
                    lastSubEndIndex = lastIndex;
                }

                if (i == lastSubEndIndex)
                {

                    if (prevEndindex == -1)
                    {
                        var length = i + 1;
                        result.Add(length);
                    }
                    else
                    {
                        var length = lastIndex - prevEndindex;
                        result.Add(length);
                    }

                    prevEndindex = lastSubEndIndex;
                }
            }

            return result;
        }
    }
}
