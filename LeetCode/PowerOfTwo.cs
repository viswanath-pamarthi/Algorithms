using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class PowerOfTwo
    {
        /// <summary>
        /// if an logical 'or' operation between a number and the leftShift of 1( powers of 2) is same as the leftShift then ,
        /// it is a power of two, at the same time number should be divisible by 2 and if number is one then true
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo(int n)
        {
            int sizeOfInteger = 8 * sizeof(int);//8bits * 4 bits .. 32bit or 8 * 2bytes

            for (int i = 0; i < sizeOfInteger; i++)
            {
                int leftShift = 1 << i;
                if (((leftShift | n) == leftShift) && ((n % 2 == 0) || (n == 1)) && (n != 0) && n > 0)
                {
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// copied from https://leetcode.com/submissions/detail/102661755/
        /// Interesting solution. always doing and operation using 000000000...1 i.e. 1. 
        /// 
        /// if a number is power of two then the binary of the number wil have only one one... 001, 010, 100, 1000, 1000.... (2power0, 2power1, 2power2, 2power3, 2power4....). 
        /// So one will be in only one bit .
        /// 
        /// for this solution the you should only get true once else false is return if more than once true condition is met.
        /// e.g. 9. binary is 1001 and operation with 1 wil return true and again after all right shift operation are done 0001 will will match 1. so false is returned
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo1(int n)
        {
            bool hasOne = false;
            while (n != 0)
            {
                if ((n & 1) == 1)
                {
                    if (hasOne)
                    {
                        return false;
                    }
                    else
                    {
                        hasOne = true;
                    }
                }
                n >>= 1;
            }
            return hasOne;
        }

        /// <summary>
        /// copied from https://leetcode.com/submissions/detail/102661755/
        /// Intersting solution!
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo2(int n)
        {
            if (n <= 0)
            {
                return false;
            }
            return (n & (n - 1)) == 0;
        }
    }
}
