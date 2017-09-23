using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/valid-anagram/description/
/// Given two strings s and t, write a function to determine if t is an anagram(a word, phrase, or name formed by rearranging the letters of another, such as cinema, formed from iceman.) of s.
///
///For example,
///s = "anagram", t = "nagaram", return true.
///s = "rat", t = "car", return false.
///
///Note:
///You may assume the string contains only lowercase alphabets.
///
///Follow up:
///What if the inputs contain unicode characters? How would you adapt your solution to such case?
///
///
/// </summary>
namespace LeetCode
{
    class ValidAnagram
    {
        public bool IsAnagram(string s, string t)
        {
            Dictionary<char, int> letterDictionary = new Dictionary<char, int>();

            //Evaluate first string
            foreach (char c in s)
            {
                if (letterDictionary.ContainsKey(c))
                {
                    letterDictionary[c] += 1;
                }
                else
                    letterDictionary.Add(c, 1);
            }

            //Validate Second string
            foreach (char c in t)
            {
                //Use the same dictionary to decrease the counts of characters
                if (letterDictionary.ContainsKey(c))
                {
                    letterDictionary[c] -= 1;
                }
                else
                {
                    return false;
                }
            }

            foreach (int value in letterDictionary.Values)
            {
                //If count of character is not zero not valid Anagrams
                if (value != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
