using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
