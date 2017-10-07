using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Given a linked list, remove the nth node from the end of list and return its head.
///https://leetcode.com/problems/remove-nth-node-from-end-of-list/discuss/
///For example,
///
///   Given linked list: 1->2->3->4->5, and n = 2.
///
///   After removing the second node from the end, the linked list becomes 1->2->3->5.
///Note:
///Given n will always be valid.
///Try to do this in one pass.
///
///
/// </summary>
namespace LeetCode
{
    class RemoveNthNodeLastLinkedList
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //referred the discussion section
            ListNode temp = new ListNode(0);

            ListNode start = temp;
            ListNode end = temp;
            start.next = head;//with this dummy node in place there is no special case of checking if the node to be deleted is head, now it is same as deleting the node in between the list


            if (head == null || ((head.next == null) && n > 1))
                return null;
            //making a gap of n nodes between the start and end nodes
            for (int i = 0; i <= n; i++)
            {
                end = end.next;
            }


            while (end != null)
            {
                start = start.next;
                end = end.next;
            }

            start.next = start.next.next;

            return temp.next;
        }
    }
}
