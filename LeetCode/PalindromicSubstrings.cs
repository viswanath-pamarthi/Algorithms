using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Given a string, your task is to count how many palindromic substrings in this string.
/// https://leetcode.com/problems/palindromic-substrings/description/
///
///The substrings with different start indexes or end indexes are counted as different substrings even they consist of same characters.
///
///Example 1:
///Input: "abc"
///Output: 3
///Explanation: Three palindromic strings: "a", "b", "c".
///Example 2:
///Input: "aaa"
///Output: 6
///Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".
///Note:
///The input string length won't exceed 1000.
///
/// </summary>
namespace LeetCode
{
    class PalindromicSubstrings
    {
        public int CountSubstrings(string s)
        {
            int countPalindromes = 0;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 1; j <= s.Length - i; j++)
                {
                    //a function to check if substring is palindrome or not
                    if (IsPalindrome(s.Substring(i, j)))
                    {
                        countPalindromes++;
                    }
                }
            }

            return countPalindromes;
        }

        public bool IsPalindrome(string str)
        {
            if (str.Length == 1)
            {
                return true;
            }

            int start = 0;
            int end = str.Length - 1;

            //Condition works for even and odd strings also
            while (start < end)
            {
                //Even atleast one character doesn't match then not a palindrom
                if (str[start] != str[end])
                {
                    return false;
                }

                start++;
                end--;
            }

            return true;
        }

    }
}
