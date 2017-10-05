using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/reverse-linked-list/description/
/// Reverse a singly linked list.
/// </summary>
namespace LeetCode
{
    class ReverseLinkedList
    {
        public ListNode ReverseList(ListNode head)
        {

            if (head == null)
                return head;

            //new head of the list (the tail)
            ListNode newHead = new ListNode(0);

            Reverse(head, ref newHead);

            return newHead;

        }

        public ListNode Reverse(ListNode head, ref ListNode newHead)
        {
            if (head.next == null)
            {
                newHead = new ListNode(head.val);
                newHead.next = null;
                return newHead;
            }

            ListNode temp = Reverse(head.next, ref newHead);

            temp.next = head;
            head.next = null;

            return head;
        }
    }
}
