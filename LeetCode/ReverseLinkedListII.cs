using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class ReverseLinkedListII
    {
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {

            ListNode newMthNode = new ListNode(0);
            ListNode temp = head;

            ListNode nPlusOneNode = new ListNode(0);

            //navigate till mth node
            for (int i = 1; i < m - 1; i++)
            {
                temp = temp.next;
            }

            if(m==1)
            {
                Reverse(temp, ref newMthNode, ref nPlusOneNode, m, n);
                temp.next = nPlusOneNode;
                temp = newMthNode;
                head = temp;
            }
            else
            {
                Reverse(temp.next, ref newMthNode, ref nPlusOneNode, m, n);
                temp.next.next = nPlusOneNode;
                temp.next = newMthNode;
            }
            

            return head;
        }

        public ListNode Reverse(ListNode head, ref ListNode newMthNode, ref ListNode nPlusOneNode, int m, int n)
        {
            if (m == n)
            {
                newMthNode = head;
                nPlusOneNode = head.next;
                newMthNode.next = null;

                return newMthNode;
            }

            ListNode temp = Reverse(head.next, ref newMthNode, ref nPlusOneNode, m + 1, n);

            temp.next = head;
            head.next = null;

            return head;

        }
    }
}
