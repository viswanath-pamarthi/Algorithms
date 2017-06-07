using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/add-two-numbers/#/description
/// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
///
///You may assume the two numbers do not contain any leading zero, except the number 0 itself.
///
///Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
///Output: 7 -> 0 -> 8
/// </summary>
namespace LeetCode
{
    /// <summary>
    /// node of the linked list
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    /// <summary>
    /// Adding two numbers
    /// </summary>
    class AddTwoNumbers
    {
        /// <summary>
        /// Adding two numbers
        /// </summary>
        /// <param name="l1">first list of digits</param>
        /// <param name="l2">Second list of digits</param>
        /// <returns></returns>
        public ListNode AddTwoNumbersInLinkedList(ListNode l1, ListNode l2)
        {
            ListNode temp = l1;
            ListNode temp1 = l2;
            ListNode temp2 = null;
            ListNode result = new ListNode(0);
            temp2 = result;

            int carryOver = 0;
            int i = 0;

            //CarryOver ==1: to get the carryover of the last digit added to the sum even after the both lists went null
            //or condition for both temp and temp1, as either of the lists can go null(not equal lengths)
            while ((temp != null) || (temp1 != null) || carryOver == 1)
            {
                int sum = 0;

                if (temp != null && temp1 != null)
                    sum = temp.val + temp1.val + carryOver;
                else if (temp == null && temp1 == null)
                    sum = carryOver;
                else if (temp1 == null)
                    sum = temp.val + carryOver;
                else if (temp == null)
                    sum = temp1.val + carryOver;

                carryOver = 0;

                //only the first time
                if (i == 0)
                {
                    result.val = sum % 10;
                }
                else
                {
                    int t1 = sum % 10;
                    temp2.next = new ListNode(t1);
                    temp2 = temp2.next;
                }

                //if the sum is greater than 10 then the carryover will be 1, there is not way that it can be different
                if (sum >= 10)
                    carryOver = 1;

                if (temp != null)
                    temp = temp.next;

                if (temp1 != null)
                    temp1 = temp1.next;

                i++;

            }

            return result;
        }
    }
}
