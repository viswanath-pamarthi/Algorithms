using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class HammingWeight
    {
        public int HammingWeightSolution(uint n)
        {
            int hammingWeight = 0;
            uint tempNumber = n;
            uint quotient;

            while (tempNumber >= 1)
            {
                quotient = tempNumber / 2;
                if (tempNumber % 2 == 1)
                {
                    hammingWeight++;
                }

                tempNumber = quotient;
            }

            return hammingWeight;
        }

        /// <summary>
        /// https://leetcode.com/articles/number-1-bits/
        /// Copied from https://leetcode.com/submissions/detail/102559960/
        /// liked the solution
        /// 
        /// for every bit will check if set or not
        /// 1<<4 is 2 power 4
        /// 1<<6 is 2 power 6( 2^6)
        /// 
        /// every bit is verified
        /// 
        /// if n is 27  and i in loop is 8 then 
        /// 
        /// 8 & 27 !=0 is true ..i.e that bit is set to 1
        /// actual number written in binary:
        /// 2^32 2^31 2^30............... 2^8 2^7 2^6 2^5 2^4 2^3 2^2 2^1 2^0
        /// 
        /// so the 4th bit from the right for the number is checked if it is set or not by doing an &operation between 2^(4-1) and number 27
        /// 27  - 11011
        /// 2^3 -  1000  .. 8
        /// &   -  1000 .. that is 8 .. means that the 4 th bit from right is set to 1
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeightSolution2(uint n)
        {
            int count = 0;

            int size = sizeof(int) * 8;

            for (int i = 0; i < size; i++)
            {
                if (((1 << i) & n) != 0)
                    count++;
            }
            return count;
        }
    }
}
