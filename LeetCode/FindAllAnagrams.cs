using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/find-all-anagrams-in-a-string/description/
/// Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.
///
///Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.
///
///The order of output does not matter.
///
///Example 1:
///
///Input:
///s: "cbaebabacd" p: "abc"
///
///Output:
///[0, 6]
///
///Explanation:
///The substring with start index = 0 is "cba", which is an anagram of "abc".
///The substring with start index = 6 is "bac", which is an anagram of "abc".
///Example 2:
///
///Input:
///s: "abab" p: "ab"
///
///Output:
///[0, 1, 2]
///
///Explanation:
///The substring with start index = 0 is "ab", which is an anagram of "ab".
///The substring with start index = 1 is "ba", which is an anagram of "ab".
///The substring with start index = 2 is "ab", which is an anagram of "ab".
/// </summary>
namespace LeetCode
{
    class FindAllAnagrams
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();

            Dictionary<char, int> letterDictionary = new Dictionary<char, int>();

            //Get the count of characters in string p
            foreach (char c in p)
            {
                if (letterDictionary.ContainsKey(c))
                {
                    letterDictionary[c] += 1;
                }
                else
                    letterDictionary.Add(c, 1);
            }

            for (int i = 0; i <= s.Length - p.Length; i++)
            {
                if (IsAnagram(letterDictionary, s.Substring(i, p.Length)))
                {
                    result.Add(i);
                }
            }

            return result;
        }


        public bool IsAnagram(Dictionary<char, int> letterDictionary, string t)
        {
            Dictionary<char, int> letterDictionary2 = new Dictionary<char, int>();
           
            //Validate Second string
            foreach (char c in t)
            {
                //Use the same dictionary to decrease the counts of characters
                if (letterDictionary2.ContainsKey(c))
                {
                    letterDictionary2[c] += 1;
                }
                else
                {
                    letterDictionary2.Add(c, 1);
                }
            }

            foreach (var pair in letterDictionary)
            {
                int value;

                if (letterDictionary2.TryGetValue(pair.Key, out value))
                {
                    if (value != pair.Value)
                    {
                        return false;
                    }
                }
                else
                    return false;
            }


            return true;
        }
    }
}
