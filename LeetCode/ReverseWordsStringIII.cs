using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.
///Example 1:
///Input: "Let's take LeetCode contest"
///Output: "s'teL ekat edoCteeL tsetnoc"
///Note: In the string, each word is separated by single space and there will not be any extra space in the string.
/// </summary>
namespace LeetCode
{
    class ReverseWordsStringIII
    {
        public string ReverseWords(string s)
        {
            if (s == null)
                return null;

            string[] strings = s.Split(' ');
            StringBuilder temp = new StringBuilder();

            foreach (string str in strings)
            {
                temp.Append(ReverseWord(str));
                temp.Append(" ");
            }

            return temp.ToString().Trim();
        }

        public string ReverseWord(string s)
        {
            StringBuilder temp = new StringBuilder();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                temp.Append(s[i]);
            }

            return temp.ToString(); ;
        }
    }
}
