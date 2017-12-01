using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/find-leaves-of-binary-tree/description/
/// Given a binary tree, collect a tree's nodes as if you were doing this: Collect and remove all leaves, repeat until the tree is empty.
///
///Example:
///Given binary tree 
///          1
///         / \
///        2   3
///       / \     
///      4   5    
///Returns[4, 5, 3], [2], [1].
///
///Explanation:
///1. Removing the leaves[4, 5, 3] would result in this tree:
///
///          1
///         / 
///        2          
///2. Now removing the leaf [2] would result in this tree:
///
///          1          
///3. Now removing the leaf [1] would result in the empty tree:
///
///
///         []
///Returns [4, 5, 3], [2], [1].
/// </summary>
namespace LeetCode
{
    class FindLeavesOfBinaryTree
    {
        /// <summary>
        /// used - DFS approach
        /// 
        /// Time complexity O is for 
        /// first call -removing the leave nodes- have to move down height of the tree h no of levels do get the leaves
        /// second call - have to move h-1
        /// third - h-2
        /// i.e. h+(h-1)+h-2)+(h-3).........+1+0 = h(h+1)/2
        /// 
        /// for binary tree total number of nodes n=2^(h+1) - 1
        /// log on both sides  and solving log(n) to base 2
        /// 
        /// Therefore, the time complexity O is (log n)(log n) ??
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            IList<IList<int>> AllLeaveNodes = new List<IList<int>>();

            TreeNode tempRoot = root;
            TreeNode returnNode = root;            

            while (returnNode != null)
            {
                IList<int> leaveNodes = new List<int>();
                returnNode = FindInLeaves(tempRoot, leaveNodes);
                AllLeaveNodes.Add(new List<int>(leaveNodes));//if directly added without new then only reference the current leavenodes list is added. if there is change done to the leaveNodes list then it reflects in the corresponsing list in the AllLeaveNodes list
            }

            return AllLeaveNodes;

        }

        public TreeNode FindInLeaves(TreeNode root, IList<int> leaveNodes)
        {
            if (root == null)
                return null;

            //Base case for a leave node, return null to remove it from tree
            if (root.left == null && root.right == null)
            {
                leaveNodes.Add(root.val);
                return null;
            }

            root.left = FindInLeaves(root.left, leaveNodes);
            root.right = FindInLeaves(root.right, leaveNodes);

            return root;
        }
    }
}
