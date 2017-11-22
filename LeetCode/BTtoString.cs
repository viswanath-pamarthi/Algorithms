using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/construct-string-from-binary-tree/description/
///     You need to construct a string consists of parenthesis and integers from a binary tree with the preorder traversing way.
///
///The null node needs to be represented by empty parenthesis pair "()". And you need to omit all the empty parenthesis pairs that don't affect the one-to-one mapping relationship between the string and the original binary tree.
///
///Example 1:
///Input: Binary tree: [1,2,3,4]
///       1
///     /   \
///    2     3
///   /    
///  4     
///
///Output: "1(2(4))(3)"
///
///Explanation: Originallay it needs to be "1(2(4)())(3()())", 
///but you need to omit all the unnecessary empty parenthesis pairs.
///And it will be "1(2(4))(3)".
///Example 2:
///Input: Binary tree: [1,2,3,null,4]
///       1
///     /   \
///    2     3
///     \  
///      4 
///
///Output: "1(2()(4))(3)"
///
///Explanation: Almost the same as the first example, 
///except we can't omit the first parenthesis pair to break the one-to-one mapping relationship between the input and the output.
/// </summary>
namespace LeetCode.BTtoString
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
        
    class BTtoString
    {
        public string Tree2str(TreeNode t)
        {
            if (t == null)
                return "";

            return PresOrderTraversal(t);
        }

        public string PresOrderTraversal(TreeNode t)
        {
            if (t == null)
            {
                return null;
            }

            string temp = "";//=new string();
            temp += t.val;
            string left = PresOrderTraversal(t.left);
            string right = PresOrderTraversal(t.right);

            if (!(string.IsNullOrEmpty(left) && string.IsNullOrEmpty(right)))
            {
                temp += string.IsNullOrEmpty(left) ? "()" : "(" + left + ")";
                temp += string.IsNullOrEmpty(right) ? "" : "(" + right + ")";
            }


            return temp;
        }
    }
}
