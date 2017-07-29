using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// https://leetcode.com/problems/longest-palindrome
/// Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters.
///
///This is case sensitive, for example "Aa" is not considered a palindrome here.
///
///Note:
///Assume the length of given string will not exceed 1,010.
///
///Example:
///
///Input:
///"abccccdd"
///
///Output:
///7
///
///Explanation:
///One longest palindrome that can be built is "dccaccd", whose length is 7.
/// </summary>
namespace LeetCode
{
    class LongestPalindrome
    {
        /// <summary>
        /// Utilized the hint of using the Dictionary from discussion section
        /// </summary>
        /// <param name="s">input string</param>
        /// <returns></returns>
        public int LongestPalindromeSolution(string s)
        {
            Dictionary<char, int> characterCount = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (characterCount.ContainsKey(s[i]))
                {
                    characterCount[s[i]]++;//Count the occurence of the each characters
                }
                else
                {
                    characterCount.Add(s[i], 1);
                }
            }

            bool isOddPresent = false;
            int evenLengthCharacters = 0;
            foreach (var item in characterCount)
            {
                if ((item.Value % 2) == 0)
                    evenLengthCharacters += item.Value;// Odd count characters will add up to be part of the palindrome
                else
                {
                    isOddPresent = true;
                    evenLengthCharacters += item.Value - 1;//Odd count characters can only on can exist. others can utilize the even part of it.
                }
            }

            return (evenLengthCharacters + (isOddPresent ? 1 : 0));
        }
    }
}
