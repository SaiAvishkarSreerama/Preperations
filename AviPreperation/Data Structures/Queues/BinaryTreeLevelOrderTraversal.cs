using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Queues
{
//    Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

//For example:
//Given binary tree[3, 9, 20, null, null, 15, 7],
//    3
//   / \
//  9  20
//    /  \
//   15   7
//return its level order traversal as:
//[
//  [3],
//  [9,20],
//  [15,7]
//]
   //Definition for a binary tree node.
   public class TreeNode
    {
       public int val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int x) { val = x; }
   }

    public class Solution
    {
        static IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            //Console.WriteLine(q.Count);

            while (q.Count > 0)
            {
                // must take count here, if we use in for loop condition, inside the for loop queue is enqueueing  
                // more nodes, makes the for loop iterates more than expected
                int size = q.Count;
                List<int> rowList = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = q.Dequeue();
                    Console.WriteLine(node.val);
                    rowList.Add(node.val);
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                }
                result.Add(rowList);
            }

            return result;
        }
        //public static void Main()
        //{
        //    TreeNode node = new TreeNode(3);
        //    node.right = new TreeNode(9);
        //    node.left = new TreeNode(12);
        //    node.left.left = new TreeNode(25);
        //    node.left.right = new TreeNode(17);

        //    LevelOrder(node);
        //}
    }
}
