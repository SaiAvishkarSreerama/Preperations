using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Recursion
{
    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
    /*Given a binary tree, determine if it is height-balanced.

   For this problem, a height-balanced binary tree is defined as:

   a binary tree in which the left and right subtrees of every node differ in height by no more than 1.



   Example 1:

   Given the following tree [3,9,20,null,null,15,7]:

       3
      / \
     9  20
       /  \
      15   7
   Return true.

   Example 2:

   Given the following tree [1,2,2,3,3,null,null,4,4]:

          1
         / \
        2   2
       / \
      3   3
     / \
    4   4
   Return false.*/
    //https://www.youtube.com/watch?v=LU4fGD-fgJQ
    //TimeComplexity - O(n)
    //SpaceComplexity - O(n)
    public class BalancedBinaryTreeSolution
    {

        //we are tracking the height of each node from the bottom node to first node
        //for that we need a helper methord for recursion
        //for each node we return a boolean ans of node is balanced or not and the hight of the node
        public class Status
        {
            public bool isBalanced;
            public int height;
            public Status(bool balanced, int height)
            {
                this.isBalanced = balanced;
                this.height = height;
            }
        }

        public bool IsBalanced(TreeNode root)
        {
            return helper(root).isBalanced;
        }

        //if the node is null means the leaf, returning true and -1, as the null node is always a balanced and no height so -1
        //for the leaf node(is a left/right for its parent), it gets -1 from its left and -1 from its right, which gives 0 height to the leaf node
        //when the absolute value of differnece of left and right heights gives >1 then is not balanced and retutn false, height
        //whenever the balanced is false, returning that node back to top and the recusion will terminates 
        public Status helper(TreeNode root)
        {
            if (root == null)
                return new Status(true, -1);

            Status left = helper(root.left);
            if (!left.isBalanced)
                return left;

            Status right = helper(root.right);
            if (!right.isBalanced)
                return right;

            bool nodeBalanced = (Math.Abs(left.height - right.height) <= 1);
            int nodeHeight = Math.Max(left.height, right.height) + 1;
            return new Status(nodeBalanced, nodeHeight);
        }


        //Approach 2
        //TimeComplexity - O(n)
        //SpaceComplexity - O(n)
        bool res = true;
        public bool IsBalanced2(TreeNode root)
        {
            if (root == null)
                return true;
            Helper(root);
            return res;
        }

        public int Helper(TreeNode node)
        {
            if (node == null)
                return 0;

            int left = Helper(node.left);
            int right = Helper(node.right);

            if (res)//if false, do not update the value
                res = Math.Abs(left - right) <= 1;

            return Math.Max(left, right) + 1; //we are at last node, so returning maxheight of left, right==> +1
        }
    }
}
