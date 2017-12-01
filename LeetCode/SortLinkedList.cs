using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/sort-list/description/
/// Sort a linked list in O(n log n) time using constant space complexity.
/// </summary>
namespace LeetCode
{
    /// <summary>
    /// recursive relation
    /// T(n)=0  n=1(comparision when one item in the list0
    /// T(n)=T(n/2)+T(n/2)+ n   n>1(n comparisions in merge routine)
    /// 
    /// https://users.cs.duke.edu/~ola/ap/recurrence.html
    /// http://www.bowdoin.edu/~ltoma/teaching/cs231/spring16/Lectures/02-recurrences/recurrences.pdf
    /// 
    /// on solving nlog n is the time complexity
    /// </summary>
    class SortLinkedList
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList(ListNode head)
        {
            //base condition
            if (head == null)
                return null;

            if (head.next == null)
                return head;

            //Do merge sort

            //Take two pointers slow and fast. by the time fast reaches end then the slow pointer is in the middle of the list, partition the list based on it

            //partition/find the mid point, 0 data comparisions in finding the midpoint
            ListNode secondListHead = PartitionList(head);

            ListNode headTemp = SortList(head);//T(n/2)- size is reduced by 2
            ListNode secondListHeadTemp = SortList(secondListHead);//T(n/2)- size is reduced by 2

            //merge - Worst case comparisions "n" - numbers in each half are alternative like 2,4,6 and 3,5,7. each number two comparisions - total of n comparisions
            ListNode temp = MergeList(headTemp, secondListHeadTemp);

            return temp;

        }

        public ListNode MergeList(ListNode head1, ListNode head2)
        {

            if (head1 == null)
                return head2;

            if (head2 == null)
                return head1;

            /* stack overflow issue for larger inputs if using this recursive solution, switching to iterative solution 
            if (head1.val < head2.val)
            {
                head1.next = MergeList(head1.next, head2);
                return head1;
            }

            else
            {
                head2.next = MergeList(head1, head2.next);
                return head2;
            }*/

            ListNode dummyNode = new ListNode(0);//interesting solution having a dummy node, so the special case
            ListNode tail = dummyNode;

            while (head1 != null && head2 != null)
            {
                if (head1.val <= head2.val)
                {
                    tail.next = head1;
                    head1 = head1.next;
                    tail = tail.next;
                    tail.next = null;
                }
                else
                {
                    tail.next = head2;
                    head2 = head2.next;
                    tail = tail.next;
                    tail.next = null;
                }
            }

            if (head1 != null)
            {
                tail.next = head1;
            }

            if (head2 != null)
            {
                tail.next = head2;
            }


            return dummyNode.next;

        }

        public ListNode PartitionList(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            //by the end of the loop slow will be in the middle of the list approximately
            //slow.next will be the second list
            ListNode secondListHead = slow.next;
            slow.next = null;// to mark the end of the part of the list while merging

            return secondListHead;
        }
    }
}
