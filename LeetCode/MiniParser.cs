using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/mini-parser/#/description
/// Given a nested list of integers represented as a string, implement a parser to deserialize it.
///
///Each element is either an integer, or a list -- whose elements may also be integers or other lists.
///
///Note: You may assume that the string is well-formed:
///
///String is non-empty.
///String does not contain white spaces.
///String contains only digits 0-9, [, - ,,].
///Example 1:
///
///Given s = "324",
///
///You should return a NestedInteger object which contains a single integer 324.
///Example 2:
///
///Given s = "[123,[456,[789]]]",
///
///Return a NestedInteger object containing a nested list with 2 elements:
///
///1. An integer containing value 123.
///2. A nested list containing two elements:
///    i.An integer containing value 456.
///    ii.A nested list with one element:
///         a.An integer containing value 789.
/// </summary>
/// 
/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // Constructor initializes an empty nested list.
 *     public NestedInteger();
 *
 *     // Constructor initializes a single integer.
 *     public NestedInteger(int value);
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     public void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     public void Add(NestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
namespace LeetCode
{
    class MiniParser
    {

        public NestedInteger Deserialize(string s)
        {
            NestedInteger list = new NestedInteger();
            ParseList(0, s, list);

            if (s.Length == 2)
                return null;

            if (list.GetList().Count == 1)
            {
                return new NestedInteger(list.GetList()[0].GetInteger());
            }
            else if (list.GetList().Count == 0)
            {
                return null;
            }
            return list;
        }

        public int ParseList(int i, string s, NestedInteger list)
        {
            int j = 0;

            for (j = i; j < s.Length; j++)
            {

                if (s[j] == ',')
                {
                    continue;
                }
                else if (s[j] == ']')
                {
                    return j++;
                }
                else if (s[i] == '[')
                {
                    NestedInteger temp1 = new NestedInteger();
                    j = ParseList(j++, s, temp1);

                    if (temp1.GetList().Count > 0)
                        list.Add(temp1);
                }
                else
                {
                    j = ParseNumber(j, s, list);
                }
            }

            return j;

        }

        public int ParseNumber(int i, string s, NestedInteger list)
        {
            int result = 0;
            bool isNegative = s[i] == '-' ? true : false;

            if (isNegative)
                i++;

            int j = 0;

            for (j = i; j < s.Length; j++)
            {
                if (s[j] == ',')
                {
                    j++;
                    break;
                }
                else if (s[j] == ']')
                    break;
                //Multiply the number with 10 to get ready(Make way by adding a least significate position in the result) to add the next number to result
                // e.g. 12. First iteration result =0;result=1; , Second iteration result=10;result= 10+2=12
                result *= 10;

                //add the next digit value to result. Substract the ASCII value of zero from the ASCII value of the digit to get the exact integer value of character.
                //e.g. ASCII of '1' is 49, to get the value of integer 1 we substract '1'-'0' (49-48) = 1 
                result += s[j] - '0';
            }
            NestedInteger num = new NestedInteger(isNegative ? (-1) * result : result);

            list.Add(num);
            return j;
        }
    }
