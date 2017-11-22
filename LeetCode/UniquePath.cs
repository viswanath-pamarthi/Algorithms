using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// http://practice.geeksforgeeks.org/problems/count-all-possible-paths-from-top-left-to-bottom-right/0#ExpectOP
/// The task is to count all the possible paths from top left to bottom right of a mXn matrix with the constraints that from each cell you can either move only to right or down.
///
///Input: 
///First line consists of T test cases.First line of every test case consists of N and M, denoting the number of rows and number of column respectively.
///
///Output: 
///Single line output i.e count of all the possible paths from top left to bottom right of a mXn matrix.Since output can be very large number use %10^9+7.
///
///
///Constraints:
///1<=T<=100
///1<=N<=100
///1<=M<=100
///
///
///Example:
///Input:
///1
///3 3
///Output:
///6
///
/// ----------------Leet code question-------------------
/// https://leetcode.com/problems/unique-paths/description/
/// A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
///
///The robot can only move either down or right at any point in time.The robot is trying to reach the bottom-right corner of the grid(marked 'Finish' in the diagram below).
///
///How many possible unique paths are there?
/// </summary>
namespace LeetCode
{
    class UniquePath
    {
        /// <summary>
        /// Calculate the solution using dynamic programming and recursion
        /// Time complexity: 2 comparisions for each cell. for each cell only once te comparisions are done. so a total of 2 * noOfRows *noOfCols.
        /// ignoring the constant the time complexity is 
        /// O(noOfRows* noOfCols)
        /// </summary>
        /// <param name="noOfRows"></param>
        /// <param name="noOfCols"></param>
        /// <returns></returns>
        public int NumberOfPaths(int noOfRows,int noOfCols)
        {
            //Using the concept of dynamic programming, storing the possible paths from each point, so when you reach that point the possible ways will be the same as it is from that point.
            //Using the recursion the problem is as simple as caliculating for a single cell. there are only two ways(left or down) to go from a single cell.
            int[,] numberOfPathsPerCell = new int[noOfRows, noOfCols+1];//integer array is intialized to 0 by default            

            return CalculatePaths(0,0,numberOfPathsPerCell,noOfRows, noOfCols);
        }

        private int CalculatePaths(int rowIndex, int colIndex, int[,] numberOfPathsPerCell, int noOfRows, int noOfCols)
        {
            //base case
            if (rowIndex == (noOfRows - 1) && colIndex == (noOfCols - 1))
                return 1;

            if (colIndex+1<noOfCols)
            {
                //check if there is a value for the right cell, if present then no need to calucuate the paths for that cell again
                numberOfPathsPerCell[rowIndex, colIndex] += numberOfPathsPerCell[rowIndex,colIndex+1]>0? numberOfPathsPerCell[rowIndex, colIndex + 1] : CalculatePaths(rowIndex, colIndex + 1, numberOfPathsPerCell, noOfRows, noOfCols);
            }

            if(rowIndex+1<noOfRows)
            {
                //check if there is a value for the bottom cell, if present then no need to calucuate the paths for that cell again
                numberOfPathsPerCell[rowIndex, colIndex] += numberOfPathsPerCell[rowIndex+1, colIndex] > 0 ? numberOfPathsPerCell[rowIndex+1, colIndex] : CalculatePaths(rowIndex+1, colIndex, numberOfPathsPerCell, noOfRows, noOfCols);
            }

            return numberOfPathsPerCell[rowIndex, colIndex];
        }
    }
}
