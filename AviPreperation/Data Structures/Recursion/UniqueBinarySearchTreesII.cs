using System;
using System.Collections.Generic;
using System.Text;
/*
 Given an integer n, generate all structurally unique BST's (binary search trees) that store values 1 ... n.

Example:

Input: 3
Output:
[
  [1,null,3,2],
  [3,2,null,1],
  [3,1,null,null,2],
  [2,1,3],
  [1,null,2,null,3]
]
Explanation:
The above output corresponds to the 5 unique BST's shown below:

   1         3     3      2      1
    \       /     /      / \      \
     3     2     1      1   3      2
    /     /       \                 \
   2     1         2                 3*/
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

    //Time Complexity - n*Gn(Gatalanumber) ==> n*(4^n/n^(3/2)) ==> 4^n/n^(1/2)
    //Space Complexity - n*Gn(Gatalanumber) ==> n*(4^n/n^(3/2)) ==> 4^n/n^(1/2)

    public class UniqueBinarySearchTreesII
    {
        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
                return new List<TreeNode>();
            return Gen_Tree(1, n);
        }

        public List<TreeNode> Gen_Tree(int start, int end)
        {
            List<TreeNode> list = new List<TreeNode>();
            if (start > end)
            {
                list.Add(null);
                return list;
            }

            for (int i = start; i <= end; i++)
            {
                List<TreeNode> left = Gen_Tree(start, i - 1);
                List<TreeNode> right = Gen_Tree(i + 1, end);

                foreach (var l in left)
                {
                    foreach (var r in right)
                    {
                        TreeNode root = new TreeNode(i);
                        root.left = l;
                        root.right = r;
                        list.Add(root);
                    }
                }
            }
            return list;
        }
    }
}
