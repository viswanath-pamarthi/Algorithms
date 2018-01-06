using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/serialize-and-deserialize-binary-tree/description/
/// Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
///
///Design an algorithm to serialize and deserialize a binary tree.There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.
///
///For example, you may serialize the following tree
///
///    1
///   / \
///  2   3
///     / \
///    4   5
///as "[1,2,3,null,null,4,5]", just the same as how LeetCode OJ serializes a binary tree.You do not necessarily need to follow this format, so please be creative and come up with different approaches yourself.
///Note: Do not use class member/global/static variables to store states.Your serialize and deserialize algorithms should be stateless.
///
///Credits:
///Special thanks to @Louis1992 for adding this problem and creating all test cases.
/// </summary>
namespace LeetCode
{
    class SerializeDeserializeBinaryTree
    {

        /// <summary>
        /// Encodes a tree to a single string. each node is delemited by ","  and null node is represented as "null"
        /// Time Complexity: ??
        /// Space Complexity: ??
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public string serialize(TreeNode root)
        {
            //if root not null then only proceed
            if (root == null)
                return null;

            //Will perform level order traversal for the binary tree using queue
            Queue<TreeNode> queueForTraversal = new Queue<TreeNode>();
            StringBuilder serializedResult = new StringBuilder();

            queueForTraversal.Enqueue(root);//push root on to queue
            int nodesToPop = 1;//Number of nodes to pop according to level

            //run till there are no elements in the queue
            while (queueForTraversal.Count > 0)
            {
                //pop the nodes for the current level from queue and add it to string
                int countOfNodesToDequeue = nodesToPop;
                nodesToPop = 0;

                for (int i = countOfNodesToDequeue; i > 0; i--)
                {

                    //While dequeueing the TreeNode can be null as we will push the nodes left and right even when they are null(leaf nodes)
                    TreeNode tempNode = queueForTraversal.Dequeue();

                    if (tempNode != null)
                    {
                        //Append the node value to the serialized string
                        serializedResult.Append(tempNode.val);
                        serializedResult.Append(",");

                        //Add the nodes child to the queue
                        queueForTraversal.Enqueue(tempNode.left);
                        queueForTraversal.Enqueue(tempNode.right);
                        nodesToPop += 2;//increment the count for next level popping
                    }
                    else
                    {
                        //If the node is null justt append null to the serialized string
                        serializedResult.Append("null");
                        serializedResult.Append(",");
                    }


                }
            }

            Console.WriteLine(serializedResult.ToString().TrimEnd(','));

            return serializedResult.ToString().TrimEnd(',');
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {

            if (String.IsNullOrEmpty(data))
            {
                return null;
            }

            //Split the serialized string on delimiter ','
            String[] nodes = data.Split(',');

            //Root node of the tree
            TreeNode root = new TreeNode(int.Parse(nodes[0]));

            Queue<TreeNode> queueForNodes = new Queue<TreeNode>();
            queueForNodes.Enqueue(root);//Add the root node to the queue

            //int nodesToPop=1;// Will pop only one Node from Queue, But will scann two  items from nodes Array - not required because will pop only one node from queue at a time

            int nodesIndex = 1;//Index pointing to the next element to read from nodes

            //Loop till the queue is empty  && till the end of the serialized string array
            while ((queueForNodes.Count > 0) && (nodesIndex < nodes.Length))
            {

                //Scan two elements in to Tree Nodes - read next index and see if it is null else create a new node by parsing string to integer            
                TreeNode leftNode = String.Compare(nodes[nodesIndex], "null") == 0 ? null : new TreeNode(int.Parse(nodes[nodesIndex]));
                TreeNode rightNode = String.Compare(nodes[nodesIndex + 1], "null") == 0 ? null : new TreeNode(int.Parse(nodes[nodesIndex + 1]));
                //Not assigning the left and right to nulls because they will be , assigned form the serialized string for sure

                nodesIndex += 2;

                TreeNode currentNode = queueForNodes.Dequeue();
                currentNode.left = leftNode;
                currentNode.right = rightNode;

                //Only add the nodes to queue if there are children for it to append i.e. the nodes are not null
                if (leftNode != null)
                    queueForNodes.Enqueue(leftNode);

                if (rightNode != null)
                    queueForNodes.Enqueue(rightNode);
            }

            return root;
        }
    }
}
