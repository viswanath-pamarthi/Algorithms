using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.
///https://leetcode.com/problems/add-strings/#/description
///Note:
///
///The length of both num1 and num2 is < 5100.
///Both num1 and num2 contains only digits 0-9.
///Both num1 and num2 does not contain any leading zero.
///You must not use any built-in BigInteger library or convert the inputs to integer directly.
/// </summary>
namespace LeetCode
{
    /// <summary>
    /// ********Reverse a string various ways************
    /// http://www.c-sharpcorner.com/UploadFile/19b1bd/reverse-a-string-in-different-ways-using-C-Sharp/
    /// </summary>
    class AddStrings
    {
        /// <summary>
        /// Adding two numbers in string format.
        /// 
        /// Referred some idea from(C++ solution) https://leetcode.com/problems/add-strings/#/solutions
        /// </summary>
        /// <param name="num1">First Number</param>
        /// <param name="num2">Second Number</param>
        /// <returns>sum of the two number</returns>
        public string AddTwoStrings(string num1, string num2)
        {
            //This piece of codes makes things easier as you always know that the first string is bigger(useful for reducing validations)
            if (num1.Length < num2.Length)
                return AddTwoStrings(num2, num1);

            int i = num1.Length - 1;
            int j = num2.Length-1;
            int carryOver = 0;
            char[] result=new char[num1.Length] ;

            //Loop through the strings and add
            while(i>=0 || j>=0)
            {
                int sum = 0;
                sum += carryOver;
                carryOver = 0;

                if (i >= 0)
                {
                    // This has to be done to get the actual number. '0' - ASCII value is "48" , '1' - ASCII value is 49
                    //so '1' while adding will be as 49+..., so 49-48 ('0') gives 1 - This is done while doing the math, '0' ASCII value again added while storing the result back to char array
                    sum += num1[i] - '0';
                                            
                }
                
                if (j >= 0)
                {
                    sum += num2[j] - '0';
                }

                //get the carryover if number is grreater than 10... always 1, as a max of 9 + 9 =18
                if (sum>=10)
                {
                    
                    carryOver = sum / 10;
                }

                result[i] = (char)((sum % 10)+'0');//Add the ASCII value back while storing

                i--;
                j--;
            }

            //If the first string is bigger then add the carryover to the next (<- direction) number
            //This case is only when the numbers are inequal and carryover is present, when numbers are equal then it is done while returning the result
            if ((i > 0) && (carryOver == 1))
            { 
                result[i] =(char) (result[i] + 1 - '0');
                carryOver = 0;
            }
            string finalResult = new string(result);

            //Concatinate the carryover, if string are
            return carryOver==1? string.Concat("1", finalResult) : finalResult;

        }
    }
}
