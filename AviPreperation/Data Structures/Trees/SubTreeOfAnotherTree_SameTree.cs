using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Trees
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
    public class SubTreeOfAnotherTree_SameTreeSolution
    {
        /*********************RECURSION + RECUSION*************************/
        //TC - O(m * n)
        //SC - O(n)
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null)
                return false;
            if (IsSameTree(s, t))
                return true;

            //if we use IsSameTree instead, it will return true or false, which will be our final result, so dont do it,
            //In above if condition if the trees are not eqaul, then reduce s to left and right and start the IsSubTree again
            return IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        //Same As SAMETREE solution
        public bool IsSameTree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
                return true;
            if (s == null || t == null)
                return false;
            if (s.val != t.val)
                return false;

            return IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right);
        }


        /*********************ITERATIVE + RECUSION*************************/
        
        //TC - O(m * n)
        //SC - O(n)
        public bool IsSubtree1(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
                return true;
            if (s == null || t == null)
                return false;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(s);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                if (IsSameTree(node, t)) //============>SameTree for both recusion and iteration is same, for iteration of same tree, we can do InOrder
                    return true;

                if (node.left != null)
                    stack.Push(node.left);

                if (node.right != null)
                    stack.Push(node.right);
            }

            return false;
        }
    }
}
