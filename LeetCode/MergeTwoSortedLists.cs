using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// https://leetcode.com/problems/merge-two-sorted-lists/description/
/// Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.
/// </summary>
namespace LeetCode
{
    class MergeTwoSortedLists
    {
        /// <summary>
        /// O(n+m)
        /// n- first list size
        /// m-size of second list
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            //This is kind of Merge Sort , Merge routine
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            ListNode head = null;
            ListNode tail = null;

            while ((l1 != null) && (l2 != null))
            {
                if (l1.val < l2.val)
                {
                    if (head == null)
                    {
                        head = l1;
                        l1 = l1.next;
                        //l2=l2.next;
                        head.next = null;
                        tail = head;
                    }
                    else
                    {
                        tail.next = l1;
                        l1 = l1.next;
                        //l2=l2.next;
                        tail = tail.next;
                        tail.next = null;
                    }
                }
                else if (l1.val > l2.val)
                {
                    if (head == null)
                    {
                        head = l2;
                        //l1=l1.next;
                        l2 = l2.next;
                        head.next = null;
                        tail = head;
                    }
                    else
                    {
                        tail.next = l2;
                        //l1=l1.next;
                        l2 = l2.next;
                        tail = tail.next;
                        tail.next = null;
                    }
                }
                else//Equal
                {
                    if (head == null)
                    {
                        head = l1;
                        //head=head.next;
                        l1 = l1.next;
                        head.next = l2;
                        l2 = l2.next;
                        tail = head.next;
                        tail.next = null;
                        //head.next=null;
                    }
                    else
                    {
                        tail.next = l1;
                        l1 = l1.next;
                        tail = tail.next;
                        tail.next = l2;
                        l2 = l2.next;
                        tail = tail.next;
                        tail.next = null;
                    }
                }

            }

            if (l2 != null)
            {
                tail.next = l2;
            }

            if (l1 != null)
            {
                tail.next = l1;
            }

            return head;
        }

        /// <summary>
        /// Referred from the submissions, I like this simple recursive approach
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists_Recursive(ListNode a, ListNode b)
        {
            //Node res = null;
            if (a == null) return b;
            if (b == null) return a;

            if (a.val < b.val)
            {
                a.next = MergeTwoLists_Recursive(a.next, b);
                return a;

            }
            else
            {
                b.next = MergeTwoLists_Recursive(a,b.next);
                return b;
            }

        }
    }
    ///// <summary>
    ///// C++ soltion in discussiono section., I liked the idea of using the dummy node to prevent an extra case to create a head node
    ///// Also, it is simple and no extra space is consumed
    ///// </summary>
    //class Solution
    //{
    //    public:
    //ListNode* mergeTwoLists(ListNode* l1, ListNode* l2)
    //    {
    //        ListNode dummy(INT_MIN);
    //        ListNode* tail = &dummy;

    //        while (l1 && l2)
    //        {
    //            if (l1->val < l2->val)
    //            {
    //                tail->next = l1;
    //                l1 = l1->next;
    //            }
    //            else
    //            {
    //                tail->next = l2;
    //                l2 = l2->next;
    //            }
    //            tail = tail->next;
    //        }

    //        tail->next = l1 ? l1 : l2;
    //        return dummy.next;
    //    }
    //};
}
