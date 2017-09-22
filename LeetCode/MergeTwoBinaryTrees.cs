using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/merge-two-binary-trees/description/
/// Given two binary trees and imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not.
///
///You need to merge them into a new binary tree.The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node.Otherwise, the NOT null node will be used as the node of new tree.
///
///Example 1:
///Input: 
///	Tree 1                     Tree 2                  
///          1                         2                             
///         / \                       / \                            
///        3   2                     1   3                        
///       /                           \   \                      
///      5                             4   7                  
///Output: 
///Merged tree:
///	     3
///	    / \
///	   4   5
///	  / \   \ 
///	 5   4   7
///Note: The merging process must start from the root nodes of both trees.
/// </summary>
namespace LeetCode.MergeTwoBinaryTrees
{
    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class MergeTwoBinaryTrees
    {
        /// <summary>
        /// Merge teo Binary trees
        /// </summary>
        /// <param name="t1">node of tree 1</param>
        /// <param name="t2">node of tree 2</param>
        /// <returns>new node (merged one)</returns>
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            //Referred the solutions
            if (t1 == null && t2 == null)
            {
                return null;
            }

            TreeNode mergedNode = new TreeNode(0);
            mergedNode.val = (t1 == null ? 0 : t1.val) + (t2 == null ? 0 : t2.val);
            mergedNode.left = MergeTrees(t1 == null ? null : t1.left, t2 == null ? null : t2.left);
            mergedNode.right = MergeTrees(t1 == null ? null : t1.right, t2 == null ? null : t2.right);

            return mergedNode;
        }
    }
}
