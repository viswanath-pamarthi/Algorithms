using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/reverse-string-ii/description/
/// Given a string and an integer k, you need to reverse the first k characters for every 2k characters counting from the start of the string. If there are less than k characters left, reverse all of them. If there are less than 2k but greater than or equal to k characters, then reverse the first k characters and left the other as original.
///Example:
///Input: s = "abcdefg", k = 2
///Output: "bacdfeg"
///Restrictions:
///The string consists of lower English letters only.
///Length of the given string and k will in the range[1, 10000]
/// </summary>
namespace LeetCode
{
    class ReverseStringII
    {
        public string ReverseStr(string s, int k)
        {
            char[] temp = s.ToCharArray();
            int remainingLength = s.Length;

            if (k == 1)
                return s;

            for (int i = 0; (i < s.Length); i += 2 * k)
            {
                int start = i;
                int end = i + k - 1 <= s.Length - 1 ? i + k - 1 : s.Length - 1;//Check if the end length exceeds the length of string then make it to the length of the string

                while (start < end)
                {
                    char tempChar = temp[start];
                    temp[start] = temp[end];
                    temp[end] = tempChar;

                    start++;
                    end--;
                }

                remainingLength -= 2 * k;
            }

            return new string(temp);
        }
    }
}
