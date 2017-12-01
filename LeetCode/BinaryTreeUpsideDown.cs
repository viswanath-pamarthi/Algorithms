using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/binary-tree-upside-down/description/
/// Given a binary tree where all the right nodes are either leaf nodes with a sibling (a left node that shares the same parent node) or empty, flip it upside down and turn it into a tree where the original right nodes turned into left leaf nodes. Return the new root.
///
///For example:
///Given a binary tree {1,2,3,4,5},
///    1
///   / \
///  2   3
/// / \
///4   5
///return the root of the binary tree[4, 5, 2,#,#,3,1].
///   4
///  / \
/// 5   2
///    / \
///   3   1
///   confused what "{1,#,2,3}" means? > read more on how binary tree is serialized on OJ.
///   OJ's Binary Tree Serialization:
///The serialization of a binary tree follows a level order traversal, where '#' signifies a path terminator where no node exists below.
///
///Here's an example:
///   1
///  / \
/// 2   3
///    /
///   4
///    \
///     5
///The above binary tree is serialized as "{1,2,3,#,#,4,#,#,5}".
/// </summary>
namespace LeetCode
{
    
// Definition for a binary tree node.
 public class TreeNode
  {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int x) { val = x; }
 }

    class BinaryTreeUpsideDown
    {
        /// <summary>
        /// Time complexity ? of a binary tree 
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode UpsideDownBinaryTree(TreeNode root)
        {
            //as the right child is either leaf node or null, we have to traverse the tree to left and then push every node on to stack


            if (root == null || (root.left == null && root.right == null))
            {
                return root;
            }

            TreeNode temp = root;
            Stack<TreeNode> stackOfnodes = new Stack<TreeNode>();//push the nodes based on the order we want them back, we want last one first and then the nd=ode to go on left

            while (temp != null)
            {
                stackOfnodes.Push(temp);//stack accepts null and duplicate values
                stackOfnodes.Push(temp.right);
                //stackOfnodes.push(temp.left);            
                temp = temp.left;
            }

            //How to check if a Stack<T> is empty

            TreeNode newRoot;//= stackOfnodes.Peek()!=null? stackOfnodes.Pop():

            if (stackOfnodes.Peek() != null)
            {
                newRoot = stackOfnodes.Pop();
            }
            else
            {
                stackOfnodes.Pop();// to remove the null value in top. in the scenario of 1,2 tree
                newRoot = stackOfnodes.Pop();
            }

            TreeNode temp1 = newRoot;

            //https://stackoverflow.com/questions/25748906/how-to-check-if-a-stackt-is-empty
            while (stackOfnodes.Count > 0 && temp1 != null)
            {
                temp1.left = stackOfnodes.Pop();

                if (temp1.left != null)
                {
                    temp1.left.left = null;
                    temp1.left.right = null;
                }

                temp1.right = stackOfnodes.Pop();
                if (temp1.right != null)
                {
                    temp1.right.left = null;
                    temp1.right.right = null;
                }

                temp1 = temp1.right;
            }

            return newRoot;
        }
    }
}
