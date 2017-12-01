using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/two-sum-iii-data-structure-design/description/
/// Design and implement a TwoSum class. It should support the following operations: add and find.
///
///add - Add the number to an internal data structure.
///find - Find if there exists any pair of numbers which sum is equal to the value.
///
///For example,
///add(1); add(3); add(5);
///find(4) -> true
///find(7) -> false
///
/// </summary>
namespace LeetCode
{
    class TwoSumIII
    {
        //Quesstion - can the numbers in the , can zero exist in the list - yes, there is a test case add 0 ,0 and find 0?
        //also nothig mentioned on the negative numbres
        Dictionary<int, int> numbersList;//number, count - the questions is not clear on the 0 number case- code is failing when there is on 0 add and  then find 0, as per the test case the code fails
                                         /** Initialize your data structure here. */
        public TwoSumIII()
        {
            numbersList = new Dictionary<int, int>();
        }

        /** Add the number to an internal data structure.. */
        public void Add(int number)
        {
            if (numbersList.ContainsKey(number))
                numbersList[number] = 2;
            else
                numbersList.Add(number, 1);
        }

        /** Find if there exists any pair of numbers which sum is equal to the value. */
        public bool Find(int value)
        {
            /* 
             //special case when value is zero
             if(value==0)
             {
                 if(!numbersList.ContainsKey(0))
                 {
                     return false;
                 }
                 else
                 {
                     if(numbersList[value]>1)
                         return true;
                     else
                         return false;
                 }
             }*/

            //referred discussion section for this idea
            foreach (var item in numbersList)
            {
                int num1 = item.Key;
                int num2 = value - num1;

                if (numbersList.ContainsKey(num2))
                {
                    if (num1 != num2 || (numbersList[num2] == 2))
                    {
                        return true;
                    }
                }
            }

            /* 
             //start with 1, n-1 and run till either of the numbers is n/2. after n/2 the same pairs repeat
             int firstNumber=0;
             int secondNumber=value;

             while(firstNumber<=(value/2)&&secondNumber>=(value/2))
             {
                 if(numbersList.ContainsKey(firstNumber)&&numbersList.ContainsKey(secondNumber))
                     return true;

                 firstNumber++;
                 secondNumber--;
             }*/

            return false;
        }
    }
}
