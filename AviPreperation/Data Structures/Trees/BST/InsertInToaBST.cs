using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Trees.BST
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
public class InsertInToaBSTSolution
    {

        //RECURSION
        //TC- O(logN) or O(H), h is height of the tree
        //SC - O(N)
        public TreeNode InsertIntoBST1(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);
            if (val > root.val)
                root.right = InsertIntoBST1(root.right, val);
            else
                root.left = InsertIntoBST1(root.left, val);
            return root;
        }


        //ITERATION
        //TC- O(logN) or O(H), h is height of the tree
        //SC - O(1)
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            TreeNode cur = root;
            while (cur != null)
            {
                if (val < cur.val)
                {
                    if (cur.left == null)
                    {
                        cur.left = new TreeNode(val);
                        return root;
                    }
                    else
                        cur = cur.left;
                }
                else
                    if (cur.right == null)
                {
                    cur.right = new TreeNode(val);
                    return root;
                }
                else
                    cur = cur.right;
            }

            return new TreeNode(val);
        }
    }
}
