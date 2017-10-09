using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
/// Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
/// </summary>
namespace LeetCode.SortedArrayToBST
{
    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class SortedArrayToBST
    {
        public TreeNode _SortedArrayToBST(int[] nums)
        {
            //referred discussion section
            if (nums.Length == 0)
                return null;

            TreeNode root = GenerateBST(nums, 0, nums.Length - 1);

            return root;
        }
        //L - Low, R-High
        public TreeNode GenerateBST(int[] nums, int L, int R)
        {
            //Base Condition
            if (L > R)
                return null;

            int m = (L + R) / 2;//Find the middle node

            TreeNode node = new TreeNode(nums[m]);
            node.left = GenerateBST(nums, L, m - 1);
            node.right = GenerateBST(nums, m + 1, R);

            return node;
        }
    }
}
