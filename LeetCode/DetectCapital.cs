using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/detect-capital/description/
/// G a word, you need to judge whether the usage of capitals in it is right or not.
///
///We define the usage of capitals in a word to be right when one of the following cases holds:
///
///All letters in this word are capitals, like "USA".
///All letters in this word are not capitals, like "leetcode".
///Only the first letter in this word is capital if it has more than one letter, like "Google".
///Otherwise, we define that this word doesn't use capitals in a right way
///
/// Example 1:
///Input: "USA"
///Output: True
///Example 2:
///Input: "FlaG"
///Output: False
///Note: The input will be a non-empty word consisting of uppercase and lowercase latin letters./// 
/// 
/// 
/// </summary>
namespace LeetCode
{
    class DetectCapital
    {
        public bool DetectCapitalUse(string word)
        {
            //referred solutions
            int count = 0;//track the capital letters count

            foreach (char c in word.ToCharArray())
            {
                if ('Z' - c >= 0)
                    count++;
            }


            return ((count == 0) || (count == word.Length) || ((count == 1) && ('Z' - word[0] >= 0)));
        }
    }
}

