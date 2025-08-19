/*
 * Given two nodes of a binary tree p and q, return their lowest common ancestor (LCA).
 * Each node will have a reference to its parent node. The definition for Node is below:
 * class Node {
 *     public int val;
 *     public Node left;
 *     public Node right;
 *     public Node parent;
 * }
 * According to the definition of LCA on Wikipedia: "The lowest common ancestor of two nodes p and q in a tree T is the lowest node that has both p and q as descendants (where we allow a node to be a descendant of itself)."
 * 
 * Example 1:
 * Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
 * Output: 3
 * Explanation: The LCA of nodes 5 and 1 is 3.
 * 
 * Example 2:
 * Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
 * Output: 5
 * Explanation: The LCA of nodes 5 and 4 is 5 since a node can be a descendant of itself according to the LCA definition.
 * 
 * Example 3:
 * Input: root = [1,2], p = 1, q = 2
 * Output: 1
 * 
 * Constraints:
 * The number of nodes in the tree is in the range [2, 105].
 * -109 <= Node.val <= 109
 * All Node.val are unique.
 * p != q
 * p and q exist in the tree.
 * */

//Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.Trees
{
    [TestClass]
    public class _1650_LowestCommonAncestorOfBinaryTree_III
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode parent;

            public TreeNode(int x) { val = x; }
        }

        [TestMethod]

        public void Run()
        {
            TreeNode node3 = new TreeNode(3);
            TreeNode node5 = new TreeNode(5);
            TreeNode node1 = new TreeNode(1);
            TreeNode node6 = new TreeNode(6);
            TreeNode node2 = new TreeNode(2);
            TreeNode node0 = new TreeNode(0);
            TreeNode node8 = new TreeNode(8);
            TreeNode node7 = new TreeNode(7);
            TreeNode node4 = new TreeNode(4);

            // Connect nodes and set parent
            node3.left = node5;
            node3.right = node1;
            node5.parent = node3;
            node1.parent = node3;

            node5.left = node6;
            node5.right = node2;
            node6.parent = node5;
            node2.parent = node5;

            node1.left = node0;
            node1.right = node8;
            node0.parent = node1;
            node8.parent = node1;

            node2.left = node7;
            node2.right = node4;
            node7.parent = node2;
            node4.parent = node2;

            TreeNode root = node3;

            TreeNode lca_IT = LowestCommonAncestor(node6, node4);
        }

        /// <summary>
        /// TC - O(h), in worst case we traverse the height of the tree twice, with 2-pointer technique
        /// SC - O(1), no extra space is used to store the nodes
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode p, TreeNode q)
        {
            if (p == null) return q;
            if (q == null) return p;
            TreeNode left = p;
            TreeNode right = q;

            // Two pointer technique, both left and right traverse same distance to LCA, even their depths are different
            // left : 3-2-1, right: 6-5-4-1
            // left: 3-2-1-6-5-4-1, right: 6,5,4,1,3,2,1 after7 traversals they both meet at 1. when left is at first instance 1, right is at 4 only
            while (left != right)
            {
                if (left.parent != null)
                {
                    left = left.parent;
                }
                else
                {
                    left = q;
                }

                if (right.parent != null)
                {
                    right = right.parent;
                }
                else
                {
                    right = p;
                }
            }
            return left;
        }

    }
}
