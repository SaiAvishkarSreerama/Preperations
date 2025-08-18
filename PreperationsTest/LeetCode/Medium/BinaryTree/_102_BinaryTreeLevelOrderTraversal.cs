/*
 * Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).
 * Example 1:
 * Input: root = [3,9,20,null,null,15,7]
 * Output: [[3],[9,20],[15,7]]
 * 
 * Example 2:
 * Input: root = [1]
 * Output: [[1]]
 * 
 * Example 3:
 * Input: root = []
 * Output: []
 * 
 * Constraints:
 * The number of nodes in the tree is in the range [0, 2000].
 * -1000 <= Node.val <= 1000
 */

//Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.BinaryTree
{
    [TestClass]
    public class _102_BinaryTreeLevelOrderTraversal
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

            var path = LevelOrder(node1);
        }

        #region Tracking level within the Queue - NOT RECOMMENDED
        /// <summary>
        /// So here we enqueue each node along with its level and processing one node at a time
        /// TC - O(n), traversing each node
        /// SC - O(n), using BFS, Queue that holds n nodes at max, but memory usage is more to maintian the level
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder_NotRecommended(TreeNode root)
        {
            Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)>();
            q.Enqueue((root, 0));

            List<IList<int>> result = new List<IList<int>>();

            while (q.Count > 0)
            {
                var (node, level) = q.Dequeue();
                if (node.left != null)
                {
                    q.Enqueue((node.left, level + 1));
                }
                if (node.right != null)
                {
                    q.Enqueue((node.right, level + 1));
                }

                if (result.Count == level)
                {
                    result.Add(new List<int>());
                }
                result[level].Add(node.val);
            }

            return result;
        }
        #endregion

        /// <summary>
        /// So here we enqueue each level to the q and process all nodes of that level in a single loop
        /// TC - O(n), traversing each node
        /// SC - O(n), using BFS, Queue that holds n nodes at max
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var level = q.Count;
                var list = new List<int>();

                // process each level at once in this loop
                for (int i = 0; i < level; i++)
                {
                    var node = q.Dequeue();
                    list.Add(node.val);
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                }

                result.Add(list);
            }

            return result;
        }
    }
}
