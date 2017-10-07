using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.
///https://leetcode.com/problems/delete-node-in-a-linked-list/description/
///Supposed the linked list is 1 -> 2 -> 3 -> 4 and you are given the third node with value 3, the linked list should become 1 -> 2 -> 4 after calling your function.
///
///
/// </summary>
namespace LeetCode
{
    class DeleteNodeLinkedList
    {
        public void DeleteNode(ListNode node)
        {
            //referred discussion for this question!
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}
