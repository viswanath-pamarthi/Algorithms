using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/plus-one/#/description
/// Given a non-negative integer represented as a non-empty array of digits, plus one to the integer.
///
///You may assume the integer do not contain any leading zero, except the number 0 itself.
///
///The digits are stored such that the most significant digit is at the head of the list.
/// </summary>
namespace LeetCode
{
    class PlusOne
    {
        public int[] PlusOneToArrayInts(int[] digits)
        {

            int carryOver = 1;
            int[] result;
            int i = digits.Length - 1;

            while ((carryOver > 0) && (i >= 0))
            {
                digits[i] = digits[i] + carryOver;
                carryOver = 0;
                carryOver = digits[i] / 10;
                digits[i] = digits[i] % 10;
                
                i--;
            }

            if(carryOver>0)
            {
                result = new int[digits.Length + 1];
                result[0] = carryOver;

                // got this from an existing solution - my original was to copy the array (which was unnecessary)
                /*for(int j=0;j< digits.Length;j++)
                {
                    result[j + 1] = digits[j];
                }*/

                digits = result;
            }
            
            return digits;

        }
    }
}
