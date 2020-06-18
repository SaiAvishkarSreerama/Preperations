using System;
using System.Collections.Generic;
using System.Text;
/*
* Given preorder and inorder traversal of a tree, construct the binary tree.
* 
* Note:
* You may assume that duplicates do not exist in the tree.
* 
* For example, given
* 
* preorder = [3,9,20,15,7]
* inorder = [9,3,15,20,7]
* Return the following binary tree:
* 
*     3
*    / \
*   9  20
*     /  \
*    15   7
* */
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
    //TC - O(N)
    //SC - O(N)
    public class ConstructBinaryTreeFromPreOrderAndInOrderSolution
    {
        int[] preOrder;
        int[] inOrder;
        Dictionary<int, int> d = new Dictionary<int, int>();

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            preOrder = preorder;
            inOrder = inorder;
            for (int i = 0; i < inorder.Length; i++)
            {
                d.Add(inorder[i], i);
            }

            return helper(0, 0, inorder.Length - 1);
        }

        public TreeNode helper(int pre, int inStart, int inEnd)
        {
            if (pre > preOrder.Length - 1 || inStart > inEnd)
                return null;

            TreeNode root = new TreeNode(preOrder[pre]);
            //get the index of root.val from inorder dectionary. where its left values are left subtrees and right values are right subtrees
            int index = d[root.val];

            //inStart------------(index-1)index(index+1)----------------inEnd
            //           RightTree          |             LeftTree

            root.left = helper(pre + 1, inStart, index - 1);
            root.right = helper(pre + (index + 1) - inStart, index + 1, inEnd);

            return root;
        }
    }
}
