using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/#/description
/// Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
/// </summary>
namespace LeetCode.PreventConflict
{

    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x) { val = x; }
    }


    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
  

    class SortedListToBST
    {

        public TreeNode SortedListToBST_Method(ListNode head)
        {
            //referred the discussion section

            if (head == null)
                return null;

            return GenerateBST(head, null);
        }

        public TreeNode GenerateBST(ListNode head, ListNode tail)
        {
            if (head == tail)
                return null;

            ListNode slow = head;
            ListNode fast = head;

            //At the end of this loop slow will be the center of the list, Fast is either null or the last node
            while (fast != tail && fast.next != tail)
            {
                fast = fast.next.next;//Advance 2 times
                slow = slow.next;//Advance 1 time
            }

            TreeNode node = new TreeNode(slow.val);

            node.left = GenerateBST(head, slow);//now slow is kindof plays the role of the null to present the end of the list, similar to that of sorted array to BST, height balanced
            node.right = GenerateBST(slow.next, tail);

            return node;
        }


    }
}
