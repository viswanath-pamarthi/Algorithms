using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/// <summary>
/// https://leetcode.com/problems/fraction-addition-and-subtraction/#/description
/// Given a string representing an expression of fraction addition and subtraction, you need to return the calculation result in string format. The final result should be irreducible fraction. If your final result is an integer, say 2, you need to change it to the format of fraction that has denominator 1. So in this case, 2 should be converted to 2/1.
///
///Example 1:
///Input:"-1/2+1/2"
///Output: "0/1"
///Example 2:
///Input:"-1/2+1/2+1/3"
///Output: "1/3"
///Example 3:
///Input:"1/3-1/2"
///Output: "-1/6"
///Example 4:
///Input:"5/3+1/3"
///Output: "2/1"
///Note:
///The input string only contains '0' to '9', '/', '+' and '-'. So does the output.
///Each fraction (input and output) has format ±numerator/denominator.If the first input fraction or the output is positive, then '+' will be omitted.
///The input only contains valid irreducible fractions, where the numerator and denominator of each fraction will always be in the range[1, 10]. If the denominator is 1, it means this fraction is actually an integer in a fraction format defined above.
///The number of given fractions will be in the range [1,10].
///The numerator and denominator of the final result are guaranteed to be valid and in the range of 32-bit int.
/// </summary>
namespace LeetCode
{
    class FractionAddition
    {
        /// <summary>
        /// Refernces
        ///  //Referred from solutions
        ///https://discuss.leetcode.com/topic/89991/concise-java-solution/2
        ///https://stackoverflow.com/questions/2484919/how-do-i-split-a-string-by-strings-and-include-the-delimiters-using-net
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public string FractionAdditionString(string expression)
        {
           
            IEnumerable<string> fractions = Regex.Split(expression,"(?=[-,+])").Select(a=>a).Where(b=> !string.IsNullOrEmpty(b));

            string result = "0/1";

            foreach(string fraction in fractions)
            {
                result = AddFractions(result,fraction);
            }

            return result;
        }

        /// <summary>
        /// Add the individual fractions
        /// </summary>
        /// <param name="num1">First fraction</param>
        /// <param name="num2">Second fraction</param>
        /// <returns></returns>
        private string AddFractions(string num1, string num2)
        {
            List<int> firstNumber = num1.Split(new char[] { '/' }).Select(a=> a == null?0: int.Parse(a)).ToList();
            List<int> secondNumber = num2.Split(new char[] { '/' }).Select(a => a == null ? 0 : int.Parse(a)).ToList();

            int numerator;
            int denominator;
            string sign = "";

            numerator = firstNumber[0] * secondNumber[1] + secondNumber[0] * firstNumber[1];
            denominator = firstNumber[1] * secondNumber[1];

            if (numerator < 0)
            {
                sign = "-";
                numerator = numerator * -1;
            }

            int GCD = Gcd(numerator, denominator);
        
            return sign+(numerator/GCD)+"/"+(denominator/GCD);
        }

        private int Gcd(int x,int y)
        {
            return (x == 0 || y == 0 ? x + y : Gcd(y,x%y));            
        }
    }
}
