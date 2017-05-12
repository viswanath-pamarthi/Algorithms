using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class LetterCombPhone
    {
        /// <summary>
        /// https://leetcode.com/problems/letter-combinations-of-a-phone-number/#/description
        /// 
        /// possible Letter combinations for phone numbers
        /// Given a digit string, return all possible letter combinations that the number could represent.
        ///A mapping of digit to letters(just like on the telephone buttons) is given below.(refer "200px-Telephone-keypad2.svg" picture)
        ///Input:Digit string "23"
        ///Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            IList<string > numbers= new List<string> { "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };// Values for the numbers
            IList<string> result=new List<string>();//Store the result
            
            int numberOfDigits = digits.Length;//find the length of the string, find out the number of digits in the number
            int i = 0;

            if( string.IsNullOrEmpty(digits))
            {
                return result;
            }

            if(numberOfDigits==1)
            {

                for (int k = 0; k < numbers[int.Parse(digits[0].ToString()) - 1].Length; k++)
                {
                    result.Add(string.Format("{0}", numbers[int.Parse(digits[0].ToString()) - 1][k]));
                }
            }

            while (i<numberOfDigits && numberOfDigits>1)
            {
                if (result.Count>0)
                {
                    int elementsCountList = result.Count;
                    IList<string> temp = new List<string>();

                    temp = result.ToList();
                    result.Clear();

                    for (int j=0;j<elementsCountList; j++)
                    {
                        for(int k=0;k< numbers[int.Parse(digits[i].ToString())-1].Length;k++)
                        {
                            result.Add(string.Format("{0}{1}", temp[j], numbers[int.Parse(digits[i].ToString())-1][k]));
                        }
                    }
                    i = i + 1;

                }
                else//Set up the initial list using the forst two 
                {
                    for(int j=0;j< numbers[int.Parse(digits[0].ToString())-1].Length;j++)
                    {
                        for(int k=0;k< numbers[int.Parse(digits[1].ToString())-1].Length;k++)
                        {
                            result.Add(string.Format("{0}{1}", numbers[int.Parse(digits[0].ToString())-1][j], numbers[int.Parse(digits[1].ToString())-1][k]));
                        }
                    }
                    i = i + 2;
                }

              
            }
            

            return result;
        }
    }
}
