using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/partition-list/description/
/// Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.
///
///You should preserve the original relative order of the nodes in each of the two partitions.
///
///For example,
///Given 1->4->3->2->5->2 and x = 3,
///return 1->2->2->4->3->5.
/// </summary>
namespace LeetCode
{
    class PartitionList
    {
        public ListNode Partition(ListNode head, int x)
        {
            ListNode lessThanX = null;//tail
            ListNode lessThanXHead = null;//head
            ListNode greaterThanX = null;//tail for greater than and equal to x
            ListNode greaterThanXHead = null;//head

            ListNode temp = null;

            if (head == null || head.next == null)
                return head;
            else
                temp = head;

            while (temp != null)
            {
                if (temp.val < x)
                {

                    if (lessThanX != null)
                    {
                        lessThanX.next = temp;
                        lessThanX = lessThanX.next;
                        temp = temp.next;
                        lessThanX.next = null;
                    }
                    else
                    {
                        lessThanXHead = temp;
                        lessThanX = temp;
                        temp = temp.next;
                        lessThanXHead.next = null;
                    }

                }
                else if (temp.val >= x)
                {
                    if (greaterThanX != null)
                    {
                        greaterThanX.next = temp;
                        greaterThanX = greaterThanX.next;
                        temp = temp.next;
                        greaterThanX.next = null;

                    }
                    else
                    {
                        greaterThanXHead = temp;
                        greaterThanX = temp;
                        temp = temp.next;
                        greaterThanXHead.next = null;

                    }

                }
                else
                    temp = temp.next;


            }


            if (lessThanXHead != null)
            {
                lessThanX.next = greaterThanXHead;
                return lessThanXHead;
            }
            else if (greaterThanXHead != null)
            {
                return greaterThanXHead;
            }


            return head;

        }
    }
}
