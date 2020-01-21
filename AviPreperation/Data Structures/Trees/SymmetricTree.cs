using System;
using System.Collections.Generic;
using System.Text;
/*Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

For example, this binary tree [1,2,2,3,4,4,3] is symmetric:

    1
   / \
  2   2
 / \ / \
3  4 4  3
 

But the following [1,2,2,null,3,null,3] is not:

    1
   / \
  2   2
   \   \
   3    3
 

Note:
Bonus points if you could solve it both recursively and iteratively.*/
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
public class Solution
    {
    //RECURSION
    //TC - O(N)
    //SC - O(N)
    public bool IsSymmetric(TreeNode root)
    {
        if (root == null || (root.left == null && root.right == null))
                return true;
            if(root.left == null || root.right == null)
                return false;

            return helper(root.left, root.right);
    }

    public bool helper(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
            return true;
        if ((p == null || q == null) || (p.val != q.val))
            return false;

        if (!helper(p.left, q.right))
            return false;
        if (!helper(p.right, q.left))
            return false;

        return true;
    }


    //SHORTEST FORM OF ABOVE RECUSTION
    // public bool IsSymmetric(TreeNode root) {
    //     return helper(root, root);
    // }
    // public bool helper(TreeNode p, TreeNode q){
    //     if(p==null&&q==null) return true;
    //     if(p==null||q==null) return false;
    //     return p.val==q.val &&
    //         helper(p.right, q.left) &&
    //         helper(p.left,q.right);
    // }

    public bool IsSymmetric1(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(root);

            while (q.Count > 0)
            {
                TreeNode t1 = q.Dequeue();
                TreeNode t2 = q.Dequeue();
                if (t1 == null & t2 == null)
                    continue;
                if ((t1 == null || t2 == null) || (t1.val != t2.val))
                    return false;

                q.Enqueue(t1.left);
                q.Enqueue(t2.right);
                q.Enqueue(t1.right);
                q.Enqueue(t2.left);
            }
            return true;
        }
    }
}
