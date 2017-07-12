using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/solve-the-equation/#/description
/// Solve a given equation and return the value of x in the form of string "x=#value". The equation contains only '+', '-' operation, the variable x and its coefficient.
///
///If there is no solution for the equation, return "No solution".
///
///If there are infinite solutions for the equation, return "Infinite solutions".
///
///If there is exactly one solution for the equation, we ensure that the value of x is an integer.
/// </summary>
namespace LeetCode
{
    class SolveTheEquation
    {
        /// <summary>
        /// Referred solutions:
        /// https://leetcode.com/problems/solve-the-equation/#/solutions
        /// </summary>
        /// <param name="equation"></param>
        /// <returns></returns>
        public string SolveEquation(string equation)
        {
            int[] leftEquation = new int[2] { 0,0};
            int[] rightEquation = new int[2] {0,0 };

            if (equation.Length < 3)
                return "No solution";
            

            parsePartOfEquation(leftEquation, equation.Split('=')[0]);

            parsePartOfEquation(rightEquation, equation.Split('=')[1]);

            if(leftEquation[0]==rightEquation[0])
            {
                if (leftEquation[1] == rightEquation[1])
                    return "Infinite solutions";
                else
                    return "no solution";
            }
          
                return "x=" + (rightEquation[1] - leftEquation[1]) / (leftEquation[0]-rightEquation[0]);
         
                        
        }

        private void parsePartOfEquation(int[] quotients,string equation)
        {
            IEnumerable<string> tokens= Regex.Split(equation, "(?=[-,+])").Select(a => a).Where(b => !string.IsNullOrEmpty(b));

            foreach(string token in tokens)
            {
                if (string.Compare(token, "-x") == 0)
                {
                    quotients[0] -= 1;
                }
                else if ((string.Compare(token, "+x") == 0)|| (string.Compare(token, "x") == 0))
                {
                    quotients[0] += 1;
                }
                else if (token.Contains("x"))
                {
                    quotients[0] += int.Parse(token.Substring(0, token.IndexOf("x")));
                }
                else
                {
                    quotients[1] += int.Parse(token);
                }
                    
            }
        }
    }
}
