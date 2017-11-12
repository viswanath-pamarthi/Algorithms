using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Given a linked list, return the node where the cycle begins. If there is no cycle, return null.
///https://leetcode.com/problems/linked-list-cycle-ii/description/
///Note: Do not modify the linked list.
///
///Follow up:
///Can you solve it without using extra space?
/// </summary>
namespace LeetCode
{
    class LinkedListCycle2
    {
        /// <summary>
        /// Detect the cycle in linked List and return the starting node of the cycle.
        /// Note: head node and starting node of cycle are not same
        /// </summary>
        /// <param name="head">haed node of the linked list</param>
        /// <returns>first node on the cycle detected</returns>
        public ListNode DetectCycle(ListNode head)
        {
            ListNode temp1;
            ListNode temp2;

            //empty list and list with one item then return no cycle
            if (head == null || head.next == null)
                return null;

            temp1 = head;
            temp2 = head;


            while (temp2.next != null && temp2.next.next != null)
            {
                temp1 = temp1.next;
                temp2 = temp2.next.next;

                if (temp1 == temp2)
                {
                    //set temp1 to head and move temp1 amd temp2 at rate of 1 step each, it is assumed that the point they meet now is the start of the cycle
                    //https://stackoverflow.com/questions/2936213/explain-how-finding-cycle-start-node-in-cycle-linked-list-work
                    temp1 = head;

                    while (temp1 != temp2)
                    {
                        temp1 = temp1.next;
                        temp2 = temp2.next;
                    }
                    return temp1;
                }
            }



            return null;
        }
    }
}
