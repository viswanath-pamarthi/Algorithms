using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// https://leetcode.com/problems/paint-house/description/
/// There are a row of n houses, each house can be painted with one of the three colors: red, blue or green. The cost of painting each house with a certain color is different. You have to paint all the houses such that no two adjacent houses have the same color.
///
///The cost of painting each house with a certain color is represented by a n x 3 cost matrix.For example, costs[0][0] is the cost of painting house 0 with color red; costs[1][2] is the cost of painting house 1 with color green, and so on...Find the minimum cost to paint all houses.
///
///Note:
///All costs are positive integers.
/// </summary>
namespace LeetCode
{
    class PaintHouse
    {
        /// <summary>
        /// Used dynamic programming and memoization
        /// Time complexity 3*n ?
        /// 
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public int MinCost(int[,] costs)
        {

            //find minimum of each row and add them up - this won't work, because if yuo choose the minimum in the first row,first col the in the second row the minimum value can be in thefirst column itself. As we choose col1 or red for first house you have to go with other colors/cols for second house, and the second or 3rd cols might have a larger values, which will add up to the cost, and you won'r get the minimum cost to paint all houses.
            //So you have to caluculate all the possible ways of painting and have to finilize based min val of the total cost to paint the houses. In this process you have to memoization the values for the sub problems (i.e. painting a house with different color is a sub problem). You will be using dynamic programming, if you choose red for second house the you have to get the minimum cost to paint first house either with blue or green.So, you will calculate these values for first house or the respective house for every combination of colors and store them (called memoization in dynamic programming. Traditionally dynamic programming problems are solved iteratively)
            /*int minCostToPaintAll=0;
            int rowLength=costs.GetLength(0);////https://stackoverflow.com/questions/9404683/get-a-length-of-row-column-in-c-sharp
            int colLength=3;
            int currentRow=0;//counter or rows
           // int currentCol=0;
            int previousHousePaint=-1;

            while(currentRow<rowLength)
            {
               //minCostToPaintAll += costs[currentRow,].Min();
                int minValue=int.MaxValue;
                int colSelected=-1;
                for(int currentCol=0;currentCol<colLength;currentCol++)
                {
                    if((costs[currentRow,currentCol]<minValue) &&(currentCol !=previousHousePaint))
                    {
                        colSelected=currentCol;
                        minValue=costs[currentRow,currentCol];
                    }

                }
                previousHousePaint=colSelected;
                minCostToPaintAll +=minValue;
                currentRow++;
            }*/


            //https://stackoverflow.com/questions/4106369/how-do-i-find-the-size-of-a-2d-array
            //Length of 2d array gives noOfrows * noOfCols- total cells
            if (costs == null || costs.Length == 0)
                return 0;

            int rowLength = costs.GetLength(0);//get length of 0 gives noOfRows, of 1 give num of cols

            //referred the discussion section for the idea for this solution

            for (int currentRow = 1; currentRow < rowLength; currentRow++)
            {
                //Total cost to paint current house with Red. e.g. if second house is painted with red then the first house is painted with minimum of either Green or BLue. Fetch that value of first house and add it to the current cost of painting the second house.
                costs[currentRow, 0] += Math.Min(costs[currentRow - 1, 1], costs[currentRow - 1, 2]);
                costs[currentRow, 1] += Math.Min(costs[currentRow - 1, 0], costs[currentRow - 1, 2]);
                costs[currentRow, 2] += Math.Min(costs[currentRow - 1, 0], costs[currentRow - 1, 1]);
            }

            //https://stackoverflow.com/questions/12651232/find-minimum-values-among-the-5-integers
            return Math.Min(costs[rowLength - 1, 0], Math.Min(costs[rowLength - 1, 1], costs[rowLength - 1, 2]));
        }
    }
}
