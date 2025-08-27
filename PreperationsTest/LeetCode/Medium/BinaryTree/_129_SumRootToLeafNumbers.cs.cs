/*
 * You are given the root of a binary tree containing digits from 0 to 9 only.
 * Each root-to-leaf path in the tree represents a number.
 * For example, the root-to-leaf path 1 -> 2 -> 3 represents the number 123.
 * Return the total sum of all root-to-leaf numbers. Test cases are generated so that the answer will fit in a 32-bit integer.
 * A leaf node is a node with no children.
 * 
 * Example 1:
 * Input: root = [1,2,3]
 * Output: 25
 * Explanation:
 * The root-to-leaf path 1->2 represents the number 12.
 * The root-to-leaf path 1->3 represents the number 13.
 * Therefore, sum = 12 + 13 = 25.
 * 
 * Example 2:
 * Input: root = [4,9,0,5,1]
 * Output: 1026
 * Explanation:
 * The root-to-leaf path 4->9->5 represents the number 495.
 * The root-to-leaf path 4->9->1 represents the number 491.
 * The root-to-leaf path 4->0 represents the number 40.
 * Therefore, sum = 495 + 491 + 40 = 1026.
 *  
 * Constraints:
 * The number of nodes in the tree is in the range [1, 1000].
 * 0 <= Node.val <= 9
 * The depth of the tree will not exceed 10.
 */

// Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.BinaryTree
{
    [TestClass]
    public class _129_SumRootToLeafNumbers
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        [TestMethod]
        public void Run()
        {
            //     4
            //    / \
            //    9   0
            //   / \
            //  5   1
            // Create all nodes

            TreeNode node4 = new TreeNode(4);
            TreeNode node9 = new TreeNode(9);
            TreeNode node0 = new TreeNode(0);
            TreeNode node5 = new TreeNode(5);
            TreeNode node1 = new TreeNode(1);

            // Connect nodes
            node4.left = node9;
            node4.right = node0;
            node9.left = node5;
            node9.right = node1;

            var path = SumNumbers(node4);
        }

        public int SumNumbers(TreeNode root)
        {
            return DFS(root, 0);
        }

        /// <summary>
        /// TC - O(n)
        /// SC - O(n)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="currentSum"></param>
        /// <returns></returns>
        public int DFS(TreeNode node, int currentSum)
        {
            if (node == null)
            {
                return 0;
            }

            currentSum = currentSum * 10 + node.val;

            // IF AT LEFT, return current sum onlu
            if (node.left == null && node.right == null)
            {
                return currentSum;
            }

            return DFS(node.left, currentSum) + DFS(node.right, currentSum);
        }
    }
}
