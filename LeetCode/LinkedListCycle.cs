using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Given a linked list, determine if it has a cycle in it.
///
///Follow up:
///Can you solve it without using extra space?
/// </summary>
namespace LeetCode
{
    class LinkedListCycle
    {
        /// <summary>
        /// Detect the cycle in the linked List
        /// </summary>
        /// <param name="head">head of linked list</param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            ListNode temp1;
            ListNode temp2;

            //empty list and list with one item then return no cycle
            if (head == null || head.next == null)
                return false;

            temp1 = head;
            temp2 = head;


            while (temp2.next != null && temp2.next.next != null)
            {
                temp1 = temp1.next;
                temp2 = temp2.next.next;

                if (temp1 == temp2)
                {
                    return true;
                }
            }


            return false;
        }
    }
}
