//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

///// <summary>
/////   https://leetcode.com/problems/nested-list-weight-sum/description/
/////   Given a nested list of integers, return the sum of all integers in the list weighted by their depth.
/////
/////Each element is either an integer, or a list -- whose elements may also be integers or other lists.
/////
/////Example 1:
/////Given the list[[1, 1],2,[1,1]], return 10. (four 1's at depth 2, one 2 at depth 1)
/////
/////Example 2:
/////Given the list[1,[4,[6]]], return 27. (one 1 at depth 1, one 4 at depth 2, and one 6 at depth 3; 1 + 4*2 + 6*3 = 27)
///// </summary>
//namespace LeetCode
//{
//    class NestedListWeightSum
//    {
//        /// <summary>
//        /// Time complexity ?
//        /// 
//        /// Depth First Search concept is used
//        /// </summary>
//        /// <param name="nestedList"></param>
//        /// <returns></returns>
//        public int DepthSum(IList<NestedInteger> nestedList)
//        {

//            return (CalculateSum(nestedList, 1));
//        }

//        public int CalculateSum(IList<NestedInteger> nestedList, int currentLevel)
//        {
//            int sum = 0;//=CalculateSum(nestedList.GetList(),currentLevel+1);

//            //Loop throught the list items in this level
//            foreach (NestedInteger item in nestedList)
//            {
//                //Check if the item is an integer or nested list
//                if (item.IsInteger())
//                {
//                    sum += item.GetInteger() * currentLevel;
//                }
//                else
//                {
//                    sum += CalculateSum(item.GetList(), currentLevel + 1);
//                }
//            }

//            return sum;
//        }
//    }
//}
