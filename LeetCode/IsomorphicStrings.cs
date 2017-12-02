using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/isomorphic-strings/description/
/// Given two strings s and t, determine if they are isomorphic.
///
///Two strings are isomorphic if the characters in s can be replaced to get t.
///
///All occurrences of a character must be replaced with another character while preserving the order of characters.No two characters may map to the same character but a character may map to itself.
///
///For example,
///Given "egg", "add", return true.
///
///
///Given "foo", "bar", return false.
///
///
///Given "paper", "title", return true.
///
///
///Note:
///You may assume both s and t have the same length.
/// </summary>
namespace LeetCode
{
    class IsomorphicStrings
    {
        /// <summary>
        /// Time complexity is O(n) as we are iterating through the list only once
        /// </summary>
        /// <param name="stringOne"></param>
        /// <param name="stringTwo"></param>
        /// <returns></returns>
        public bool IsIsomorphic(string stringOne, string stringTwo)
        {
            //Referred the discussion section to get the idea of what the question is talking about.

            //the string should be non empty and 
            //string.IsNullOrEmpty(stringOne) || string.IsNullOrEmpty(stringTwo)

            //Edge cases -  lengths should be equal
            if ((stringOne.Length != stringTwo.Length))
                return false;

            //Fetch each character in string one and map it to that particular character in a Dictionary/HashTable
            //if not present add both Dictionary or make sure the character of second string is not mapped to another character before adding

            Dictionary<char, char> characterMap = new Dictionary<char, char>();
            int indexStringOne = 0;
            int indexStringTwo = 0;

            while (indexStringOne < stringOne.Length && indexStringTwo < stringTwo.Length)
            {
                char charInStringOne = stringOne[indexStringOne];
                char charInStringTwo = stringTwo[indexStringTwo];

                //Check if the charInStringOne is already in the first string, if yes then inside check if the mapped character is charInStringTwo
                if (characterMap.ContainsKey(charInStringOne))
                {
                    if (!characterMap[charInStringOne].Equals(charInStringTwo))
                    {
                        return false;
                    }
                }
                else
                {
                    //the possibility is that the pair is not yet added to the dictionary. Before adding the pair, make sure that the char of second string is not mapped to any other character in first string
                    if (characterMap.ContainsValue(charInStringTwo))
                    {
                        return false;
                    }
                    else
                    {
                        characterMap.Add(charInStringOne, charInStringTwo);
                    }
                }


                indexStringOne++;
                indexStringTwo++;
            }


            return true;
        }
    }
}
