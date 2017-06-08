using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/add-binary/#/description
/// Given two binary strings, return their sum (also a binary string).
///
///For example,
///a = "11"
///b = "1"
///Return "100".
/// </summary>
namespace LeetCode
{
    class AddBinary
    {
        /// <summary>
        /// Adding two Binary numbers in string format
        /// </summary>
        /// <param name="a">First binary number string</param>
        /// <param name="b">Second binary number string</param>
        /// <returns>result of adding two binary numbers</returns>
        public string AddBinaryNumbers(string a, string b)
        {
            if (a.Length < b.Length)
            {
                return AddBinaryNumbers(b, a);
            }

            
            int carryOver = 0;
            int i = a.Length - 1;
            int j = b.Length - 1;
            char[] result = new char[a.Length];

            if (a.Length == 0)
                return b;

            if (b.Length == 0)
                return a;


            while (i >= 0 || j>=0 || (i >= 0&&carryOver ==1))
            {
                if (i >= 0)
                    result[i] = a[i];
                if (j >= 0)
                    result[i] = (char)(((result[i] - '0') + (b[j] - '0')) + '0');

                result[i]= (char)((result[i] - '0')  + (carryOver) + '0');
                carryOver = (result[i]-'0')/2;
                result[i] = (char)(((result[i]-'0') % 2)+'0');
                i--;
                j--;
              }


            string finalResult = new string(result);

            return (carryOver == 1 ? "1" + finalResult : finalResult);
        }
    }
}
