using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures
{
    class IsValidBinarySearchTree
    {
        //TimeComplexity - O(N)
        //Space Complexity - O(N)
        //RECURSION
        public bool IsValidBST_RECURSION(TreeNode root)
        {
            return helper(root, null, null);
        }

        public bool helper(TreeNode root, int? lower, int? upper)
        {
            if (root == null)
                return true;

            int val = root.val;

            if ((lower != null && val <= lower) || (upper != null && val >= upper))
                return false;

            if (!helper(root.left, lower, val)) return false;
            if (!helper(root.right, val, upper)) return false;


            return true;
        }

        //TimeComplexity - O(N)
        //Space Complexity - O(N)
        //ITERATION - USING INORDER TRAVERSAL
        //Using inorder always gives [-1,0,1,2,3,4,5....] ascending order of a tree values if the tree is balanced binary tree
        public bool IsValidBST_ITERATION(TreeNode root)
        {
            if (root == null)
                return true;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode pre = null;

            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                if (pre != null && root.val <= pre.val) return false;

                pre = root;
                root = root.right;
            }

            return true;
        }

    }
}
