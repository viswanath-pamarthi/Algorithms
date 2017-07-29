using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/reverse-string/tabs/description
/// Write a function that takes a string as input and returns the string reversed.
///
///Example:
///Given s = "hello", return "olleh".
/// </summary>
namespace LeetCode
{
    class StringReverse
    {
        public string ReverseString(string s)
        {
            StringBuilder reverseOfString = new StringBuilder();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                reverseOfString.Append(s[i]);
            }

            return reverseOfString.ToString();
        }
    }
}
