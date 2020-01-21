using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Given a binary tree, find its maximum depth.

The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

Note: A leaf is a node with no children.

Example:

Given binary tree [3,9,20,null,null,15,7],

    3
   / \
  9  20
    /  \
   15   7
return its depth = 3.*/
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
    public class Solution
    {
        //ITERATION
        //BFS TREE LEVEL ORDER TRAVERSAL
        //Time Complexity - O(n)
        //Space Complexity - O(n)
        public int MaxDepth_BFS(TreeNode root)
        {
            int result = 0;

            if (root == null)
                return result;

            Queue<TreeNode> q = new Queue<TreeNode>();

            q.Enqueue(root);

            while (q.Count > 0)
            {
                int size = q.Count;
                int val = 0;
                for (int i = 0; i < size; i++)
                {
                    root = q.Dequeue();
                    if (root.left != null) q.Enqueue(root.left);
                    if (root.right != null) q.Enqueue(root.right);

                    val = 1;
                }
                result += val;
            }
            return result;
        }


        //RECURSION
        //Time Complexity - O(n)
        //Space Complexity - worst case:O(n), BestCase:O(logN)
        public int MaxDepth_Recursion(TreeNode root)
        {
            if (root == null)
                return 0;
            else
            {
                int leftHeight = MaxDepth_Recursion(root.left);
                int rightHeight = MaxDepth_Recursion(root.right);

                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        //ITERATION-DFS
        //TimeComplexity - O(N)
        //Space Complexity - O(logN)
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<int> depths = new Stack<int>();

            //starting with root and level 1
            stack.Push(root);
            depths.Push(1);

            int result_depth = 0;
            int level_depth = 0;
            while (stack.Count() > 0)
            {
                root = stack.Pop();
                level_depth = depths.Pop();

                if (root != null)
                {
                    result_depth = Math.Max(result_depth, level_depth);

                    //left nodes
                    stack.Push(root.left);
                    depths.Push(level_depth + 1);

                    //right nodes
                    stack.Push(root.right);
                    depths.Push(level_depth + 1);
                }
            }
            return result_depth;
        }
    }
}
