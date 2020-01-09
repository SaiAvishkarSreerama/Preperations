using System;
using System.Collections.Generic;
using System.Text;
//Given a binary tree, return the preorder traversal of its nodes' values.

//Example:

//Input: [1,null,2,3]
//   1
//    \
//     2
//    /
//   3

//PreOrder ===> Output: [1,2,3]
//InORder ===> Output: [1,3,2]
//PostOrder ===> Output: [3,2,1]
//Follow up: Recursive solution is trivial, could you do it iteratively?

namespace AviPreperation.Data_Structures.Stacks
{
    //Definition for a binary tree node.
    public class TreeNode
     {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {

        /**************************************************************************************************************/
        //Since the question is asked for Iteration than the Recusrsive
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            //using stack to push and pop each node
            Stack<TreeNode> stack = new Stack<TreeNode>();
            IList<int> list = new List<int>();

            // root is empty 
            if (root == null)
                return list;

            //initally push the given root node to stack
            stack.Push(root);

            //Iterating stack till it becomes empty
            while (stack.Count > 0)//Count is a property for Stack
            {
                //pop will removes the val from the stack
                TreeNode node = stack.Pop();
                //Add that node.val to the list-->output list
                list.Add(node.val);

                //doing the righ node first because Stack is a LIFO
                // If we put Left node and the Right node after the root, then order will be Root--> Right --> Left which is wrong for PREORDER TRAVERSAL
                if (node.right != null)
                    stack.Push(node.right);

                //then push left
                if (node.left != null)
                    stack.Push(node.left);
            }

            return list;
        }

        /**************************************************************************************************************/
        //RECURSION APPRAOCH
        //Time Complexity - O(N)
        //Space COmplexity - O(N)
        public IList<int> InorderTraversal_RECURSION(TreeNode root)
        {
            List<int> result = new List<int>();
            helper(root, result);
            return result;
        }

        public void helper(TreeNode root, List<int> res)
        {
            if (root == null)
                return;

            if (root.left != null)
                helper(root.left, res);

            res.Add(root.val);

            if (root.right != null)
                helper(root.right, res);
        }
        //ITERATION APPROACH
        //Time Complexity = O(N)
        //Spce Complexity = O(N)
        public IList<int> InorderTraversal_ITERATION(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            IList<int> list = new List<int>();

            // root is empty 
            if (root == null)
                return list;


            while (root != null || stack.Count > 0)
            {
                //left
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                //root
                root = (TreeNode)stack.Pop();
                list.Add(root.val);

                //right
                root = root.right;
            }
            return list;
        }

        /**************************************************************************************************************/
        public IList<int> PostorderTraversal(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> list = new List<int>();

            // root is empty 
            if (root == null)
                return list;

            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    if (root.left != null)
                        root = root.left;
                    else
                        root = root.right;
                }
                TreeNode node = stack.Pop();
                list.Add(node.val);
                if (stack.Count > 0 && stack.Peek().right != node)
                    root = stack.Peek().right;
            }
            return list;
        }

        //public static void Main()
        //{
        //    TreeNode node = new TreeNode(1);
        //    node.right = new TreeNode(2);
        //    node.right.left = new TreeNode(3);
        //    PreorderTraversal(node);
        //}
    }
}
