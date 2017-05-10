using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * https://leetcode.com/problems/hamming-distance/#/description
 * The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

Given two integers x and y, calculate the Hamming distance.

Note:
0 ≤ x, y < 231.

Example:

Input: x = 1, y = 4

Output: 2

Explanation:
1   (0 0 0 1)
4   (0 1 0 0)
       ↑   ↑

The above arrows point to positions where the corresponding bits are different.
 * */
namespace LeetCode
{
    class HammingDistance
    {
        int numberOne;
        int numberTwo;
        int hammingDistance = 0;// Variable to hold the hamming Distance

        public HammingDistance(int number1,int number2)
        {
            numberOne = number1;
            numberTwo = number2;
        }

        /// <summary>
        /// Bruteforce solution
        /// </summary>
        public void solutionOne()
        {           
            int tempNumberOne;//Temporary variable to hold the quotient of the numberOne
            int tempNumberTwo;//Temporary variable to hold the quotient of the numberTwo

            tempNumberOne = numberOne;
            tempNumberTwo = numberTwo;

            int quotientOne;// Variable to hold the quotient of the number One
            int quotientTwo;// Variable to hold the quotient of the number Two

            

            // Validate the limits of the two numbers
            if (tempNumberOne >= 0 && tempNumberOne < Math.Pow(2, 31))
            {
                while (tempNumberOne >= 1 || tempNumberTwo >= 1)
                {
                    quotientOne = tempNumberOne / 2;
                    quotientTwo = tempNumberTwo / 2;

                    if ((tempNumberOne % 2) != (tempNumberTwo % 2))
                    {
                        hammingDistance++;
                    }

                    tempNumberOne = quotientOne;
                    tempNumberTwo = quotientTwo;
                }
            }

            Console.WriteLine("{0} is the Hamming Distance between {1} and {2}", hammingDistance, numberOne, numberTwo);
        }

        /// <summary>
        /// Used the XOR operator available in C# and counted the number of remainders which are 1
        /// 0101 - num 1
        /// 1001- num 2
        /// 1100 - is xor
        /// </summary>
        public void solutionTwo()
        {
            int xor = numberOne ^ numberTwo;
            int quotient;
            
            while(xor>=1)
            {
                quotient = xor / 2;

                if ((xor%2)==1)
                {
                    hammingDistance++;
                }

                xor = quotient;
            }

            Console.WriteLine("{0} is hamming distance using xor", hammingDistance);
        }
    }
}
