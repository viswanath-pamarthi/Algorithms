using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/trim-a-binary-search-tree/discuss/
/// Given a binary search tree and the lowest and highest boundaries as L and R, trim the tree so that all its elements lies in [L, R] (R >= L). You might need to change the root of the tree, so the result should return the new root of the trimmed binary search tree.
///
///Example 1:
///Input: 
///    1
///   / \
///  0   2
///
///  L = 1
///  R = 2
///
///Output: 
///    1
///      \
///       2
///Example 2:
///Input: 
///    3
///   / \
///  0   4
///   \
///    2
///   /
///  1
///
///  L = 1
///  R = 3
///
///Output: 
///      3
///     / 
///   2   
///  /
/// 1
/// </summary>
namespace LeetCode.TrimBST
{
    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class TrimBST
    {
        public TreeNode _TrimBST(TreeNode root, int L, int R)
        {
            //Referred the discussion section
            if (root == null)
                return null;

            if (root.val < L)
            {
                return (_TrimBST(root.right, L, R));//As the current node is less than the range, the left sub tree also will not be in the range. We are just skipping(not returning the current node) this node and proceeding to the right sub tree            
            }

            if (root.val > R)
            {
                return (_TrimBST(root.left, L, R));//As the current node is greater than the range, the right sub tree also will not be in the range. We are just skipping(not returning the current node) this node and proceeding to the left sub tree 
            }


            //if not less than L and not greater than R, then the node is in range
            root.left = _TrimBST(root.left, L, R);
            root.right = _TrimBST(root.right, L, R);

            return root;//retain the node in range

        }
    }
}
