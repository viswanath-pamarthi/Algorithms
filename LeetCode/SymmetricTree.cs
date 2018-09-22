    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/symmetric-tree/description/
/// Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
///
///For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
///
///    1
///   / \
///  2   2
/// / \ / \
///3  4 4  3
///But the following[1, 2, 2, null, 3, null, 3] is not:
///    1
///   / \
///  2   2
///   \   \
///   3    3
///Note:
///Bonus points if you could solve it both recursively and iteratively.
/// </summary>
namespace LeetCode
{
    class SymmetricTree
    {
        public bool IsSymmetric(TreeNode root)
        {

            //Solved using recursion
            //If no elements in the tree then it is symmetric
            if (root == null)
                return true;

            return CheckIfSymmetric(root.left, root.right);
        }

        /// <summary>
        /// Recursive solution.
        /// Time Complexity: O(n)- n/2 comparisions are done
        /// //https://leetcode.com/articles/symmetric-tree/
        /// Because we traverse the entire input tree once, the total run time is O(n), where nn is the total number of nodes in the tree.
        ///The number of recursive calls is bound by the height of the tree.In the worst case, the tree is linear and the height is in O(n)O(n). Therefore, space complexity due to recursive calls on the stack is O(n)O(n) in the worst case.
        /// Space Complexity: O(1) ??
        ///liked the minimal conditions checked in this solution in the discussion section.
        ///public boolean isSymmetric(TreeNode root) {
        /// return root==null || isSymmetricHelp(root.left, root.right);
        /// }
        /// 
        /// private boolean isSymmetricHelp(TreeNode left, TreeNode right)
        ///{
        ///    if (left == null || right == null)
        ///        return left == right;// will this work , will it explicitly check the val of left and right
        ///    if (left.val != right.val)
        ///        return false;
        ///       return isSymmetricHelp(left.left, right.right) && isSymmetricHelp(left.right, right.left);
        ///   }
        ///   /// </summary>
        ///   /// <param name="leftSubTreeNode"></param>
        /// <param name="rightSubTreeNode"></param>
        /// <returns></returns>
        public bool CheckIfSymmetric(TreeNode leftSubTreeNode, TreeNode rightSubTreeNode)
        {
            //check if the nodes make the tree asymmetric
            if (((leftSubTreeNode != null) && (rightSubTreeNode == null)) || ((leftSubTreeNode == null) && (rightSubTreeNode != null)))
            {
                return false;
            }

            //Base case: Check if the values are same for the mirror nodes, also the case where both are null
            if (((leftSubTreeNode == null) && (rightSubTreeNode == null)))
            {
                return true;
            }

            //If the mirror nodes values are not equal , return false
            if ((leftSubTreeNode.val != rightSubTreeNode.val))
            {
                return false;
            }

            if (!CheckIfSymmetric(leftSubTreeNode.left, rightSubTreeNode.right))
                return false;

            if (!CheckIfSymmetric(leftSubTreeNode.right, rightSubTreeNode.left))
                return false;

            return true;
        }

        //Iterative solution
        //Because we traverse the entire input tree once, the total run time is O(n), where n is the total number of nodes in the tree.

        //There is additional space required for the search queue.In the worst case, we have to insert O(n) nodes in the queue.Therefore, space complexity is O(n)O(n).
        /* public bool IsSymmetric(TreeNode root)
         {

             //Solved using recursion
             //If no elements in the tree then it is symmetric
             if (root == null || (root.left == null && root.right == null))
                 return true;



             return CheckIfSymmetric(root);
         }

         
         public bool CheckIfSymmetric(TreeNode root)
         {
             //Queue to store the sequence of the nodes to be checked. Consecutive two nodes are the mirror nodes in symmetric tree. First is left node and second is right node
             Queue<TreeNode> queueForMirrorNodes = new Queue<TreeNode>();

             queueForMirrorNodes.Enqueue(root.left);
             queueForMirrorNodes.Enqueue(root.right);

             //loop till all the nodes are completed comparision i.e. the queue is empty
             while (queueForMirrorNodes.Count > 0)
             {
                 TreeNode leftNode = queueForMirrorNodes.Dequeue();
                 TreeNode rightNode = queueForMirrorNodes.Dequeue();



                 //if the values of the mirror nodes are un-equal tree is not symmetric
                 if ((leftNode == null && rightNode != null) || (rightNode == null && leftNode != null) || (leftNode.val != rightNode.val))
                 {
                     return false;
                 }

                 //push all mirror nodes, except when both of the nodes are null - just preventing the extra conditions to be checked after dequeuing as this is a valid scenario for a symmetric tree
                 if (!(leftNode.left == null && rightNode.right == null))
                 {
                     queueForMirrorNodes.Enqueue(leftNode.left);
                     queueForMirrorNodes.Enqueue(rightNode.right);
                 }

                 if (!(leftNode.right == null && rightNode.left == null))
                 {
                     queueForMirrorNodes.Enqueue(leftNode.right);
                     queueForMirrorNodes.Enqueue(rightNode.left);
                 }
             }


             return true;

         }
         */
    }
}
