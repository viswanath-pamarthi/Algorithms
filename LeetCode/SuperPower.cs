using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/super-pow/description/
/// Your task is to calculate ab mod 1337 where a is a positive integer and b is an extremely large positive integer given in the form of an array.
///
///Example1:
///
///a = 2
///b = [3]
///
///Result: 8
///Example2:
///
///a = 2
///b = [1,0]
///
///Result: 1024
///Credits:
///Special thanks to @Stomach_ache for adding this problem and creating all test cases.
////// </summary>
namespace LeetCode
{
    class SuperPower
    {
        /// <summary>
        /// Recursion
        /// 
        /// Time complexity is O(sqrt(n)) ?
        /// </summary>
        /// <param name="number"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public int SuperPow(int number, int[] power)
        {

            if (power.Length == 0)
                return 0;

            if (number == 1)
                return 1;

            string stringPower = string.Join("", power);
            int actualPower;
            int.TryParse(stringPower, out actualPower);

            return CalculatePower(number, actualPower);
        }

        public int CalculatePower(int number, int power)
        {
            if (power == 0)
                return 1;

            //Can calculate the half power value and can multiply it to self to get the actual result. power/2 Reduces the time to run for this problem
            int partialResult = CalculatePower(number, power / 2);

            if (power % 2 == 0)
                return partialResult * partialResult % 1337;
            else
                return power < 0 ? (partialResult * partialResult * (1 / number) % 1337) : (partialResult * partialResult * number % 1337);//only for the n=1 and n=odd then the n=5 then n=1 and n=5 stages only uses this


        }
    }
}
