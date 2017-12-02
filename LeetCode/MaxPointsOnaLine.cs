using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/max-points-on-a-line/description/
/// Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.
/// </summary>
namespace LeetCode
{    
    //Definition for a point.
    public class Point
     {
        public int x;
        public int y;
        public Point() { x = 0; y = 0; }
        public Point(int a, int b) { x = a; y = b; }
    }

    class MaxPointsOnaLine
    {
        /// <summary>
        /// Time complexity is O(n^2)
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MaxPoints(Point[] points)
        {
            //Referred the discussion section for idea for solution

            //edge cases - minimum of two poitns are required
            if (points.Length <= 2)
            {
                return points.Length; //if two points are present, it is not necessary that the they should be on the same line ??            
            }

            //loop through points, start with the index 0, find if the other points are on the same line as it. next start with index 1 and repeat the same

            //Store the the slope fraction numerator x and denomenator y - count. instead of storing the decimal value as key we are storing the numerator and denomenator after removing the GCD of them
            Dictionary<int, Dictionary<int, int>> slopesCount = new Dictionary<int, Dictionary<int, int>>();//so when the x values are same then we will prevent the zero/by issue if we store this way and also y2-y2 infinity situation is also avoided
            int result = int.MinValue;

            for (int i = 0; i < points.Length; i++)
            {
                int localmax = int.MinValue;//number of points on line max after every point comparision
                int overlappedPoints = 0;//To store the count of overlapped points, i.e. the duplicate points

                slopesCount.Clear();

                for (int j = i + 1; j < points.Length; j++)
                {
                    int numeratorOfSlope = points[j].y - points[i].y;
                    int denomenatorOfSlope = points[j].x - points[i].x;

                    if (numeratorOfSlope == 0 && denomenatorOfSlope == 0)
                    {
                        overlappedPoints++;
                        continue;
                    }

                    int gcd = FindGcd(numeratorOfSlope, denomenatorOfSlope);//As per math, gcd of two -ve numbers is positve, how eevr as per the current logic it will be negative

                    numeratorOfSlope /= gcd;
                    denomenatorOfSlope /= gcd;

                    //see if the numerator is present in the dictionary
                    if (slopesCount.ContainsKey(numeratorOfSlope))
                    {
                        if (slopesCount[numeratorOfSlope].ContainsKey(denomenatorOfSlope))
                        {
                            slopesCount[numeratorOfSlope][denomenatorOfSlope] += 1;
                        }
                        else
                        {
                            slopesCount[numeratorOfSlope].Add(denomenatorOfSlope, 1);
                        }
                    }
                    else
                    {
                        Dictionary<int, int> temp = new Dictionary<int, int>();
                        temp.Add(denomenatorOfSlope, 1);

                        slopesCount.Add(numeratorOfSlope, temp);
                    }

                    //update local max here        
                    localmax = Math.Max(slopesCount[numeratorOfSlope][denomenatorOfSlope], localmax);
                }

                localmax = localmax == int.MinValue ? 0 : localmax;//when all are overLappedpoints then for comparision have to make local max back to 0

                //update the overall max            
                result = Math.Max(localmax + overlappedPoints + 1, result);// one is when point A is compared with point B and Point C then count is updated in the Dictionary Two times for each comparision if their slopes are same, But the points are three, so the extra is added here as "1"
            }

            return result;

        }

        //A method to find the GCD of two numbers
        public int FindGcd(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0)
                return secondNumber;

            return FindGcd(secondNumber % firstNumber, firstNumber);
        }
    }
}
