/*
 * Given the root of a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
 * 
 * Example 1:
 * Input: root = [1,2,3,null,5,null,4]
 * Output: [1,3,4]
 * 
 * Example 2:
 * Input: root = [1,2,3,4,null,null,null,5]
 * Output: [1,3,4,5]
 * 
 * Example 3:
 * Input: root = [1,null,3]
 * Output: [1,3]
 * 
 * Example 4:
 * Input: root = []
 * Output: []
 * 
 * Constraints:
 * The number of nodes in the tree is in the range [0, 100].
 * -100 <= Node.val <= 100
 */

namespace PreperationsTest.LeetCode.Medium.BinaryTree
{
    [TestClass]
    public class _199_BinaryTreeRightSideView
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
            //           1
            //         /   \
            //        2     3
            //       / \   / \
            //      4   5 6   7
            //     /           \
            //    8             9
            //                 /
            //               10
            // Create all nodes
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);
            TreeNode node7 = new TreeNode(7);
            TreeNode node8 = new TreeNode(8);
            TreeNode node9 = new TreeNode(9);
            TreeNode node10 = new TreeNode(10);

            // Connect nodes to form the tree
            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7;
            node4.left = node8;
            node7.right = node9;
            node9.left = node10;

            var path = RightSideView(node1);
        }

        /// <summary>
        /// Similar to Level order traversal
        /// We push each level nodes into the queue, and proccess all nodes in single for loop
        /// When we have the last node, that is our last visible node of that level, we add that nodes value into our result
        /// TC - O(n), traverse all nodes
        /// SC - O(n), BFS, Queue usage
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> RightSideView(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var level = q.Count;
                for (int i = 1; i <= level; i++) //process all nodes in queue
                {
                    TreeNode node = q.Dequeue();
                    if (i == level) // when we are at last node of that level
                    {
                        result.Add(node.val);
                    }

                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                }
            }

            return result;
        }
    }
}
