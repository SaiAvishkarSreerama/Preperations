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
    /*Given a non-empty binary tree, find the maximum path sum.

   For this problem, a path is defined as any sequence of nodes from some starting node to any node in the tree along the parent-child connections.
   The path must contain at least one node and does not need to go through the root.

   Example 1:

   Input: [1,2,3]

          1
         / \
        2   3

   Output: 6
   Example 2:

   Input: [-10,9,20,null,null,15,7]

      -10
      / \
     9  20
       /  \
      15   7
     /  \
    5    20

   Output: 62*/

    public class BinaryTreeMaximumPathSumSolution
    {
        //NOTE: any one path which gives maximum sum, in second ex, 20+15+20+7 is a path has high sum
        //TC - O(N)
        //SC - O(logN)
        int maxPath;
        public int MaxPathSum(TreeNode root)
        {
            maxPath = int.MinValue;
            helper(root);
            return maxPath;
        }

        public int helper(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = Math.Max(0, helper(root.left));
            int right = Math.Max(0, helper(root.right));

            int total = root.val + left + right;

            maxPath = Math.Max(maxPath, total);

            return root.val + Math.Max(left, right);
        }
    }
}
