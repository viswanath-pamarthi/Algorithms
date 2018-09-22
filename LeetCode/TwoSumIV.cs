using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/two-sum-iv-input-is-a-bst/description/
    /// Given a Binary Search Tree and a target number, return true if there exist two elements in the BST such that their sum is equal to the given target.
    ///
    ///Example 1:
    ///Input: 
    ///    5
    ///   / \
    ///  3   6
    /// / \   \
    ///2   4   7
    ///
    ///Target = 9
    ///
    ///Output: True
    ///Example 2:
    ///Input: 
    ///    5
    ///   / \
    ///  3   6
    /// / \   \
    ///2   4   7
    ///
    ///Target = 28
    ///
    ///Output: False
    /// </summary>
    class TwoSumIV
    {
        public bool FindTarget(TreeNode root, int k)
        {
            HashSet<int> values = new HashSet<int>();//Generic collection to hold unique elements

            return Find(root, k, values);

        }

        private bool Find(TreeNode root, int target, HashSet<int> data)
        {
            if (root == null)
                return false;

            if (data.Contains(target - root.val))
                return true;
            else
                data.Add(root.val);

            return Find(root.left, target, data) || Find(root.right, target, data);

        }
    }
}
