using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructures
{
    /// <summary>
    /// Each node for the binary search tree
    /// </summary>
    class Node
    {
        private int _value;
        public Node left;//had to make them private to public to use the ref key word in deletion work
        public Node right;//had to make them private to public to use the ref key word in deletion work

        public Node()
        {            
            left = null;
            right = null;
        }

        public Node(int num)
        {
            _value = num;
            left = null;
            right = null;
        }

        public int Value
        {
            get
            {
                return this._value;
            }

            set
            {
                this._value = value;
            }
        }

        public Node Left
        {
            get {
                return left;
            }

            set
            {
                this.left = value;
            }
        }

        public Node Right  
        {
            get
            {
                return right;
            }

            set
            {
                this.right = value;
            }
        }

    }

    /// <summary>
    /// Class with implementation for Binary Search Tree
    /// </summary>
    class BinarySearchTree
    {
        public Node _rootNode = null;//had to make them private to public to use the ref key word in deletion work

        public Node RootNode
        {
            get
            {
                return _rootNode;
            }

            set
            {
                _rootNode = value;
            }
        }

        //Insert
        public Node insert(Node root, int num)
        {
            if(root == null)
            {
                root = new Node(num);
            }
            else if(num < root.Value)
            {
               root.Left= insert(root.Left, num);
            }
            else
            {
                root.Right=insert(root.Right, num);
            }

            return root;
        }

        //Delete

        //search       

        //Inorder traversal - Left,root,right
        public void InOrderTraversal(Node root)
        {
            if(root==null)
            {
                return;
            }

            //Traverse left subtree
            InOrderTraversal(root.Left);

            //root node of the subtree
            Console.WriteLine(root.Value);

            //Traverse right subtree
            InOrderTraversal(root.Right);
                                    
        }

        //post order traversal- Left,right, root
        public void PostOrderTraversal(Node root)//, int num)
        {
            if (root == null)
            {
                return;
            }

            //Traverse left subtree
            PostOrderTraversal(root.Left);

            //Traverse right subtree
            PostOrderTraversal(root.Right);

            //root node of the subtree
            Console.WriteLine(root.Value);
            
        }

        //pre-order traversal - root,Left,right
        public void PreOrderTraversal(Node root)//, int num)
        {
            if (root == null)
            {
                return;
            }

            //root node of the subtree
            Console.WriteLine(root.Value);

            //Traverse left subtree
            PreOrderTraversal(root.Left);

            //Traverse right subtree
            PreOrderTraversal(root.Right);
            
        }

        /// <summary>
        /// Find the node in BST
        /// </summary>
        /// <param name="num"></param>
        /// <returns>null if not found and if found the node</returns>
        public Node FindNode(Node node, int num)
        {
            //Element not found
            if(node==null)
            {
                return null;
            }
            
            //Element found
            if(node.Value ==num)
            {
                return node;
            }
            else if(num<node.Value)
            {
                FindNode(node.Left,num);
            }
            else if(num>node.Value)
            {
                FindNode(node.Right,num);
            }

            return null;
        }

        /// <summary>
        /// Good explanation for delete BST node:
        /// http://www.mathcs.emory.edu/~cheung/Courses/171/Syllabus/9-BinTree/BST-delete2.html
        /// 
        /// 
        /// Delete a node from BST. Three cases :
        /// 1. node has no children
        /// 2. node has either left or right child
        /// 3. node has a left child and right child
        /// </summary>
        /// <param name="node"></param>
        public bool DeleteNode(ref Node node, int key)
        {
            if (node == null)
            { 
                return false;
            }
            else if (node.Value == key)
            {
                //Call ProcessDeleteNode
                PreProcessDeleteNode(ref node);
            }
            else if (key < node.Value)
            { 
               return DeleteNode(ref node.left, key);
            }
            else if(key>node.Value)
            {
               return DeleteNode(ref node.right, key);
            }

            return true;
        }

        private void PreProcessDeleteNode(ref Node node)
        {
            if(node.Left==null && node.Right==null)
            {
                node = null;//Will set value in it's parent also it is passed by reference either parents node.left or node.right
            }
            else if(node.Left == null)
            {
                node = node.Right;
            }
            else if(node.Right == null)
            {
                node = node.Left;
            }
            else
            {
                //find either inorder successor (least element in the right sub tree) or inorder predessor (max value of left sub tree)
                //implemented for inorder successor
                //node.Value =
                   int temp ;
                    GetInOrderSuccessor(ref node, out temp);
                node.Value = temp;
            }

        }

        /// <summary>
        /// Get the Inorder Successor
        /// </summary>
        /// <param name="node"></param>
        /// <param name="temp"></param>
        private void GetInOrderSuccessor(ref Node node,out int temp)
        {
            if (node.Left == null)
            {
                temp = node.Value;
                node = null;

            }
            else
                GetInOrderSuccessor(ref node.left,out temp);
        }
    }

    
}
