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
    public class LCA_LowestCommonAncestorSolution
    {
        //INORDER TRAVERSAL
        //TIME COMPLEXITY - O(N)
        //SPACE COMPLEXITY - O(N)
         public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            if (root == p || root == q)
                return root;

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
                return root;
            else
                return left == null ? right : left;
        }

        //ITERATION
        //TC- O(N)
        //SC - O(N)
        public TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
        {
            //to handle tree traversal
            Stack<TreeNode> s = new Stack<TreeNode>();
            s.Push(root);
            //To collect all ansestors of p and q
            Dictionary<TreeNode, TreeNode> d = new Dictionary<TreeNode, TreeNode>();
            d.Add(root, null);

            while (!d.ContainsKey(p) || !d.ContainsKey(q))
            {
                TreeNode ancestor = s.Pop();

                if (ancestor.left != null)
                {
                    d.Add(ancestor.left, ancestor);
                    s.Push(ancestor.left);
                }

                if (ancestor.right != null)
                {
                    d.Add(ancestor.right, ancestor);
                    s.Push(ancestor.right);
                }
            }

            //HashSEt to get the uniqie ansestors of p from the parent ancestors d
            HashSet<TreeNode> ancestors = new HashSet<TreeNode>();
            while (p != null)
            {
                ancestors.Add(p);
                p = d[p];
            }

            //check the ancestor of q in the ancestors hashset whcih have all ancestors of p
            //if matches then return the q;
            while (!ancestors.Contains(q))
            {
                q = d[q];
            }

            return q;
        }
    }
}
