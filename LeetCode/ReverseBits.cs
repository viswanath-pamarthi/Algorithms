using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*The left-shift operator (<<) shifts its first operand left by the number of bits specified by its second operand. 
 * The type of the second operand must be an int or a type that has a predefined implicit numeric conversion to int.
 * 32 bits... 31 30 29 28 27 ...... 3 2 1 0
 * e.g. 1<<2 shists 1 in 00000000000000000000000000000000...(32 bit) to 00000000000000000000000000000100 i.e 3rd bit towards left direction from right. decimal value is 2 power 2 =4
 * 1<<3  shifts 1 to (3+1)bit towards left from right.   0000.....1000 .... its decimal value is 2 power 3 = 8
 * 
 * 
 * */
namespace LeetCode
{
    class ReverseBits
    {
        public uint reverseBits(uint n)
        {
            uint reversedNumber = 0;

            for (int i = 0; i < 32/2; i++)
            {
                int j = 31 - i;//exact other end bit.. e.g. 0th bit and 31st bit are exact mirror copies when reversed
                uint iLeftShift = (uint)(1 << i);
                uint jLeftShift = (uint)(1 << j);

                /* if ((iLeftShift & n) != 0) //ith bit is set to 1, multiply this bit with 2 power j(mirror bit)
                 {
                     reversedNumber += jLeftShift;
                 }

                 if ((jLeftShift & n) != 0)
                 {
                     reversedNumber += iLeftShift;
                 }*/

                reversedNumber = (uint)(reversedNumber + jLeftShift * ((iLeftShift & n) != 0 ? 1 : 0) + iLeftShift * ((jLeftShift & n) != 0 ? 1 : 0));

            }

            return reversedNumber;
        }
    }
}
