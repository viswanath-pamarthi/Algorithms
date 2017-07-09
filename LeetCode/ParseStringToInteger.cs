using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class ParseStringToInteger
    {
        /// <summary>
        /// Method to parse a string to integer
        /// </summary>
        /// <param name="input">String format of integer</param>
        /// <returns>Interger form of the Input string</returns>
        public int ParseStringToInt(string input)
        {
            int result = 0;
            bool isNegative = input[0] == '-' ? true : false;

            if (isNegative)
                input = input.Substring(1, input.Length-1);

            foreach (char c in input)
            {
                //Multiply the number with 10 to get ready(Make way by adding a least significate position in the result) to add the next number to result
                // e.g. 12. First iteration result =0;result=1; , Second iteration result=10;result= 10+2=12
                result *= 10;

                //add the next digit value to result. Substract the ASCII value of zero from the ASCII value of the digit to get the exact integer value of character.
                //e.g. ASCII of '1' is 49, to get the value of integer 1 we substract '1'-'0' (49-48) = 1 
                result += c - '0';
            }

            return isNegative? (-1)* result:result;
        }
    }
}
