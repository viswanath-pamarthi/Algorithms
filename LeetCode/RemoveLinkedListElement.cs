using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/remove-linked-list-elements/description/
/// Remove all elements from a linked list of integers that have value val.
///
///Example
///Given: 1 --> 2 --> 6 --> 3 --> 4 --> 5 --> 6, val = 6
///Return: 1 --> 2 --> 3 --> 4 --> 5
/// </summary>
namespace LeetCode
{
    class RemoveLinkedListElement
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode temp;
            temp = head;

            if (head == null)
                return head;
            else if ((head.next == null) && (head.val == val))
            {
                head = head.next;
                return head;
            }


            while (temp.next != null)
            {
                if ((head.val == val))
                {
                    head = head.next;
                    temp = head;
                }
                //else if((temp.next.val ==val) && (temp.next.next ==null))
                else if (temp.next.val == val)
                {
                    temp.next = temp.next.next;
                }
                else
                    temp = temp.next;

            }

            if ((head.next == null) && (head.val == val))
            {
                head = head.next;
                return head;
            }

            return head;
        }
    }
}
