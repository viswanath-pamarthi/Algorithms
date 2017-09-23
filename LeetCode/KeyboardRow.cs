using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/keyboard-row/description/
/// Given a List of words, return the words that can be typed using letters of alphabet on only one row's of American keyboard like the image below.
///
///
///American keyboard
///
///
///Example 1:
///Input: ["Hello", "Alaska", "Dad", "Peace"]
///Output: ["Alaska", "Dad"]
///Note:
///You may use one character in the keyboard more than once.
///You may assume the input string will only contain letters of alphabet.
///
/// </summary>
namespace LeetCode
{
    class KeyboardRow
    {
        public string[] FindWords(string[] words)
        {
            string[] keyboardRows = { "qwertyuiop", "asdfghjkl", "zxcvbnm" };

            List<string> results = new List<string>();


            foreach (string word in words)
            {
                //Check for all three rows, if atleast one match check all leters of word belong to that word and break
                for (int i = 0; i < 3; i++)
                {
                    if (keyboardRows[i].Contains(char.ToLower(word[0])))
                    {
                        bool isValid = true;

                        foreach (char c in word)
                        {
                            if (!keyboardRows[i].Contains(char.ToLower(c)))
                            {
                                isValid = false;
                                break;
                            }
                        }

                        if (isValid)
                            results.Add(word);

                        break;
                    }
                }




            }

            return results.ToArray();
        }
    }
}
