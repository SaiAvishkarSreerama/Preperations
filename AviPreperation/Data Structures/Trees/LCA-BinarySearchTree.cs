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
    public class LCA_BinarySearchTreeSolution
    {
        //TC - O(N)
        //SC - O(N)
        public TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
        {
            int rootVal = root.val;
            int pVal = p.val;
            int qVal = q.val;

            if (pVal > rootVal && qVal > rootVal)
                return LowestCommonAncestor1(root.right, p, q);
            else if (pVal < rootVal && qVal < rootVal)
                return LowestCommonAncestor1(root.left, p, q);
            else
                return root;
        }

        //ITERATION
        //TC - O(N)
        //SC - O(1)
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            while (root != null)
            {
                int val = root.val;

                if (p.val > val && q.val > val)
                {
                    root = root.right;
                }
                else if (p.val < val && q.val < val)
                {
                    root = root.left;
                }
                else
                {
                    return root;
                }
            }

            return null;
        }
    }
}
