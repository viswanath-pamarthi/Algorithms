using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Valid Parentheses
/// https://leetcode.com/problems/valid-parentheses/description/
/// Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

///The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.
/// </summary>
namespace LeetCode
{
    class ValidParantheses
    {
        /// <summary>
        /// Time Complexity: O(n)
        /// Space Commplexity: O(n). Will store n/2 objects
        /// </summary>
        /// <param name="s">input strings</param>
        /// <returns>boolean, if string s is valid then true else false</returns>
        public bool IsValid(string s)
        {
            //check if the string is empty or length equal to one then it is invalid string input
            if (String.IsNullOrEmpty(s) || s.Length == 1)
            {
                return false;
            }

            Stack<char> openingBraces = new Stack<char>();// Store the opening bracket till a closing bracket is seen
            int currentIndex = 0;//keep track of the current index in the string
            int lengthOfInputString = s.Length;//Store the length of the string instead of calling the Length propery which internally calcualtes the string length each time invoked

            //Loop till you reach the end of the string
            while (currentIndex < lengthOfInputString)
            {
                //store the character on stack if the character is an opening bracket
                if (s[currentIndex] == '(' || s[currentIndex] == '{' || s[currentIndex] == '[')
                {
                    openingBraces.Push(s[currentIndex]);
                }
                else if (s[currentIndex] == ')' || s[currentIndex] == '}' || s[currentIndex] == ']')
                {
                    //if the character is a closed bracket then pop the stack to match retrieve the opening bracket
                    char openingBrace = openingBraces.Count > 0 ? openingBraces.Pop() : 'c';

                    //Not matching brackets then return false
                    if (!IsMatchingBracket(openingBrace, s[currentIndex]))
                    {
                        return false;
                    }
                }
                else//If there are characters other than the brackets
                    return false;

                currentIndex++;
            }

            //Check if there are any opening brackets present in stack after the validation loop is completeed
            if (openingBraces.Count > 0)
                return false;

            return true;
        }

        public bool IsMatchingBracket(char open, char close)
        {
            if ((open == '(' && close == ')') || (open == '{' && close == '}') || (open == '[' && close == ']'))
            {
                return true;
            }

            return false;
        }
    }
}
