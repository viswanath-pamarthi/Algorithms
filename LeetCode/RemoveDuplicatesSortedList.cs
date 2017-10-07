using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Given a sorted linked list, delete all duplicates such that each element appear only once.
///https://leetcode.com/problems/remove-duplicates-from-sorted-list/description/
///For example,
///Given 1->1->2, return 1->2.
///Given 1->1->2->3->3, return 1->2->3.
/// </summary>
namespace LeetCode
{
    class RemoveDuplicatesSortedList
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            //refered from solutions
            if (head == null || head.next == null)
                return head;

            head.next = DeleteDuplicates(head.next);

            return head.val == head.next.val ? head.next : head;

        }
    }
}
