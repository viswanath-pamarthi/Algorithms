using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/intersection-of-two-linked-lists/description/
/// Write a program to find the node at which the intersection of two singly linked lists begins.
///
///
///For example, the following two linked lists:
///
///A:          a1 → a2
///                   ↘
///                     c1 → c2 → c3
///                   ↗            
///B:     b1 → b2 → b3
///begin to intersect at node c1.
///
///
///Notes:
///
///If the two linked lists have no intersection at all, return null.
///The linked lists must retain their original structure after the function returns.
///You may assume there are no cycles anywhere in the entire linked structure.
///Your code should preferably run in O(n) time and use only O(1) memory.
/// </summary>
namespace LeetCode
{
    //public class ListNode
    //{
    //    int value;
    //    ListNode next;
    //    public ListNode(int value)
    //    {
    //        this.value = value;
    //    }
    //}


    class IntersectionLinkedList
    {
        /// <summary>
        /// Time complexity is O(n), where n being the length of the shorter list
        /// space complexity is O(1)
        /// </summary>
        /// <param name="headOne"></param>
        /// <param name="headTwo"></param>
        /// <returns></returns>
        public ListNode FindIntersectionLists(ListNode headOne,ListNode headTwo)
        {
            //referred the discussion section on the idea of lengths and substracting the length

            if (headOne == null || headTwo == null)
                return null;

            ListNode tempOne = headOne;
            ListNode tempTwo = headTwo;

            //find the length of first list
            int lenghtOfFirstList = FindLengthOfList(headOne);
            //find the length of second list
            int lenghtOfSecondList = FindLengthOfList(headTwo);

            //Progress the longer list head to equal the length of the shorter list
            while (lenghtOfFirstList > lenghtOfSecondList)
            {
                tempOne = tempOne.next;
                lenghtOfFirstList--;
            }

            while (lenghtOfSecondList > lenghtOfFirstList)
            {
                tempTwo = tempTwo.next;
                lenghtOfSecondList--;
            }

            //progress the pointers of both lists till the intersection is reach at the same time
            while (tempOne!=null && tempTwo!=null && tempOne != tempTwo)
            {
                tempOne = tempOne.next;
                tempTwo = tempTwo.next;
            }

            return tempOne;
        }

        /// <summary>
        /// A method to find the length of the list
        /// </summary>
        /// <param name="head">head of the list</param>
        /// <returns></returns>
        private int FindLengthOfList(ListNode head)
        {
            ListNode temp = head;
            int lengthOfList = 0;

            while(temp!=null)
            {
                temp = temp.next;
                lengthOfList++;
            }

            return lengthOfList;
        }
    }
}
