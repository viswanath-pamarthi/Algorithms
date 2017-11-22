using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/sqrtx/discuss/
/// Implement int sqrt(int x).
///
/// Compute and return the square root of x.
///
///x is guaranteed to be a non-negative integer.
/// </summary>
namespace LeetCode
{
    class SquareRoot
    {
        public int MySqrt(int inputNumber)
        {
            int lowerLimit = 1;
            int upperLimit = inputNumber;
            int midPoint;
            int squareRoot = 0;

            //Referred from solutions section, using the Binary search approach
            //Time complexity is O(log n)
            while (lowerLimit <= upperLimit)
            {

                //Calculate the midpoint of the range
                midPoint = (lowerLimit + upperLimit) / 2;
                //midPoint * midPoint will overflow when midPoint > sqrt(INT_MAX) , so , doing the division
                if ((inputNumber / midPoint) >= midPoint)
                {
                    lowerLimit = midPoint + 1;
                    squareRoot = midPoint;
                }
                else
                    upperLimit = midPoint - 1;
            }

            return squareRoot;
        }
    }
}
