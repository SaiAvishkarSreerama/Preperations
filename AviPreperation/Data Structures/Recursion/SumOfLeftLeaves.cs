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

    //********************* THIS CODE IS FOR SUM OF ALL LEFT NODE VALUES*********************************
    //TimeComplexity - O(n)
    //SpaceComplexity - O(n)
     public class SumOfLeftNodesSolution
    {
        int res;
        public int SumOfLeftLeaves(TreeNode root)
        {
            res = 0;
            helper(root);
            return res;
        }

        public void helper(TreeNode node)
        {
            if (node == null)
                return;
            if (node.left != null)
            {
                res += node.left.val;
                helper(node.left);
            }
            helper(node.right);
        }
    }

    // *********************THIS CODE IS FOR SUM OF ALL LEFT """LEAF""" NODE VALUES*********************************
    // TimeComplexity - O(n)
    // SpaceComplexity - O(n)
    public class SumOfLeftLeavesSolution
    {
        int res;
        public int SumOfLeftLeaves(TreeNode root)
        {
            res = 0;
            helper(root);
            return res;
        }

        public void helper(TreeNode node)
        {
            if (node == null)
                return;
            if (node.left != null)
            {
                if (node.left.left == null && node.left.right == null)
                    res += node.left.val;
                helper(node.left);
            }
            helper(node.right);
        }
    }
}
